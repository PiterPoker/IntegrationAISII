using IntegrationAISII.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.AggregatesModel.AcknowledgementAggregate
{
    public class NotificationType
        : Enumeration
    {
        public static NotificationType DeliveryAndReception = new NotificationType(1, "Уведомления о доставке и приеме сообщения".ToLowerInvariant());
        public static NotificationType RegisteringDocumentInDMS = new NotificationType(2, "Уведомления о регистрации документа в системе управления документами получателя".ToLowerInvariant());
        public static NotificationType Reserved = new NotificationType(3, "ЗАРЕЗЕРВИРОВАНО (недопустимо для использования разработчиками ВСЭД)".ToLowerInvariant());
        public static NotificationType CustomNotification = new NotificationType(4, "Пользовательские уведомления".ToLowerInvariant());

        public NotificationType(int id, string name)
            : base(id, name)
        {
        }

        public static IEnumerable<NotificationType> List() =>
            new[] { DeliveryAndReception, RegisteringDocumentInDMS, Reserved, CustomNotification };

        public static NotificationType FromName(string name)
        {
            var notificationType = List()
                .SingleOrDefault(nt => string.Equals(nt.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (notificationType is null)
                throw new IntegrationAISIIDomainException($"Possible values for notification type: {string.Join(",", List().Select(nt => nt.Name))}");

            return notificationType;
        }

        public static NotificationType From(int id)
        {
            var notificationType = List()
                .SingleOrDefault(nt => nt.Id == id);

            if (notificationType is null)
                throw new IntegrationAISIIDomainException($"Possible values for notification type: {string.Join(",", List().Select(nt => nt.Name))}");

            return notificationType;
        }
    }
}
