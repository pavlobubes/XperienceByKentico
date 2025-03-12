using CMS.Websites;
using Infrastructure.ContentPage.Dto;
using XperienceAdapter.Repositories.Implementations;

namespace Infrastructure.ContentPage.Repository;

public class ContentPageRepository : BasePageContentRepository<ContentPageDto, XperienceAdapter.Models.PageContentTypes.DancingGoat.Content.Content>, IContentPageRepository
{
    public async Task<ContentPageDto?> GetContentPage(int WebPageItemID) =>
        await GetPageAsync(
            XperienceAdapter.Models.PageContentTypes.DancingGoat.Content.Content.CONTENT_TYPE_NAME,
            query => query.Where(where => where.WhereEquals(nameof(IWebPageContentQueryDataContainer.WebPageItemID), WebPageItemID)).WithLinkedItems(3)
        );

    public async Task<IEnumerable<ContentPageDto>> GetContentPages(string parentPath) =>
        await GetPagesAsync(
            XperienceAdapter.Models.PageContentTypes.DancingGoat.Content.Content.CONTENT_TYPE_NAME,
            query => query.Where(where => where.WhereNotEquals(nameof(IWebPageContentQueryDataContainer.WebPageItemTreePath), parentPath)
                .WhereStartsWith(nameof(IWebPageContentQueryDataContainer.WebPageItemTreePath), parentPath))
                .WithLinkedItems(3)
        );

    protected override ContentPageDto MapProperties(XperienceAdapter.Models.PageContentTypes.DancingGoat.Content.Content page)
    {
        return new(page);
    }
}