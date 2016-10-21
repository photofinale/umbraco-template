using System;
using AgeBaseTemplate.Core.Services;
using AgeBaseTemplate.Core.Services.Implementations;
using DevTrends.MvcDonutCaching;
using Umbraco.Core;
using Umbraco.Core.Cache;
using Umbraco.Core.Events;
using Umbraco.Core.Models;
using Umbraco.Core.Publishing;
using Umbraco.Core.Services;
using Umbraco.Web.Cache;

namespace AgeBaseTemplate.Core.Events
{
    public class ClearOutputCacheManager : IApplicationEventHandler
    {
        private static readonly object LockObj = new object();
        private static bool _ran;

        private ILogService _logService;
        private IOutputCacheManager _outputCacheManager;

        public ClearOutputCacheManager()
        {
        }

        public ClearOutputCacheManager(ILogService logService, IOutputCacheManager outputCacheManager)
        {
            _logService = logService;
            _outputCacheManager = outputCacheManager;
        }

        public void OnApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            if (_logService == null)
                _logService = new LogService();

            if (_outputCacheManager == null)
                _outputCacheManager = new OutputCacheManager();

            if (_ran)
                return;

            lock (LockObj)
            {
                if (_ran)
                    return;

                _logService.Debug<ClearOutputCacheManager>("OnApplicationStarted", "Setting up event");

                // Content
                ContentService.Deleted += ContentServiceOnDeleted;
                ContentService.EmptiedRecycleBin += ContentServiceOnEmptiedRecycleBin;
                ContentService.Published += ContentServiceOnPublished;
                ContentService.RolledBack += ContentServiceOnRolledBack;
                ContentService.Trashed += ContentServiceOnTrashed;
                ContentService.UnPublished += ContentServiceOnUnPublished;

                // Data Types
                DataTypeService.Saved += DataTypeServiceOnSaved;

                // Domains
                DomainService.Deleted += DomainServiceOnDeleted;
                DomainService.Saved += DomainServiceOnSaved;

                // Localizations
                LocalizationService.DeletedDictionaryItem += LocalizationServiceOnDeletedDictionaryItem;
                LocalizationService.SavedDictionaryItem += LocalizationServiceOnSavedDictionaryItem;

                // Media
                MediaService.Deleted += MediaServiceOnDeleted;
                MediaService.EmptiedRecycleBin += MediaServiceOnEmptiedRecycleBin;
                MediaService.Saved += MediaServiceOnSaved;
                MediaService.Trashed += MediaServiceOnTrashed;

                // Members
                MemberService.Deleted += MemberServiceOnDeleted;
                MemberService.Saved += MemberServiceOnSaved;

                // Public Access
                PublicAccessService.Deleted += PublicAccessServiceOnDeleted;
                PublicAccessService.Saved += PublicAccessServiceOnSaved;

                // Cache Refreshers
                DataTypeCacheRefresher.CacheUpdated += DataTypeCacheRefresherOnCacheUpdated;
                DictionaryCacheRefresher.CacheUpdated += DictionaryCacheRefresherOnCacheUpdated;
                DomainCacheRefresher.CacheUpdated += DomainCacheRefresherOnCacheUpdated;
                LanguageCacheRefresher.CacheUpdated += LanguageCacheRefresherOnCacheUpdated;
                MediaCacheRefresher.CacheUpdated += MediaCacheRefresherOnCacheUpdated;
                MemberCacheRefresher.CacheUpdated += MemberCacheRefresherOnCacheUpdated;
                PageCacheRefresher.CacheUpdated += PageCacheRefresherOnCacheUpdated;
                PublicAccessCacheRefresher.CacheUpdated += PublicAccessCacheRefresherOnCacheUpdated;
                UnpublishedPageCacheRefresher.CacheUpdated += UnpublishedPageCacheRefresherOnCacheUpdated;

                _ran = true;
            }
        }

        private void ContentServiceOnDeleted(IContentService sender, DeleteEventArgs<IContent> deleteEventArgs)
        {
            _logService.Debug<ClearOutputCacheManager>("ContentService.Deleted", "ContentServiceOnDeleted clearing output cache");
            ClearCache();
        }

        private void ContentServiceOnEmptiedRecycleBin(IContentService sender, RecycleBinEventArgs recycleBinEventArgs)
        {
            _logService.Debug<ClearOutputCacheManager>("ContentService.EmptiedRecycleBin", "ContentServiceOnEmptiedRecycleBin clearing output cache");
            ClearCache();
        }

