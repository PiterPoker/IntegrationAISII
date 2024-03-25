using IntegrationAISII.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationAISII.Domain.AggregatesModel.CatalogAggregate.DocumentTypeAggregate;
using IntegrationAISII.Domain.AggregatesModel.MessageAggregate;
using System.Xml.Linq;
using System.Dynamic;
using IntegrationAISII.Domain.AggregatesModel.CatalogAggregate.OrganizationAggregate;

namespace IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.DocumentAggregate
{
    public abstract class Document : Entity, IAggregateRoot, IDocument
    {
        private string _idNumber;
        private long _documentTypeId;
        private bool _isConfident;
        private string _regNumber;
        private int _pages;
        private DateTime _regDate;
        private Guid _documentGuid;
        private string _title;
        private long _versionId;
        private Message _message;

        protected Document(Message message, string idNumber, bool isConfident, string regNumber, int pages, DateTime regDate, Guid documentGuid, string title, long documentTypeId)
            : this(message, idNumber, isConfident, regNumber, pages, regDate, title, documentTypeId)
        {
            this.SetDocumentGuid(documentGuid);
        }

        protected Document(Message message, string idNumber, bool isConfident, string regNumber, int pages, DateTime regDate, string title, long documentTypeId)
        {
            this._message = message;
            this.SetIdNumber(idNumber);
            this.SetIsConfident(isConfident);
            this.SetRegNumber(regNumber);
            this.SetPages(pages);
            this.SetRegDate(regDate);
            this.SetTitle(title);
            this.SetDocumentTypeId(documentTypeId);
        }

        public void SetDocumentTypeId(long documentTypeId)
        {
            _documentTypeId = documentTypeId > 0 ? documentTypeId : throw new IntegrationAISIIDomainException($"Invalid {nameof(documentTypeId)} must not be less zero");
        }

        private void SetTitle(string title)
        {
            _title = title;
        }

        public void SetDocumentGuid(Guid documentGuid)
        {
            _documentGuid = documentGuid;
        }

        public void SetRegDate(DateTime regDate)
        {
            _regDate = regDate;
        }

        public void SetPages(int pages)
        {
            this._pages = pages;
        }

        public void SetIsConfident(bool isConfident)
        {
            this._isConfident = isConfident;
        }

        /// <summary>
        /// Идентификатор вида документа
        /// </summary>
        public DocumentType DocumentType
        {
            get;
            private set;
        }
        /// <summary>
        /// Уникальный служебный идентификационный номер документа в передающей системе
        /// </summary>
        public string IdNumber
        {
            get => _idNumber;
        }
        /// <summary>
        /// Признак ограниченного доступа к документу
        /// </summary>
        public bool IsConfident { get => _isConfident; }
        /// <summary>
        /// Общее количество листов только  основного документа либо основного документа с приложениями включительно
        /// </summary>
        public int Pages { get => _pages; }
        /// <summary>
        /// Дата регистрации документа/задачи в системе отправителя
        /// </summary>
        public DateTime RegDate { get => _regDate; }
        /// <summary>
        /// Регистрационный идентификатор документа
        /// </summary>
        public virtual Guid DocumentGuid { get => _documentGuid; }
        /// <summary>
        /// Регистрационный идентификатор вида документа
        /// </summary>
        public abstract Guid DocumentKind { get; }
        /// <summary>
        /// Сообщение документа
        /// </summary>
        public virtual Message Message { get => _message; }
        /// <summary>
        /// Родительское сообщение
        /// </summary>
        public abstract Message ParentMessage { get; }
        /// <summary>
        /// Основное сообщение
        /// </summary>
        public abstract Message MainMessage { get; }
        /// <summary>
        /// Рег. номер документа/задачи в системе отправителя
        /// </summary>
        public string RegNumber
        {
            get => _regNumber;
        }

        /// <summary>
        /// Заголовок текста (краткое содержание)
        /// </summary>
        public string Title { get => _title; }
        /// <summary>
        /// Версия документа
        /// </summary>
        public Version Version { get; private set; }

        public virtual void AddVersion(string fileName, string noname, string author, long? fileTypeId)
        {
            if (Version is null)
            {
                var vesrsion = new Version(this, fileName, noname, author, fileTypeId);
                Version = vesrsion;
            }
            else
            {
                Version.SetFileName(fileName);
                Version.SetNoname(noname);
                Version.SetFileTypeId(fileTypeId);
            }
        }

        public virtual void AddSignatureForVersion(string signer, DateTime signTime, byte[] value)
        {
            if (Version is null)
                throw new ArgumentNullException(nameof(Version));

            Version.AddSignature(signer, signTime, value);
        }

        public void SetIdNumber(string idNumber)
        {
            _idNumber = idNumber;
        }
        public void SetRegNumber(string regNumber)
        {
            _regNumber = !string.IsNullOrWhiteSpace(regNumber) ? regNumber : throw new IntegrationAISIIDomainException($"Invalid {nameof(regNumber)} must not be empty");
        }
    }
}
