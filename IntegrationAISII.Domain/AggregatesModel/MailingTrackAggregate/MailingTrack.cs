using IntegrationAISII.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationAISII.Domain.AggregatesModel.AcknowledgementAggregate;
using IntegrationAISII.Domain.AggregatesModel.MessageAggregate;

namespace IntegrationAISII.Domain.AggregatesModel.MailingTrackAggregate
{
    public class MailingTrack : Entity, IAggregateRoot, IMailingTrack
    {
        /// <summary>
        /// Дата трека
        /// </summary>
        public DateTime CreateDate { get => _createDate; }
        public virtual Acknowledgement Acknowledgement { get; }
        //public virtual Message Message { get; }
        /// <summary>
        /// Описание трека сообщения
        /// </summary>
        public string Description { get => _description; }
        /// <summary>
        /// Признак непрочитанного трека
        /// </summary>
        public bool IsUnread { get => _isUnread; }
        // smallint -> Int16
        private int _statusId;
        private DateTime _createDate;
        private string _description;
        private bool _isUnread;

        protected MailingTrack()
        {
            this.ChangeStatus(TrackingStatus.Init);
            this._isUnread = true;
        }

        protected MailingTrack(DateTime createDate) : this()
        {
            _createDate = createDate;
        }

        /// <summary>
        /// Значение трека
        /// </summary>
        public TrackingStatus Value { get => TrackingStatus.From(_statusId); }

        public virtual Guid TypeGuid { get; }

        public void ChangeStatus(TrackingStatus status)
        {
            this._statusId = status.Id;
            this._description = status.Name;
        }

        public virtual void SetIsUnread(bool value)
        {
            this._isUnread = value;
        }
    }
}
