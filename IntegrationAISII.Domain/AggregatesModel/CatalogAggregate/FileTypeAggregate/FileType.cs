using IntegrationAISII.Domain.Events.CatalogEvents.FileTypeEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.AggregatesModel.CatalogAggregate.FileTypeAggregate
{
    public class FileType : Catalog, IFileType
    {
        private string _extension;
        private List<FileTypeSync> _fileTypeSyncs;

        /// <summary>
        /// Расширение
        /// </summary>
        public string Extension { get => _extension; }
        public IEnumerable<FileTypeSync> FileTypeSyncs { get => _fileTypeSyncs; }
        public FileType(Guid objid, DateTime createDate, string name, bool isActual, Guid aisiiId, string extension)
            : base(objid, createDate, name, isActual, aisiiId)
        {
            this._extension = !string.IsNullOrWhiteSpace(extension) ? extension : throw new IntegrationAISIIDomainException($"Invalid {nameof(extension)} must not be empty");
            this._fileTypeSyncs = new List<FileTypeSync>();

            this.EntitySyncAllSubscribers();
        }
        public FileType(IFileType fileType) 
            : this(fileType.ObjId, fileType.CreateDate, fileType.Name, fileType.IsActual, fileType.AisiiId, fileType.Extension)
        {
        }

        public override void EntitySync(long subscriberId)
        {
            if (subscriberId <= 0)
                throw new IntegrationAISIIDomainException($"Invalid {nameof(subscriberId)}");

            var fileTypeSync = _fileTypeSyncs.SingleOrDefault(t => t.Id == subscriberId);

            if (fileTypeSync is null)
            {
                throw new IntegrationAISIIDomainException($"Invalid {nameof(fileTypeSync)} not found");
            }

            fileTypeSync.SetIsSync(true);
        }

        private protected override void EntitySyncAllSubscribers()
        {
            this.AddDomainEvent(new FileTypeAddedNewTypeEvent(this));
        }

        public bool CompareByExtension(string extension) => string.Equals(this._extension, extension);
    }
}
