namespace Temp.Api.Applications.Caching
{
    public sealed class CacheService : AbstractCacheService, ICachePreheatable
    {
        public CacheService(ICacheProvider cacheProvider, IServiceProvider serviceProvider)
        : base(cacheProvider, serviceProvider)
        {
        }

        public override async Task PreheatAsync()
        {
            await CacheProvider.SetAsync(ConcatCacheKey("testkey", "testvalue"), 111111, TimeSpan.FromSeconds(1111));
        }
    }
}
