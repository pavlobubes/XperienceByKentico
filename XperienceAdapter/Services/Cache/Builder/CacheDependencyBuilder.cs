using CMS.Helpers;

namespace XperienceAdapter.Services.Cache.Builder;

public class CacheDependencyBuilder<TData> : ICacheDependencyBuilder
{
    public string SiteName { get; }

    public string Culture { get; }


    private readonly TData? _data;


    private readonly List<string> _customKeys = [];


    public CacheDependencyBuilder(string siteName,
        string culture,
        TData? data)
    {
        SiteName = siteName;
        Culture = culture;
        _data = data;
    }

    public CMSCacheDependency Build() =>
        CacheHelper.GetCacheDependency(_customKeys);

    public ICacheDependencyBuilder Custom(params string[] keys)
    {
        _customKeys.AddRange(keys);
        return this;
    }
}