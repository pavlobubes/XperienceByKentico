using CMS.ContentEngine;
using CMS.DataEngine;
using CMS.Websites;
using Domain.Content;
using Domain.Image;
using Infrastructure.ContentPage.Repository;
using XperienceAdapter.Models.Classes.DancingGoat.GlobalSettingsKey;

namespace Infrastructure.Content;

public class ContentRepository(
    IContentPageRepository contentPageRepository,
    IWebPageUrlRetriever webPageUrlRetriever,
    IInfoProvider<GlobalSettingsKeyInfo> globalSettingsKeyInfoProvider,
    ITaxonomyRetriever taxonomyRetriever) : IContentRepository
{
    public async Task<ContentModel?> GetContent(int WebPageItemID, string LanguageName, string WebsiteChannelName)
    {
        var contentPage = await contentPageRepository.GetContentPage(WebPageItemID);

        if (contentPage is null)
            return null;

        var url = await webPageUrlRetriever.Retrieve(WebPageItemID, LanguageName);

        var childPages = await contentPageRepository.GetContentPages(contentPage.WebPageItemTreePath);
        var urls = await webPageUrlRetriever.Retrieve(
            childPages.Select(p => p.WebPageItemGUID).ToArray(),
            WebsiteChannelName,
            LanguageName
        );

        var taxonomy = await taxonomyRetriever.RetrieveTaxonomy("Carpets", LanguageName);
        if (taxonomy is not null)
        {
            var taxonomyPagesAny = await contentPageRepository.GetContentPagesAnyTag(taxonomy.Tags.Select(t => t.Identifier));
            var taxonomyPagesAll = await contentPageRepository.GetContentPagesAllTags(taxonomy.Tags.Select(t => t.Identifier).ToList());
        }

        var testSetting = await globalSettingsKeyInfoProvider.Get()
            .WhereEquals(nameof(GlobalSettingsKeyInfo.GlobalSettingsKeyName), "TestKey")
            .TopN(1)
            .GetEnumerableTypedResultAsync();

        return new ContentModel(
            contentPage.Title,
            contentPage.Description,
            contentPage.ImageThumbnail.Select(image => new ImageModel(
                image.ImageTitle,
                image.ImageDescription,
                image.ImageThumbnail.Url,
                image.ImageThumbnail.VariantUrls.Select(variant => new ImageVariantModel(variant.Key, variant.Value)))
            ),
            url?.RelativePath ?? string.Empty
        );
    }
}