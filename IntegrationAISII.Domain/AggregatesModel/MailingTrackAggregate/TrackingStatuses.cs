using IntegrationAISII.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.AggregatesModel.MailingTrackAggregate
{
    public class TrackingStatuses
        : Enumeration
    {
        public static TrackingStatuses Init = new TrackingStatuses(1, "Инициализаци".ToLowerInvariant());
        public static TrackingStatuses SendingWaiting = new TrackingStatuses(2, "Ожидание отправки".ToLowerInvariant());
        public static TrackingStatuses DeliveryWaiting = new TrackingStatuses(3, "Ожидание подтверждения доставки".ToLowerInvariant());
        public static TrackingStatuses SendingImpossible = new TrackingStatuses(4, "Отправка невозможна".ToLowerInvariant());
        public static TrackingStatuses DeliveryConfirmed = new TrackingStatuses(5, "Доставка подтверждена".ToLowerInvariant());
        public static TrackingStatuses RegistrationConfirmed = new TrackingStatuses(6, "Регистрация подтверждена".ToLowerInvariant());
        public static TrackingStatuses Received = new TrackingStatuses(7, "Получено".ToLowerInvariant());
        public static TrackingStatuses Refused = new TrackingStatuses(8, "Отклонено".ToLowerInvariant());
        public static TrackingStatuses Accepted = new TrackingStatuses(9, "Принято без регистрации".ToLowerInvariant());
        public static TrackingStatuses Registered = new TrackingStatuses(10, "Зарегистрировано".ToLowerInvariant());
        public static TrackingStatuses RefusedRegistration = new TrackingStatuses(11, "Отказано в регистрации".ToLowerInvariant());
        public static TrackingStatuses DeliveriedToAismvRouter = new TrackingStatuses(12, "Доставлено в ядро АИС МВ".ToLowerInvariant());

        public TrackingStatuses(int id, string name) 
            : base(id, name)
        {
        }

        public static IEnumerable<TrackingStatuses> List() =>
            new[] { Init, SendingWaiting, DeliveryWaiting, SendingImpossible, DeliveryConfirmed, RegistrationConfirmed, Received, Refused, Accepted, Registered, RefusedRegistration, DeliveriedToAismvRouter };

        public static TrackingStatuses FromName(string name)
        {
            var trackingStatuses = List()
                .SingleOrDefault(ts => string.Equals(ts.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (trackingStatuses is null)
                throw new IntegrationAISIIDomainException($"Possible values for tracking statuses: {string.Join(",", List().Select(st => st.Name))}");

            return trackingStatuses;
        }

        public static TrackingStatuses From(int id)
        {
            var trackingStatuses = List()
                .SingleOrDefault(ts=>ts.Id == id);

            if(trackingStatuses is null)
                throw new IntegrationAISIIDomainException($"Possible values for tracking statuses: {string.Join(",", List().Select(st => st.Name))}");

            return trackingStatuses;
        }
    }
}
