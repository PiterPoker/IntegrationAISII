using IntegrationAISII.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.AggregatesModel.MailingTrackAggregate
{
    public class TrackingStatus
        : Enumeration
    {
        public static TrackingStatus Init = new TrackingStatus(1, "Инициализаци".ToLowerInvariant());
        public static TrackingStatus SendingWaiting = new TrackingStatus(2, "Ожидание отправки".ToLowerInvariant());
        public static TrackingStatus DeliveryWaiting = new TrackingStatus(3, "Ожидание подтверждения доставки".ToLowerInvariant());
        public static TrackingStatus SendingImpossible = new TrackingStatus(4, "Отправка невозможна".ToLowerInvariant());
        public static TrackingStatus DeliveryConfirmed = new TrackingStatus(5, "Доставка подтверждена".ToLowerInvariant());
        public static TrackingStatus RegistrationConfirmed = new TrackingStatus(6, "Регистрация подтверждена".ToLowerInvariant());
        public static TrackingStatus Received = new TrackingStatus(7, "Получено".ToLowerInvariant());
        public static TrackingStatus Refused = new TrackingStatus(8, "Отклонено".ToLowerInvariant());
        public static TrackingStatus Accepted = new TrackingStatus(9, "Принято без регистрации".ToLowerInvariant());
        public static TrackingStatus Registered = new TrackingStatus(10, "Зарегистрировано".ToLowerInvariant());
        public static TrackingStatus RefusedRegistration = new TrackingStatus(11, "Отказано в регистрации".ToLowerInvariant());
        public static TrackingStatus DeliveriedToAismvRouter = new TrackingStatus(12, "Доставлено в ядро АИС МВ".ToLowerInvariant());

        public TrackingStatus(int id, string name) 
            : base(id, name)
        {
        }

        public static IEnumerable<TrackingStatus> List() =>
            new[] { Init, SendingWaiting, DeliveryWaiting, SendingImpossible, DeliveryConfirmed, RegistrationConfirmed, Received, Refused, Accepted, Registered, RefusedRegistration, DeliveriedToAismvRouter };

        public static TrackingStatus FromName(string name)
        {
            var trackingStatuses = List()
                .SingleOrDefault(ts => string.Equals(ts.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (trackingStatuses is null)
                throw new IntegrationAISIIDomainException($"Possible values for tracking statuses: {string.Join(",", List().Select(st => st.Name))}");

            return trackingStatuses;
        }

        public static TrackingStatus From(int id)
        {
            var trackingStatuses = List()
                .SingleOrDefault(ts=>ts.Id == id);

            if(trackingStatuses is null)
                throw new IntegrationAISIIDomainException($"Possible values for tracking statuses: {string.Join(",", List().Select(st => st.Name))}");

            return trackingStatuses;
        }
    }
}
