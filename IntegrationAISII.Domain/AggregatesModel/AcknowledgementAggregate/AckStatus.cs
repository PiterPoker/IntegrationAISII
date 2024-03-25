using IntegrationAISII.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.AggregatesModel.AcknowledgementAggregate
{
    public class AckStatus
        : Enumeration
    {
        public static AckStatus Received = new AckStatus(1, "Получено (для входящих уведомлений)".ToLowerInvariant());
        public static AckStatus SendingWaiting = new AckStatus(2, "Ожидание отправки".ToLowerInvariant());
        public static AckStatus Sent = new AckStatus(3, "Отправлено".ToLowerInvariant());

        public AckStatus(int id, string name)
            : base(id, name)
        {
        }

        public static IEnumerable<AckStatus> List() =>
            new[] { Received, SendingWaiting, Sent };

        public static AckStatus FromName(string name)
        {
            var ackStatuses = List()
                .SingleOrDefault(ack => string.Equals(ack.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (ackStatuses is null)
                throw new IntegrationAISIIDomainException($"Possible values for acknowledgement status: {string.Join(",", List().Select(ack => ack.Name))}");

            return ackStatuses;
        }

        public static AckStatus From(int id)
        {
            var ackStatuses = List()
                .SingleOrDefault(ack => ack.Id == id);

            if (ackStatuses is null)
                throw new IntegrationAISIIDomainException($"Possible values for acknowledgement status: {string.Join(",", List().Select(ack => ack.Name))}");

            return ackStatuses;
        }
    }
}
