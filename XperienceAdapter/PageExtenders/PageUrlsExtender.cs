using System.Diagnostics.Metrics;
using System.Reflection;
using System.Runtime.CompilerServices;

using CMS.ContentEngine;
using CMS.DataEngine;
using CMS.Websites;
using CMS.Websites.Internal;

using Kentico.Xperience.Admin.Base;
using Kentico.Xperience.Admin.Base.FormAnnotations;
using Kentico.Xperience.Admin.Base.Forms;
using Kentico.Xperience.Admin.Websites.UIPages;

using XperienceAdapter.PageExtenders;

[assembly: PageExtender(typeof(PageUrlsExtender))]

namespace XperienceAdapter.PageExtenders;

public class PageUrlsExtender(
    IInfoProvider<WebPageFormerUrlPathInfo> webPageFormerUrlPathInfoProvider,
    IInfoProvider<ContentLanguageInfo> contentLanguageInfoProvider,
    IWebsiteChannelDomainProvider websiteChannelDomainProvider)
    : PageExtender<UrlsTab>
{
    public override async Task<TemplateClientProperties> ConfigureTemplateProperties(
        TemplateClientProperties properties)
    {
        if (properties is not UrlsTabClientProperties urlProperties)
        {
            return await base.ConfigureTemplateProperties(properties);
        }

        urlProperties.Items.Add(await new FormCategory
        {
            Collapsible = true,
            IsCollapsed = false,
            Title = "Former URLs"
        }.GetClientProperties());

        var formerUrls = await GetFormerUrls();

        if (formerUrls.Count == 0)
        {
            var textWithLabel = new TextWithLabelComponent
            {
                Properties = new TextWithLabelProperties
                {
                    Label = "There are no former URLs for this page",
                }
            };
            textWithLabel.SetValue(" ");
            urlProperties.Items.Add(await textWithLabel.GetClientProperties());
            return await base.ConfigureTemplateProperties(urlProperties);
        }

        var domain = await websiteChannelDomainProvider.GetDomain(Page.ApplicationIdentifier.WebsiteChannelID,
            CancellationToken.None);
        foreach (var formerUrl in formerUrls)
        {
            var url = $"https://{domain}/{formerUrl.WebPageFormerUrlPath}";
            var linkComponent = new LinkComponent
            {
                Properties = new LinkProperties
                {
                    Text = url,
                    OpenInNewTab = true
                }
            };
            linkComponent.SetValue(url);

            var nameProperty = typeof(LinkComponent).GetProperty(nameof(linkComponent.Name),
                BindingFlags.Instance | BindingFlags.Public);
            nameProperty?.GetSetMethod(true)?.Invoke(linkComponent, [formerUrl.WebPageFormerUrlPath]);

            urlProperties.Items.Add(await linkComponent.GetClientProperties());
        }

        return await base.ConfigureTemplateProperties(urlProperties);
    }

    private async Task<List<WebPageFormerUrlPathInfo>> GetFormerUrls()
    {
        var languageId = (await contentLanguageInfoProvider.Get()
                .TopN(1)
                .Column(nameof(ContentLanguageInfo.ContentLanguageID))
                .WhereEquals(nameof(ContentLanguageInfo.ContentLanguageName), Page.WebPageIdentifier.LanguageName)
                .GetEnumerableTypedResultAsync())
            .First()
            .ContentLanguageID;

        var formerUrls = await webPageFormerUrlPathInfoProvider.Get()
            .WhereEquals(nameof(WebPageFormerUrlPathInfo.WebPageFormerUrlPathWebsiteChannelID),
                Page.ApplicationIdentifier.WebsiteChannelID)
            .WhereEquals(nameof(WebPageFormerUrlPathInfo.WebPageFormerUrlPathWebPageItemID),
                Page.WebPageIdentifier.WebPageItemID)
            .WhereEquals(nameof(WebPageFormerUrlPathInfo.WebPageFormerUrlPathContentLanguageID), languageId)
            .GetEnumerableTypedResultAsync();

        return formerUrls.ToList();
    }
}
