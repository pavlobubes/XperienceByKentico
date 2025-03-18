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

    public async Task<IEnumerable<ContentPageDto>> GetContentPagesAnyTag(IEnumerable<Guid> categories) =>
        await GetPagesAsync(
            XperienceAdapter.Models.PageContentTypes.DancingGoat.Content.Content.CONTENT_TYPE_NAME,
            query => query.Where(where => where.WhereContainsTags(nameof(ContentPageDto.Categories), categories)).WithLinkedItems(3)
        );

    public async Task<IEnumerable<ContentPageDto>> GetContentPagesAllTags(List<Guid> categories) =>
        await GetPagesAsync(
            XperienceAdapter.Models.PageContentTypes.DancingGoat.Content.Content.CONTENT_TYPE_NAME,
            query =>
            {
                query.WithLinkedItems(3);
                query.Where(where =>
                {
                    for (int i = 0; i < categories.Count(); i++)
                    {
                        where.WhereContainsTags(nameof(ContentPageDto.Categories), [categories[i]]);
                        if (i < categories.Count() - 1)
                            where.And();
                    }
                });
            }
        );

    protected override ContentPageDto MapProperties(XperienceAdapter.Models.PageContentTypes.DancingGoat.Content.Content page)
    {
        return new(page);
    }
}