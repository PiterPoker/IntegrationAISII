using IntegrationAISII.Domain.AggregatesModel.CatalogAggregate.OrganizationAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.Events.CatalogEvents.OrganizationEvents
{
    public class OrganizationAddedNewTypeEvent
        : INotification
    {
        public Organization Organization { get; private set; }
        public OrganizationAddedNewTypeEvent(Organization organization)
        {
            Organization = organization;
        }
    }
}
