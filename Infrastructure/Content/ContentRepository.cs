using CMS.Websites;
using Domain.Content;
using Domain.Image;
using Infrastructure.ContentPage.Repository;
using Kentico.Content.Web.Mvc;

namespace Infrastructure.Content;

public class ContentRepository(
    IWebPageDataContextRetriever webPageDataContextRetriever,
    IContentPageRepository contentPageRepository,
    IWebPageUrlRetriever webPageUrlRetriever) : IContentRepository
{
    public async Task<ContentModel?> GetContent()
    {
        var webPage = webPageDataContextRetriever.Retrieve().WebPage;

        var contentPage = await contentPageRepository.GetContentPage(webPage.WebPageItemID);

        if (contentPage is null)
            return null;

        var url = await webPageUrlRetriever.Retrieve(contentPage.ContentItemID, webPage.LanguageName);

        var childPages = await contentPageRepository.GetContentPages(contentPage.WebPageItemTreePath);
        var urls = await webPageUrlRetriever.Retrieve(
            childPages.Select(p => p.WebPageItemGUID).ToArray(),
            webPage.WebsiteChannelName,
            webPage.LanguageName
        );

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