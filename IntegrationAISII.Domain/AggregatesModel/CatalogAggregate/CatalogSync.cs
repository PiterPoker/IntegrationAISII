using IntegrationAISII.Domain.SeedWork;

namespace IntegrationAISII.Domain.AggregatesModel.CatalogAggregate
{
    /// <summary>
    /// Абстрактная модель: Таблицы синхронизации справочника «Виды документов»
    /// </summary>
    public abstract class CatalogSync : Entity, ICatalogSync
    {
        private long _subscriberId;
        private bool _isSync;

        /// <summary>
        /// Запись справочника «Типы файлов»
        /// </summary>
        public abstract long EntitySyncId { get; }
        /// <summary>
        /// Абонент коннектора
        /// </summary>
        public long SubscriberId { get => _subscriberId; }
        /// <summary>
        /// Признак синхронизации с системой абонента
        /// </summary>
        public bool IsSync { get => _isSync; }

        protected CatalogSync(long subscriberId)
        {
            _subscriberId = subscriberId;
            _isSync = false;
        }

        public virtual void SetIsSync(bool value)
        {
            this._isSync = value;
        }
    }
}