        private void ContentServiceOnPublished(IPublishingStrategy sender, PublishEventArgs<IContent> publishEventArgs)
        {
            _logService.Debug<ClearOutputCacheManager>("ContentService.Published", "ContentServiceOnPublished clearing output cache");
            ClearCache();
        }

        private void ContentServiceOnRolledBack(IContentService sender, RollbackEventArgs<IContent> rollbackEventArgs)
        {
            _logService.Debug<ClearOutputCacheManager>("ContentService.RolledBack", "ContentServiceOnRolledBack clearing output cache");
            ClearCache();
        }

        private void ContentServiceOnTrashed(IContentService sender, MoveEventArgs<IContent> moveEventArgs)
        {
            _logService.Debug<ClearOutputCacheManager>("ContentService.Trashed", "ContentServiceOnTrashed clearing output cache");
            ClearCache();
        }

        private void ContentServiceOnUnPublished(IPublishingStrategy sender, PublishEventArgs<IContent> publishEventArgs)
        {
            _logService.Debug<ClearOutputCacheManager>("ContentService.UnPublished", "ContentServiceOnUnPublished clearing output cache");
            ClearCache();
        }

        private void DataTypeCacheRefresherOnCacheUpdated(DataTypeCacheRefresher sender, CacheRefresherEventArgs cacheRefresherEventArgs)
        {
            _logService.Debug<ClearOutputCacheManager>("DataTypeCacheRefresher.CacheUpdated", "DataTypeCacheRefresherOnCacheUpdated clearing output cache");
            ClearCache();
        }

        private void DataTypeServiceOnSaved(IDataTypeService sender, SaveEventArgs<IDataTypeDefinition> saveEventArgs)
        {
            _logService.Debug<ClearOutputCacheManager>("DataTypeService.Saved", "DataTypeServiceOnSaved clearing output cache");
            ClearCache();
        }

        private void DomainCacheRefresherOnCacheUpdated(DomainCacheRefresher sender, CacheRefresherEventArgs cacheRefresherEventArgs)
        {
            _logService.Debug<ClearOutputCacheManager>("DomainCacheRefresher.CacheUpdated", "DomainCacheRefresherOnCacheUpdated clearing output cache");
            ClearCache();
        }

        private void DictionaryCacheRefresherOnCacheUpdated(DictionaryCacheRefresher sender, CacheRefresherEventArgs cacheRefresherEventArgs)
        {
            _logService.Debug<ClearOutputCacheManager>("DictionaryCacheRefresher.CacheUpdated", "DictionaryCacheRefresherOnCacheUpdated clearing output cache");
            ClearCache();
        }

        private void DomainServiceOnDeleted(IDomainService sender, DeleteEventArgs<IDomain> deleteEventArgs)
        {
            _logService.Debug<ClearOutputCacheManager>("DomainService.Deleted", "DomainServiceOnDeleted clearing output cache");
            ClearCache();
        }

        private void DomainServiceOnSaved(IDomainService sender, SaveEventArgs<IDomain> saveEventArgs)
        {
            _logService.Debug<ClearOutputCacheManager>("DomainService.Saved", "DomainServiceOnSaved clearing output cache");
            ClearCache();
        }

        private void LanguageCacheRefresherOnCacheUpdated(LanguageCacheRefresher sender, CacheRefresherEventArgs cacheRefresherEventArgs)
        {
            _logService.Debug<ClearOutputCacheManager>("LanguageCacheRefresher.CacheUpdated", "LanguageCacheRefresherOnCacheUpdated clearing output cache");
            ClearCache();
        }

        private void LocalizationServiceOnDeletedDictionaryItem(ILocalizationService sender, DeleteEventArgs<IDictionaryItem> deleteEventArgs)
        {
            _logService.Debug<ClearOutputCacheManager>("LocalizationService.DeletedDictionaryItem", "LocalizationServiceOnDeletedDictionaryItem clearing output cache");
            ClearCache();
        }

        private void LocalizationServiceOnSavedDictionaryItem(ILocalizationService sender, SaveEventArgs<IDictionaryItem> saveEventArgs)
        {
            _logService.Debug<ClearOutputCacheManager>("LocalizationService.SavedDictionaryItem", "LocalizationServiceOnSavedDictionaryItem clearing output cache");
            ClearCache();
        }

        private void MediaServiceOnDeleted(IMediaService sender, DeleteEventArgs<IMedia> deleteEventArgs)
        {
            _logService.Debug<ClearOutputCacheManager>("MediaService.Deleted", "MediaServiceOnDeleted clearing output cache");
            ClearCache();
        }

