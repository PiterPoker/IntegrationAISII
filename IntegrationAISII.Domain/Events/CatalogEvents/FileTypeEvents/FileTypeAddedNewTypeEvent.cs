using IntegrationAISII.Domain.AggregatesModel.CatalogAggregate.FileTypeAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.Events.CatalogEvents.FileTypeEvents
{
    public class FileTypeAddedNewTypeEvent
        : INotification
    {
        public FileType FileType { get; private set; }
        public FileTypeAddedNewTypeEvent(FileType fileType)
        {
            this.FileType = fileType;
        }
    }
}
