using CMS.ContentEngine;
using CMS.Websites;
using Core;

namespace XperienceAdapter.Services;

public interface IPageContentService : IService
{
    Task<IEnumerable<TPage>> RetrieveAsync<TPage>(string contentType, Action<ContentTypeQueryParameters>? filter = null)
        where TPage : IWebPageFieldsSource;

    Task<TPage?> RetrieveOneAsync<TPage>(string contentType, Action<ContentTypeQueryParameters>? filter = null)
        where TPage : IWebPageFieldsSource;
}