namespace XperienceAdapter.Services.Cache.Builder;

public interface ICacheBuilder
{
    ICacheBuilder Key(params string[] baseKeys);

    ICacheBuilder Expiration(double cacheMinutes, bool useSliding = false);

    ICacheBuilder Dependencies(Action<ICacheDependencyBuilder> configureDependenciesAction);
}