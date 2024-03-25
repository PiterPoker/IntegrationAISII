using IntegrationAISII.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IntegrationAISII.Domain.AggregatesModel.CatalogAggregate
{
    /// <summary>
    /// Абстрактная Модель: Справочников
    /// </summary>
    public abstract class Catalog : Entity, IAggregateRoot, ICatalog
    {
        private Guid _objid;
        private Guid _aisiiId;
        private DateTime _createDate;
        private bool _isActual;
        private string? _name;
        protected Catalog()
        {
        }

        protected Catalog(ICatalog catalog) : this(catalog.ObjId, catalog.CreateDate, catalog.Name, catalog.IsActual, catalog.AisiiId)
        {
        }

        protected Catalog(Guid objid, DateTime createDate, string name, bool isActual, Guid aisiiId) : this()
        {
            _objid = objid != Guid.Empty ? objid : throw new IntegrationAISIIDomainException($"Invalid {nameof(objid)} must be greater than zero");
            _createDate = createDate != DateTime.MinValue ? createDate : throw new IntegrationAISIIDomainException($"Invalid {nameof(createDate)} must be greater than the minimum");
            _name = !string.IsNullOrWhiteSpace(name) ? name : throw new IntegrationAISIIDomainException($"Invalid {nameof(createDate)} must not be empty");
            _isActual = isActual;
            _aisiiId = aisiiId != Guid.Empty ? aisiiId : throw new IntegrationAISIIDomainException($"Invalid {nameof(aisiiId)} must be greater than zero");
        }

        /// <summary>
        /// Идентификатор записи справочника (ИЗМЕНЯЕТСЯ ОТ ВЕРСИИ К ВЕРСИИИ)
        /// </summary>
        public Guid AisiiId { get => _aisiiId; }
        /// <summary>
        /// Дата изменения записи
        /// </summary>
        public DateTime CreateDate { get => _createDate; }
        /// <summary>
        /// Признак актуальности записи справочника
        /// </summary>
        public bool IsActual { get => _isActual; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string? Name { get => _name; }
        /// <summary>
        /// Идентификатор записи справочника АИС МВ (НЕ МЕНЯЕТСЯ ОТ ВЕРСИИ К ВЕРСИИ)
        /// </summary>
        public Guid ObjId { get => _objid; }
        /// <summary>
        /// Синхронизация сущносит спавочника
        /// </summary>
        /// <param name="subscriberId">ID подпищика АИС ВМ</param>
        public abstract void EntitySync(long subscriberId);
        /// <summary>
        /// Синхронизация сущносит спавочника
        /// </summary>
        protected private abstract void EntitySyncAllSubscribers();
    }
}
