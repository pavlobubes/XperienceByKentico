using CMS.Helpers;

namespace XperienceAdapter.Services.Cache.Builder;

public class CustomCacheSettings(string cultureCode,
        string siteName,
        string baseKey,
        double cacheMinutes,
        bool useSlidingExpiration,
        Action<ICacheDependencyBuilder>? customDependencies)
{

    public CacheSettings GetSettings() => new(cacheMinutes, useSlidingExpiration, GetCacheItemNameParts());

    public CMSCacheDependency GetDependency<TData>(TData? data)
    {
        var dependencyBuilder = new CacheDependencyBuilder<TData>
        (
            siteName,
            cultureCode,
            data
        );

        customDependencies?.Invoke(dependencyBuilder);

        return dependencyBuilder.Build();
    }

    private object[] GetCacheItemNameParts() => [baseKey, siteName, cultureCode];
}