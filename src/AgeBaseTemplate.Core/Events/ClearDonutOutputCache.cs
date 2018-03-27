using DevTrends.MvcDonutCaching;
using Umbraco.Core;
using Umbraco.Core.Cache;
using Umbraco.Web.Cache;

namespace AgeBaseTemplate.Core.Events
{
    public class ClearDonutOutputCache : ApplicationEventHandler
    {
        private static readonly object LockObj = new object();
        private static bool _ran;
        private IOutputCacheManager _outputCacheManager;

        protected override void ApplicationStarting(UmbracoApplicationBase umbracoApplication,
            ApplicationContext applicationContext)
        {
            if (_ran)
            {
                return;
            }

            lock (LockObj)
            {
                if (_ran)
                {
                    return;
                }

                if (_outputCacheManager == null)
                {
                    _outputCacheManager = new OutputCacheManager();
                }

                CacheRefresherBase<DataTypeCacheRefresher>.CacheUpdated += DataTypeCacheRefresherOnCacheUpdated;
                CacheRefresherBase<DictionaryCacheRefresher>.CacheUpdated += DictionaryCacheRefresherOnCacheUpdated;
                CacheRefresherBase<DomainCacheRefresher>.CacheUpdated += DomainCacheRefresherOnCacheUpdated;
                CacheRefresherBase<LanguageCacheRefresher>.CacheUpdated += LanguageCacheRefresherOnCacheUpdated;
                CacheRefresherBase<MediaCacheRefresher>.CacheUpdated += MediaCacheRefresherOnCacheUpdated;
                CacheRefresherBase<MemberCacheRefresher>.CacheUpdated += MemberCacheRefresherOnCacheUpdated;
                CacheRefresherBase<PageCacheRefresher>.CacheUpdated += PageCacheRefresherOnCacheUpdated;
                CacheRefresherBase<PublicAccessCacheRefresher>.CacheUpdated += PublicAccessCacheRefresherOnCacheUpdated;
                CacheRefresherBase<UnpublishedPageCacheRefresher>.CacheUpdated += UnpublishedPageCacheRefresherOnCacheUpdated;

                _ran = true;
            }
        }

        private void DataTypeCacheRefresherOnCacheUpdated(DataTypeCacheRefresher sender,
            CacheRefresherEventArgs cacheRefresherEventArgs)
        {
            ClearCache();
        }

        private void DictionaryCacheRefresherOnCacheUpdated(DictionaryCacheRefresher sender,
            CacheRefresherEventArgs cacheRefresherEventArgs)
        {
            ClearCache();
        }

        private void DomainCacheRefresherOnCacheUpdated(DomainCacheRefresher sender,
            CacheRefresherEventArgs cacheRefresherEventArgs)
        {
            ClearCache();
        }

        private void LanguageCacheRefresherOnCacheUpdated(LanguageCacheRefresher sender,
            CacheRefresherEventArgs cacheRefresherEventArgs)
        {
            ClearCache();
        }

        private void MediaCacheRefresherOnCacheUpdated(MediaCacheRefresher sender,
            CacheRefresherEventArgs cacheRefresherEventArgs)
        {
            ClearCache();
        }

        private void MemberCacheRefresherOnCacheUpdated(MemberCacheRefresher sender,
            CacheRefresherEventArgs cacheRefresherEventArgs)
        {
            ClearCache();
        }

        private void PageCacheRefresherOnCacheUpdated(PageCacheRefresher sender,
            CacheRefresherEventArgs cacheRefresherEventArgs)
        {
            ClearCache();
        }

        private void PublicAccessCacheRefresherOnCacheUpdated(PublicAccessCacheRefresher sender,
            CacheRefresherEventArgs cacheRefresherEventArgs)
        {
            ClearCache();
        }

        private void UnpublishedPageCacheRefresherOnCacheUpdated(UnpublishedPageCacheRefresher sender,
            CacheRefresherEventArgs cacheRefresherEventArgs)
        {
            ClearCache();
        }

        private void ClearCache()
        {
            _outputCacheManager.RemoveItems();
        }
    }
}