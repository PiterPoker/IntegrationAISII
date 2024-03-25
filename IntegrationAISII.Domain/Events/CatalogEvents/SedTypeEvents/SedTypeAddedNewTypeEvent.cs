using IntegrationAISII.Domain.AggregatesModel.CatalogAggregate.SedTypeAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.Events.CatalogEvents.SedTypeEvents
{
    public class SedTypeAddedNewTypeEvent
        : INotification
    {
        public SedType SedType { get; private set; }

        public SedTypeAddedNewTypeEvent(SedType sedType)
        {
            SedType = sedType;
        }
    }
}
