using CMS.Helpers;

namespace XperienceAdapter.Services.Cache.Builder;

public class CacheBuilder(string siteName, string culture) : ICacheBuilder
{
    private string? _baseKey;

    private double _cacheMinutes = CacheHelper.CacheMinutes();

    private bool _useSlidingExpiration;

    private Action<ICacheDependencyBuilder>? _configureDependenciesAction;

    private readonly string _siteName = siteName;

    private readonly string _culture = culture;

    public CustomCacheSettings Build()
    {
        if (string.IsNullOrEmpty(_baseKey))
        {
            throw new InvalidOperationException("The base cache key needs to be provided.");
        }

        return new CustomCacheSettings(_culture, _siteName, _baseKey, _cacheMinutes,
            _useSlidingExpiration, _configureDependenciesAction);
    }

    public ICacheBuilder Key(params string[] baseKeys)
    {
        _baseKey = string.Join("|", baseKeys);
        return this;
    }

    public ICacheBuilder Expiration(double cacheMinutes, bool useSliding = false)
    {
        _cacheMinutes = cacheMinutes;
        _useSlidingExpiration = useSliding;
        return this;
    }

    public ICacheBuilder Dependencies(Action<ICacheDependencyBuilder> configureDependenciesAction)
    {
        _configureDependenciesAction = configureDependenciesAction;
        return this;
    }
}