using IntegrationAISII.Domain.AggregatesModel.CatalogAggregate.OrganizationAggregate;
using IntegrationAISII.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.AggregatesModel.SubscriberAggregate
{
    public class Subscriber : Entity, IAggregateRoot
    {
        private string _email;
        private string _login;
        private long? _organizationId;
        private Organization _organization;
        private string _password;
        private Guid _subscriberGuid;

        public Subscriber(string email, string login, Organization organization, string password)
        {
            this.SetEmail(email);
            this.SetLogin(login);
            this.SetPassword(password);
            _organization = organization ?? throw new ArgumentNullException(nameof(organization));
            _subscriberGuid = Guid.NewGuid();
        }

        /// <summary>
        /// Наименование технологического почтового ящика абонента в транспортной системе СМДО
        /// </summary>
        public string Email { get => _email; }
        /// <summary>
        /// Логин к технологическому почтовому ящику абонента
        /// </summary>
        public string Login { get => _login; }
        /// <summary>
        /// Запись справочника «Организации», соответствующая абоненту
        /// </summary>
        public Organization Organization { get => _organization; }
        /// <summary>
        /// Пароль к технологическому почтовому ящику абонента
        /// </summary>
        public string Password { get => _password; }
        /// <summary>
        /// Регистрационный идентификатор абонента СМДО-коннектора
        /// </summary>
        public Guid SubscriberGuid { get => _subscriberGuid; }

        public void SetLogin(string login) => _login = login;
        public void SetEmail(string email) => _email = email ?? throw new ArgumentNullException(nameof(email));
        public void SetPassword(string password) => _password = password ?? throw new ArgumentNullException(nameof(password));
        public bool IsActual() => _organization?.IsActual ?? throw new ArgumentNullException(nameof(_organization));
    }
}
