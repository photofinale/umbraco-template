using System;
using AgeBaseTemplate.Core.Services;
using AgeBaseTemplate.Core.Services.Implementations;
using DevTrends.MvcDonutCaching;
using Umbraco.Core;
using Umbraco.Core.Cache;
using Umbraco.Web.Cache;

namespace AgeBaseTemplate.Core.Events
{
    public class ClearDonutOutputCache : ApplicationEventHandler
    {
        private ILogService _logService;
        private IOutputCacheManager _outputCacheManager;

        private static readonly object LockObj = new object();
        private static bool _ran;

        protected override void ApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            if (_ran)
                return;

            lock (LockObj)
            {
                if (_ran)
                    return;

                if (_logService == null)
                    _logService = new LogService();

                if (_outputCacheManager == null)
                    _outputCacheManager = new OutputCacheManager();

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

        private void DataTypeCacheRefresherOnCacheUpdated(DataTypeCacheRefresher sender, CacheRefresherEventArgs cacheRefresherEventArgs)
        {
            _logService.Debug<ClearDonutOutputCache>("DataTypeCacheRefresherOnCacheUpdated");
            ClearCache();
        }

        private void DictionaryCacheRefresherOnCacheUpdated(DictionaryCacheRefresher sender, CacheRefresherEventArgs cacheRefresherEventArgs)
        {
            _logService.Debug<ClearDonutOutputCache>("DictionaryCacheRefresherOnCacheUpdated");
            ClearCache();
        }

        private void DomainCacheRefresherOnCacheUpdated(DomainCacheRefresher sender, CacheRefresherEventArgs cacheRefresherEventArgs)
        {
            _logService.Debug<ClearDonutOutputCache>("DomainCacheRefresherOnCacheUpdated");
            ClearCache();
        }

        private void LanguageCacheRefresherOnCacheUpdated(LanguageCacheRefresher sender, CacheRefresherEventArgs cacheRefresherEventArgs)
        {
            _logService.Debug<ClearDonutOutputCache>("LanguageCacheRefresherOnCacheUpdated");
            ClearCache();
        }

        private void MediaCacheRefresherOnCacheUpdated(MediaCacheRefresher sender, CacheRefresherEventArgs cacheRefresherEventArgs)
        {
            _logService.Debug<ClearDonutOutputCache>("MediaCacheRefresherOnCacheUpdated");
            ClearCache();
        }

        private void MemberCacheRefresherOnCacheUpdated(MemberCacheRefresher sender, CacheRefresherEventArgs cacheRefresherEventArgs)
        {
            _logService.Debug<ClearDonutOutputCache>("MemberCacheRefresherOnCacheUpdated");
            ClearCache();
        }

        private void PageCacheRefresherOnCacheUpdated(PageCacheRefresher sender, CacheRefresherEventArgs cacheRefresherEventArgs)
        {
            _logService.Debug<ClearDonutOutputCache>("PageCacheRefresherOnCacheUpdated");
            ClearCache();
        }

        private void PublicAccessCacheRefresherOnCacheUpdated(PublicAccessCacheRefresher sender, CacheRefresherEventArgs cacheRefresherEventArgs)
        {
            _logService.Debug<ClearDonutOutputCache>("PublicAccessCacheRefresherOnCacheUpdated");
            ClearCache();
        }

        private void UnpublishedPageCacheRefresherOnCacheUpdated(UnpublishedPageCacheRefresher sender, CacheRefresherEventArgs cacheRefresherEventArgs)
        {
            _logService.Debug<ClearDonutOutputCache>("UnpublishedPageCacheRefresherOnCacheUpdated");
            ClearCache();
        }

        private void ClearCache()
        {
            try
            {
                _logService.Debug<ClearDonutOutputCache>("ClearCache");
                _outputCacheManager.RemoveItems();
            }
            catch (Exception ex)
            {
                _logService.Error<ClearDonutOutputCache>("ClearCache", ex, "Unable to clear output cache");
            }
        }
    }
}