namespace XperienceAdapter.Services.Cache.Builder;

public interface ICacheDependencyBuilder
{
    internal string SiteName { get; }

    internal string Culture { get; }

    ICacheDependencyBuilder Custom(params string[] keys);
}