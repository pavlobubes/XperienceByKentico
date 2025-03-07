using CMS.Helpers;
using CMS.Websites.Routing;
using Kentico.Content.Web.Mvc.Routing;
using Microsoft.AspNetCore.Http;
using System.Collections;
using XperienceAdapter.Services.Cache.Builder;

namespace XperienceAdapter.Services.Implementations;

public class CacheService(IProgressiveCache progressiveCache,
        IWebsiteChannelContext websiteChannelContext,
        IHttpContextAccessor httpContextAccessor,
        IPreferredLanguageRetriever preferredLanguageRetriever) : ICacheService
{
    public TData? TryGetData<TData>(Func<TData?> getData, Action<ICacheBuilder> buildCacheAction) =>
        GetAndSetCache(getData, GetCacheSetting(buildCacheAction));

    public Task<TData?> TryGetDataAsync<TData>(Func<Task<TData?>> getData, Action<ICacheBuilder> buildCacheAction)
    {
        var token = httpContextAccessor.HttpContext?.RequestAborted ?? default;

        return websiteChannelContext.IsPreview
            ? getData()
            : GetAndSetCacheAsync(getData, GetCacheSetting(buildCacheAction), token);
    }

    private TData? GetAndSetCache<TData>(Func<TData?> getData,
        CustomCacheSettings cacheSettings) =>
        progressiveCache.Load(GetLoadDataFunc(getData, cacheSettings), cacheSettings.GetSettings());

    private Task<TData?> GetAndSetCacheAsync<TData>(Func<Task<TData?>> getData,
        CustomCacheSettings cacheSettings,
        CancellationToken cancellationToken) =>
        progressiveCache.LoadAsync(GetLoadDataAsyncFunc(getData, cacheSettings),
            cacheSettings.GetSettings(), cancellationToken);

    private static Func<CacheSettings, TData?> GetLoadDataFunc<TData>(
        Func<TData?> getData,
        CustomCacheSettings settings) => cacheSettings =>
        {
            var data = getData();
            ApplyCacheParameters(cacheSettings, settings, data);
            return data;
        };

    private static Func<CacheSettings, CancellationToken, Task<TData?>> GetLoadDataAsyncFunc<TData>(
        Func<Task<TData?>> getData,
        CustomCacheSettings settings) => async (cacheSettings, _) =>
        {
            var data = await getData();
            ApplyCacheParameters(cacheSettings, settings, data);
            return data;
        };

    private static void ApplyCacheParameters<TData>(CacheSettings cacheSettings,
        CustomCacheSettings settings,
        TData? data)
    {
        if (data is null or ICollection { Count: 0 })
        {
            cacheSettings.Cached = false;
        }
        else
        {
            cacheSettings.CacheDependency = settings.GetDependency(data);
        }
    }

    private CustomCacheSettings GetCacheSetting(Action<ICacheBuilder> buildCacheAction)
    {
        var siteName = websiteChannelContext.WebsiteChannelName;
        var culture = preferredLanguageRetriever.Get();

        var cacheBuilder = new CacheBuilder(siteName, culture);

        buildCacheAction(cacheBuilder);

        return cacheBuilder.Build();
    }
}