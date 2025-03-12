using Microsoft.AspNetCore.Http;
using CMS.ContentEngine;
using CMS.Websites;
using CMS.Websites.Routing;
using Kentico.Content.Web.Mvc.Routing;

namespace XperienceAdapter.Services.Implementations;

public class PageContentService(
    IHttpContextAccessor httpContextAccessor,
    IContentQueryExecutor executor,
    IWebsiteChannelContext websiteChannelContext,
    IPreferredLanguageRetriever preferredLanguageRetriever) : IPageContentService
{
    public async Task<IEnumerable<TPage>> RetrieveAsync<TPage>(string contentType, Action<ContentTypeQueryParameters>? filter = null)
        where TPage : IWebPageFieldsSource
    {
        var builder = GetQuery(contentType, filter);
        var options = GetOptions();

        if (httpContextAccessor.HttpContext is null)
            return await executor.GetMappedWebPageResult<TPage>(builder, options);
        else
            return await executor.GetMappedWebPageResult<TPage>(builder, options, httpContextAccessor.HttpContext.RequestAborted);
    }

    public async Task<TPage?> RetrieveOneAsync<TPage>(string contentType, Action<ContentTypeQueryParameters>? filter = null)
        where TPage : IWebPageFieldsSource
    {
        var builder = GetQuery(contentType, filter);
        var options = GetOptions();

        if (httpContextAccessor.HttpContext is null)
            return (await executor.GetMappedWebPageResult<TPage>(builder, options)).FirstOrDefault();
        else
            return (await executor.GetMappedWebPageResult<TPage>(builder, options, httpContextAccessor.HttpContext.RequestAborted)).FirstOrDefault();
    }

    private ContentItemQueryBuilder GetQuery(string contentType, Action<ContentTypeQueryParameters>? filter)
    {
        return new ContentItemQueryBuilder()
            .ForContentType(
                contentType,
                filter + (filter => filter.ForWebsite(websiteChannelContext.WebsiteChannelName))
        ).InLanguage(preferredLanguageRetriever.Get());
    }

    private ContentQueryExecutionOptions GetOptions(bool includeSecuredItems = false)
    {
        return new ContentQueryExecutionOptions()
        {
            ForPreview = websiteChannelContext.IsPreview,
            IncludeSecuredItems = includeSecuredItems || websiteChannelContext.IsPreview
        };
    }
}