        private void MediaServiceOnEmptiedRecycleBin(IMediaService sender, RecycleBinEventArgs recycleBinEventArgs)
        {
            _logService.Debug<ClearOutputCacheManager>("MediaService.EmptiedRecycleBin", "MediaServiceOnEmptiedRecycleBin clearing output cache");
            ClearCache();
        }

        private void MediaServiceOnSaved(IMediaService sender, SaveEventArgs<IMedia> saveEventArgs)
        {
            _logService.Debug<ClearOutputCacheManager>("MediaService.Saved", "MediaServiceOnSaved clearing output cache");
            ClearCache();
        }

        private void MediaServiceOnTrashed(IMediaService sender, MoveEventArgs<IMedia> moveEventArgs)
        {
            _logService.Debug<ClearOutputCacheManager>("MediaService.Trashed", "MediaServiceOnTrashed clearing output cache");
            ClearCache();
        }

        private void MediaCacheRefresherOnCacheUpdated(MediaCacheRefresher sender, CacheRefresherEventArgs cacheRefresherEventArgs)
        {
            _logService.Debug<ClearOutputCacheManager>("MediaCacheRefresher.CacheUpdated", "MediaCacheRefresherOnCacheUpdated clearing output cache");
            ClearCache();
        }

        private void MemberCacheRefresherOnCacheUpdated(MemberCacheRefresher sender, CacheRefresherEventArgs cacheRefresherEventArgs)
        {
            _logService.Debug<ClearOutputCacheManager>("MemberCacheRefresher.CacheUpdated", "MemberCacheRefresherOnCacheUpdated clearing output cache");
            ClearCache();
        }

        private void MemberServiceOnDeleted(IMemberService sender, DeleteEventArgs<IMember> deleteEventArgs)
        {
            _logService.Debug<ClearOutputCacheManager>("MemberService.OnDeleted", "MemberServiceOnDeleted clearing output cache");
            ClearCache();
        }

        private void MemberServiceOnSaved(IMemberService sender, SaveEventArgs<IMember> saveEventArgs)
        {
            _logService.Debug<ClearOutputCacheManager>("MemberService.OnSaved", "MemberServiceOnSaved clearing output cache");
            ClearCache();
        }

        private void PageCacheRefresherOnCacheUpdated(PageCacheRefresher sender, CacheRefresherEventArgs cacheRefresherEventArgs)
        {
            _logService.Debug<ClearOutputCacheManager>("PageCacheRefresher.CacheUpdated", "PageCacheRefresherOnCacheUpdated clearing output cache");
            ClearCache();
        }

        private void PublicAccessCacheRefresherOnCacheUpdated(PublicAccessCacheRefresher sender, CacheRefresherEventArgs cacheRefresherEventArgs)
        {
            _logService.Debug<ClearOutputCacheManager>("PublicAccessCacheRefresher.CacheUpdated", "PublicAccessCacheRefresherOnCacheUpdated clearing output cache");
            ClearCache();
        }

        private void PublicAccessServiceOnDeleted(IPublicAccessService sender, DeleteEventArgs<PublicAccessEntry> deleteEventArgs)
        {
            _logService.Debug<ClearOutputCacheManager>("PublicAccessService.OnDeleted", "PublicAccessServiceOnDeleted clearing output cache");
            ClearCache();
        }

        private void PublicAccessServiceOnSaved(IPublicAccessService sender, SaveEventArgs<PublicAccessEntry> saveEventArgs)
        {
            _logService.Debug<ClearOutputCacheManager>("PublicAccessService.OnSaved", "PublicAccessServiceOnSaved clearing output cache");
            ClearCache();
        }

        private void UnpublishedPageCacheRefresherOnCacheUpdated(UnpublishedPageCacheRefresher sender, CacheRefresherEventArgs cacheRefresherEventArgs)
        {
            _logService.Debug<ClearOutputCacheManager>("UnpublishedPageCacheRefresher.CacheUpdated", "UnpublishedPageCacheRefresherOnCacheUpdated clearing output cache");
            ClearCache();
        }

        private void ClearCache()
        {
            try
            {
                _logService.Debug<ClearOutputCacheManager>("ClearCache");
                _outputCacheManager.RemoveItems();
            }
            catch (Exception ex)
            {
                _logService.Error<ClearOutputCacheManager>("ClearCache", ex, "Unable to clear output cache");
            }
        }

        public void OnApplicationInitialized(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
        }

        public void OnApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
        }
    }
}