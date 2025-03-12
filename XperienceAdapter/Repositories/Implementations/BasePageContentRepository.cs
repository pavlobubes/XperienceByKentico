using CMS.ContentEngine;
using CMS.Websites;
using Core;
using XperienceAdapter.Models;
using XperienceAdapter.Services;

namespace XperienceAdapter.Repositories.Implementations;

public abstract class BasePageContentRepository<TPageModel, TPage> : IRepository
    where TPageModel : BasicPage, IPage
    where TPage : IWebPageFieldsSource
{
    public required IPageContentService PageContentService { private get; init; }

    protected async Task<IEnumerable<TPageModel>> GetPagesAsync(string contentType, Action<ContentTypeQueryParameters>? filter = default) =>
        MapPages(await PageContentService.RetrieveAsync<TPage>(contentType, ColumnsSetup + filter));

    protected async Task<TPageModel?> GetPageAsync(string contentType, Action<ContentTypeQueryParameters>? filter = default) =>
        MapPage(await PageContentService.RetrieveOneAsync<TPage>(contentType, ColumnsSetup + filter + GetOne));

    private List<TPageModel> MapPages(IEnumerable<TPage> pages) =>
        new(pages.Select(MapProperties));

    private TPageModel? MapPage(TPage? page) =>
        page is null ? null : MapProperties(page);

    private static void ColumnsSetup(ContentTypeQueryParameters q) => q
        .Columns([..BasicPage.SourceColumns, ..TPageModel.Columns]);

    private static void GetOne(ContentTypeQueryParameters q) => q
        .TopN(1);

    protected abstract TPageModel MapProperties(TPage page);
}