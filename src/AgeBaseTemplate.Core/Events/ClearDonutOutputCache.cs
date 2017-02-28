using System;
using System.Reflection;
using DevTrends.MvcDonutCaching;
using log4net;
using Umbraco.Core;
using Umbraco.Core.Cache;
using Umbraco.Web.Cache;

namespace AgeBaseTemplate.Core.Events
{
    public class ClearDonutOutputCache : ApplicationEventHandler
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

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
            Log.Debug("Clearing output cache");
            ClearCache();
        }

        private void DictionaryCacheRefresherOnCacheUpdated(DictionaryCacheRefresher sender, CacheRefresherEventArgs cacheRefresherEventArgs)
        {
            Log.Debug("Clearing output cache");
            ClearCache();
        }

        private void DomainCacheRefresherOnCacheUpdated(DomainCacheRefresher sender, CacheRefresherEventArgs cacheRefresherEventArgs)
        {
            Log.Debug("Clearing output cache");
            ClearCache();
        }

        private void LanguageCacheRefresherOnCacheUpdated(LanguageCacheRefresher sender, CacheRefresherEventArgs cacheRefresherEventArgs)
        {
            Log.Debug("Clearing output cache");
            ClearCache();
        }

        private void MediaCacheRefresherOnCacheUpdated(MediaCacheRefresher sender, CacheRefresherEventArgs cacheRefresherEventArgs)
        {
            Log.Debug("Clearing output cache");
            ClearCache();
        }

        private void MemberCacheRefresherOnCacheUpdated(MemberCacheRefresher sender, CacheRefresherEventArgs cacheRefresherEventArgs)
        {
            Log.Debug("Clearing output cache");
            ClearCache();
        }

        private void PageCacheRefresherOnCacheUpdated(PageCacheRefresher sender, CacheRefresherEventArgs cacheRefresherEventArgs)
        {
            Log.Debug("Clearing output cache");
            ClearCache();
        }

        private void PublicAccessCacheRefresherOnCacheUpdated(PublicAccessCacheRefresher sender, CacheRefresherEventArgs cacheRefresherEventArgs)
        {
            Log.Debug("Clearing output cache");
            ClearCache();
        }

        private void UnpublishedPageCacheRefresherOnCacheUpdated(UnpublishedPageCacheRefresher sender, CacheRefresherEventArgs cacheRefresherEventArgs)
        {
            Log.Debug("Clearing output cache");
            ClearCache();
        }

        private void ClearCache()
        {
            try
            {
                _outputCacheManager.RemoveItems();
            }
            catch (Exception ex)
            {
                Log.Error("Unable to clear output cache", ex);
            }
        }
    }
}