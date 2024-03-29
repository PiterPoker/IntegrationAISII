using IntegrationAISII.Domain.AggregatesModel.MailingTrackAggregate;
using IntegrationAISII.Domain.AggregatesModel.MessageAggregate;
using IntegrationAISII.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.AggregatesModel.AcknowledgementAggregate
{
    public class Acknowledgement : Entity, IAggregateRoot, IAcknowledgement
    {
        private int _ackTypeId;
        public int _statusId;
        private DateTime _createDate;
        private Guid _ackMessageGuid;
        private bool _isLocked;
        private string _subject;
        private Guid _packageId;
        private string _errorText;
        private int _errorCode;

        protected Acknowledgement(Guid ackMessageGuid, string subject, string errorText, int errorCode)
            : this(subject, errorText, errorCode)
        {
            _ackMessageGuid = ackMessageGuid;
        }

        protected Acknowledgement(string subject, string errorText, int errorCode)
            : this()
        {
            _subject = subject ?? throw new ArgumentNullException(nameof(subject));
            _errorText = errorText ?? throw new ArgumentNullException(nameof(errorText));
            _errorCode = errorCode;
        }

        protected Acknowledgement()
        {
            _statusId = AckStatus.SendingWaiting.Id;
            _createDate = DateTime.UtcNow;
            _isLocked = false;
        }
        /// <summary>
        /// Тип уведомления
        /// </summary>
        public virtual Guid AcknowledgementType { get; }
        /// <summary>
        /// Сообщение уведомление
        /// </summary>
        public virtual Message Message { get; }
        /// <summary>
        /// Сообщение по которому создается уведомление
        /// </summary>
        public virtual Message ResponseTo { get; }
        /// <summary>
        /// Тип уведомления
        /// </summary>
        public NotificationType AckType { get => NotificationType.From(_ackTypeId); }
        /// <summary>
        /// Текст уведомления
        /// </summary>
        public string ErrorText { get => _errorText; }
        // smallint -> Int16
        /// <summary>
        /// Код ошибки
        /// </summary>
        public int ErrorCode { get => _errorCode; }
        // smallint -> Int16
        /// <summary>
        /// Состояние уведомления
        /// </summary>
        public AckStatus Status { get => AckStatus.From(_statusId); }
        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreateDate { get => _createDate; }
        /// <summary>
        /// Идентификатор уведомления в СМДО
        /// </summary>
        public virtual Guid AckMessageGuid { get => _ackMessageGuid; }
        /// <summary>
        /// Признак блокировки сообщения
        /// </summary>
        public bool IsLocked { get => _isLocked; }
        /// <summary>
        /// Тема уведомления
        /// </summary>
        public string Subject
        {
            get => _subject;
        }
        public virtual IEnumerable<MailingTrack> MailingTracks { get; }
        /// <summary>
        /// ID пакета отправки в АИС МВ
        /// </summary>
        public virtual Guid PackageId { get => _packageId; }

        public virtual void SetPackageId(Guid packageId)
        {
            _packageId = packageId;
        }

        public virtual void SetIsLocked(bool isLocked)
        {
            _isLocked = isLocked;
        }

        public void SetAckMessageGuid(Guid ackMessageGuid)
        {
            _ackMessageGuid = ackMessageGuid;
        }

        public void SetSubject(string subject)
        {
            _subject = subject;
        }

        public void SetErrorText(string errorText)
        {
            _errorText = errorText;
        }

        public void SetErrorCode(int errorCode)
        {
            _errorCode = errorCode;
        }

    }
}
