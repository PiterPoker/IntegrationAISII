using IntegrationAISII.Domain.AggregatesModel.CatalogAggregate.SedTypeAggregate;
using IntegrationAISII.Domain.Events.CatalogEvents.OrganizationEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.AggregatesModel.CatalogAggregate.OrganizationAggregate
{
    public class Organization : Catalog, IOrganization
    {
        private string _smdoCode;
        private string _unp;
        private string _soato;
        private string _email;
        private string _shortName;
        private long _edmsTypeId;
        private SedType _edmsType;
        private string _street;
        private string _corpus;
        private string _abonentBox;
        private string _phone;
        private string _fax;
        private string _home;
        private string _postIndex;
        private List<OrganizationSync> _organizationSyncs;

        /// <summary>
        /// Идентификатор организации в СМДО
        /// </summary>
        public string SmdoCode
        {
            get => _smdoCode;
        }
        /// <summary>
        /// УНП
        /// </summary>
        public string Unp
        {
            get => _unp;
        }
        /// <summary>
        /// Сокращенное наименование
        /// </summary>
        public string ShortName { get => _shortName; }
        /// <summary>
        /// Идентификатор ведомственной СЭД
        /// </summary>
        public SedType EdmsType { get => _edmsType; }
        /// <summary>
        /// Код СОАТО
        /// </summary>
        public string Soato
        {
            get => _soato;
        }
        /// <summary>
        /// Улица
        /// </summary>
        public string Street { get => _street; }
        /// <summary>
        /// Номер дома
        /// </summary>
        public string Home
        {
            get => _home;
        }
        /// <summary>
        /// Номер корпуса
        /// </summary>
        public string Corpus
        {
            get => _corpus;
        }
        /// <summary>
        /// Почтовый индекс
        /// </summary>
        public string PostIndex
        {
            get => _postIndex;
        }
        /// <summary>
        /// Абонентский ящик
        /// </summary>
        public string AbonentBox
        {
            get => _abonentBox;
        }
        /// <summary>
        /// Телефон
        /// </summary>
        public string Phone
        {
            get => _phone;
        }
        /// <summary>
        /// Факс
        /// </summary>
        public string Fax
        {
            get => _fax;
        }

        /// <summary>
        /// Адрес электронной почты
        /// </summary>
        public string Email
        {
            get => _email;
        }
        public IEnumerable<OrganizationSync> OrganizationSyncs { get => _organizationSyncs; }
        public Organization(Guid objid,
                            DateTime createDate,
                            string name,
                            bool isActual,
                            Guid aisiiId,
                            string smdoCode,
                            string unp,
                            string soato,
                            string mail,
                            string shortName,
                            long edmsTypeId,
                            string street,
                            string corpus,
                            string abonentBox,
                            string phone,
                            string fax, 
                            string home, 
                            string postIndex)
            : base(objid,
                   createDate,
                   name,
                   isActual,
                   aisiiId)
        {
            _smdoCode = !string.IsNullOrWhiteSpace(smdoCode) ? smdoCode : throw new IntegrationAISIIDomainException($"Invalid {nameof(smdoCode)} must not be empty");
            _unp = !string.IsNullOrWhiteSpace(unp) ? unp : throw new IntegrationAISIIDomainException($"Invalid {nameof(unp)} must not be empty");
            _soato = !string.IsNullOrWhiteSpace(soato) ? soato : throw new IntegrationAISIIDomainException($"Invalid {nameof(soato)} must not be empty");
            _email = !string.IsNullOrWhiteSpace(mail) ? mail : throw new IntegrationAISIIDomainException($"Invalid {nameof(mail)} must not be empty");
            _shortName = !string.IsNullOrWhiteSpace(shortName) ? shortName : throw new IntegrationAISIIDomainException($"Invalid {nameof(shortName)} must not be empty");
            _edmsTypeId = edmsTypeId > 0 ? edmsTypeId : throw new IntegrationAISIIDomainException($"Invalid {nameof(edmsTypeId)}");
            _street = !string.IsNullOrWhiteSpace(street) ? street : throw new IntegrationAISIIDomainException($"Invalid {nameof(street)} must not be empty");
            _corpus = !string.IsNullOrWhiteSpace(corpus) ? corpus : throw new IntegrationAISIIDomainException($"Invalid {nameof(corpus)} must not be empty");
            _abonentBox = !string.IsNullOrWhiteSpace(abonentBox) ? abonentBox : throw new IntegrationAISIIDomainException($"Invalid {nameof(abonentBox)} must not be empty");
            _phone = !string.IsNullOrWhiteSpace(phone) ? phone : throw new IntegrationAISIIDomainException($"Invalid {nameof(phone)} must not be empty");
            _fax = !string.IsNullOrWhiteSpace(fax) ? fax : throw new IntegrationAISIIDomainException($"Invalid {nameof(fax)} must not be empty");
            _home = !string.IsNullOrWhiteSpace(home) ? home : throw new IntegrationAISIIDomainException($"Invalid {nameof(home)} must not be empty");
            _postIndex = !string.IsNullOrWhiteSpace(postIndex) ? postIndex : throw new IntegrationAISIIDomainException($"Invalid {nameof(postIndex)} must not be empty");
            _organizationSyncs = new List<OrganizationSync>();

            EntitySyncAllSubscribers();
        }

        public Organization(IOrganization organization)
            : this(organization.ObjId, organization.CreateDate, organization.Name, organization.IsActual, organization.AisiiId, organization.SmdoCode, organization.Unp, organization.Soato, organization.Email, organization.ShortName, organization.EdmsType.Id, organization.Street, organization.Corpus, organization.AbonentBox, organization.Phone, organization.Fax, organization.Home, organization.PostIndex)
        {
        }

        public Organization()
            : base()
        {
        }

        public override void EntitySync(long subscriberId)
        {
            if (subscriberId <= 0)
                throw new IntegrationAISIIDomainException($"Invalid {nameof(subscriberId)}");

            var documentTypeSync = _organizationSyncs.SingleOrDefault(t => t.Id == subscriberId);

            if (documentTypeSync is null)
            {
                throw new IntegrationAISIIDomainException($"Invalid {nameof(documentTypeSync)} not found");
            }

            documentTypeSync.SetIsSync(true);
        }

        private protected override void EntitySyncAllSubscribers()
        {
            this.AddDomainEvent(new OrganizationAddedNewTypeEvent(this));
        }
    }
}
