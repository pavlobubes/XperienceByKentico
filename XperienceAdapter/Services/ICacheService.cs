using Core;
using XperienceAdapter.Services.Cache.Builder;

namespace XperienceAdapter.Services;

public interface ICacheService : IService
{
    TData? TryGetData<TData>(Func<TData?> getData, Action<ICacheBuilder> buildCacheAction);

    Task<TData?> TryGetDataAsync<TData>(Func<Task<TData?>> getData, Action<ICacheBuilder> buildCacheAction);
}