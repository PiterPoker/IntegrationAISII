using IntegrationAISII.Domain.AggregatesModel.AcknowledgementAggregate;
using IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.AddDocumentAggregate;
using IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.DocumentAggregate;
using IntegrationAISII.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IntegrationAISII.Domain.AggregatesModel.MessageAggregate
{
    public abstract class Message : Entity, IAggregateRoot, IMessage
    {
        private DateTime _createDate;
        private Guid _messageGuid;
        private Guid _packageId;
        private bool _isLocked;
        private string _subject;
        private long? _subscriberId;

        /// <summary>
        /// Дата создания сообщения
        /// </summary>
        public DateTime CreateDate { get => _createDate; }
        /// <summary>
        /// Тип сообщеия
        /// </summary>
        public abstract Guid MessageType { get; }
        /// <summary>
        /// Идентификатор сообщения в АИС МВ
        /// </summary>
        public virtual Guid MessageGuid { get => _messageGuid; }
        /// <summary>
        /// ID пакета отправки в АИС МВ
        /// </summary>
        public Guid PackageId { get => _packageId; }
        /// <summary>
        /// Признак блокировки сообщения
        /// </summary>
        public bool IsLocked { get => _isLocked; }
        /// <summary>
        /// Тема сообщения
        /// </summary>
        public string Subject { get => _subject; }
        /// <summary>
        /// Идентификатор абонента-отправителя исх. сообщения/получателя вх. сообщения
        /// </summary>
        public long? SubscriberId { get => _subscriberId; }
        public abstract AddDocument AddDocument { get; }
        public abstract Document Document { get; }
        //public Acknowledgement Acknowledgement { get; }

        protected Message(Guid packageId,
                        string subject,
                        long? subscriberId)
            : this(subject,
                  subscriberId)
        {
            _packageId = packageId;
        }

        protected Message(string subject,
                        long? subscriberId)
        {
            _createDate = DateTime.UtcNow;
            _isLocked = false;
            _subject = subject;
            _subscriberId = subscriberId;
        }

        protected Message(IMessage message)
            : this(message.PackageId,
                message.Subject,
                message.SubscriberId)
        {
        }

        public void SetPackageId(Guid packageId)
        {
            _packageId = packageId;
        }
    }
}
