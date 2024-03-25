using IntegrationAISII.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationAISII.Domain.AggregatesModel.CatalogAggregate.FileTypeAggregate;
using IntegrationAISII.Domain.AggregatesModel.CatalogAggregate.DocumentTypeAggregate;
using IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.DocumentAggregate;
using IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.AddDocumentAggregate;

namespace IntegrationAISII.Domain.AggregatesModel.DocumentAggregate
{
    public class Version : Entity, IVersion
    {
        private string _fileName;
        private string _noname;
        private string _author;
        private long? _fileTypeId;
        private FileType _fileType;
        private Document _document;
        private AddDocument _addDocument;
        private List<Signature> _signatures;
        /// <summary>
        /// Полное наименование исходного файла, включая расширение
        /// </summary>
        public string FileName
        {
            get => _fileName;
        }
        /// <summary>
        /// Псевдоним документа в коннекторе АИС МВ
        /// </summary>
        public string Noname
        {
            get => _noname;
        }
        /// <summary>
        /// Автор документа АИС МВ
        /// </summary>
        public string Author
        {
            get => _author;
        }
        /// <summary>
        /// Расширение документа
        /// </summary>
        public FileType FileType
        {
            get;
        }
        /// <summary>
        /// Список подписей
        /// </summary>
        public IEnumerable<Signature> Signatures { get => _signatures; }
        public Version(Document document,string fileName, string noname, string author, long? fileTypeId)
            : this(fileName, noname, author, fileTypeId)
        {            
            _document = document is not null ? document : throw new ArgumentNullException(nameof(document));
        }
        public Version(AddDocument addDocument,string fileName, string noname, string author, long? fileTypeId)
            : this(fileName, noname, author, fileTypeId)
        {            
            _addDocument = addDocument is not null ? addDocument : throw new ArgumentNullException(nameof(addDocument));
        }
        protected Version(string fileName, string noname, string author, long? fileTypeId)
        {            
            this.SetFileName(fileName);
            this.SetNoname(noname);
            this.SetAuthor(author);
            this.SetFileTypeId(fileTypeId);
            _signatures = new List<Signature>();
        }

        public void AddSignature(string signer, DateTime signTime, byte[] value)
        {
            if (_signatures.Count > 20)
                throw new IntegrationAISIIDomainException($"Maximum number of {nameof(_signatures)} execeeded. Maximum count equals 20");

            var existsSignature = this._signatures.SingleOrDefault(s => s.IsEquals(signer, signTime, value));

            if (existsSignature is null)
            {
                var signature = new Signature(this, signer, signTime, value);

                this._signatures.Add(signature);
            }
        }

        public void SetFileName(string fileName)
        {
            _fileName = !string.IsNullOrWhiteSpace(fileName) ? fileName : throw new IntegrationAISIIDomainException($"Invalid {nameof(fileName)} must not be empty");
        }

        public void SetNoname(string noname)
        {
            _noname = !string.IsNullOrWhiteSpace(noname) ? noname : throw new IntegrationAISIIDomainException($"Invalid {nameof(noname)} must not be empty");
        }

        public void SetAuthor(string author)
        {
            _author = !string.IsNullOrWhiteSpace(author) ? author : throw new IntegrationAISIIDomainException($"Invalid {nameof(author)} must not be empty");
        }

        public void SetFileTypeId(long? fileTypeId)
        {
            _fileTypeId = fileTypeId.HasValue ? fileTypeId.Value : throw new IntegrationAISIIDomainException($"Invalid {nameof(fileTypeId)} must not be empty");
        }

        public bool IsEquals(string fileName, string noname, long? fileTypeId)
        {
            var isSimilarFileName = string.Equals(this._fileName, fileName);
            var isSimilarNoname = string.Equals(this._noname, noname);
            var isSimilarFileTypeId = _fileTypeId == fileTypeId;
            return (isSimilarFileName && isSimilarNoname && isSimilarFileTypeId);
        }
    }
}
