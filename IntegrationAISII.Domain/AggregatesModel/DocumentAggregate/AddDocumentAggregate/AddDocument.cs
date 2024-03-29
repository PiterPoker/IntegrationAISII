using IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.DocumentAggregate;
using IntegrationAISII.Domain.AggregatesModel.MessageAggregate;
using IntegrationAISII.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.AddDocumentAggregate
{
    public class AddDocument : Entity, IAggregateRoot, IAddDocument
    {
        private List<Version> _versions;
        private int _addTypeId;
        private string _content;
        private Guid _addDocumentGuid;
        //private Message _message;

        public AddDocument()
        {

        }

        protected AddDocument(Guid addDocumentGuid, int addTypeId, string content)
            : this(addTypeId, content)
        {
            _addDocumentGuid = addDocumentGuid;
        }

        protected AddDocument(int addTypeId, string content)
        {
            _addTypeId = addTypeId;
            _content = content;
            _versions = new List<Version>();
        }

       /* public AddDocument(Message message, Guid addDocumentGuid, int addTypeId, string content)
            : this(addDocumentGuid, addTypeId, content)
        {
            this._message = message;
        }

        public AddDocument(Message message, int addTypeId, string content)
            : this(addTypeId, content)
        {
            this._message = message;
        }*/

        /// <summary>
        /// Список документов
        /// </summary>
        public IEnumerable<Version> Versions { get => _versions; }
        /// <summary>
        /// Регистрационный идентификатор приложения
        /// </summary>
        public virtual Guid AddDocumentGuid { get => _addDocumentGuid; }
        /// <summary>
        /// Тип приложения
        /// </summary>
        public virtual Guid AddDocumentType { get; }
        /// <summary>
        /// Тип приложения
        /// </summary>
        public TypeMaterial AddType { get => TypeMaterial.From(_addTypeId); }
        /// <summary>
        /// Текстовое описание содержимого группы
        /// </summary>
        public string Content { get => _content; }
        /// <summary>
        /// Основной документ
        /// </summary>
        public virtual Document MainDocument { get; }
        public virtual Message Message { get; }
        //public abstract void AddAdditionalDocument(string fileName, string noname, long? fileTypeId);
        public virtual Version AddAdditionalDocument(string fileName, string noname, string author, long? fileTypeId)
        {
            var existsAddDocument = this.Versions.SingleOrDefault(v => v.IsEquals(fileName, noname, fileTypeId));

            if (existsAddDocument is null)
            {
                var addDocument = new Version(this, fileName, noname, author, fileTypeId);
                SetVersion(addDocument);
                return addDocument;
            }
            return existsAddDocument;
        }

        public virtual void SetAddDocumentGuid(Guid addDocumentGuid) => this._addDocumentGuid = addDocumentGuid;
        public virtual void SetVersion(Version version) => this._versions.Add(version);

        public void SetAddType(int addTypeId)
        {
            this._addTypeId = addTypeId;
        }

        public void SetContent(string content)
        {
            this._content = content;
        }
    }
}
