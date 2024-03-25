using IntegrationAISII.Domain.AggregatesModel.MailingTrackAggregate;
using IntegrationAISII.Domain.AggregatesModel.MessageAggregate;

namespace IntegrationAISII.Domain.AggregatesModel.AcknowledgementAggregate
{
    public interface IAcknowledgement
    {
        /// <summary>
        /// Идентификатор уведомления в СМДО
        /// </summary>
        Guid AckMessageGuid { get; }
        /// <summary>
        /// Тип уведомления
        /// </summary>
        Guid AcknowledgementType { get; }
        /// <summary>
        /// Тип уведомления
        /// </summary>
        NotificationType AckType { get; }
        /// <summary>
        /// Дата создания
        /// </summary>
        DateTime CreateDate { get; }
        /// <summary>
        /// Код ошибки
        /// </summary>
        int ErrorCode { get; }
        /// <summary>
        /// Текст уведомления
        /// </summary>
        string ErrorText { get; }
        /// <summary>
        /// Признак блокировки сообщения
        /// </summary>
        bool IsLocked { get; }
        /// <summary>
        /// Сообщение по которому создается уведомление
        /// </summary>
        Message Message { get; }
        /// <summary>
        /// ID пакета отправки в АИС МВ
        /// </summary>
        Guid PackageId { get; }
        // smallint -> Int16
        /// <summary>
        /// Состояние уведомления
        /// </summary>
        AckStatus Status { get; }
        /// <summary>
        /// Тема уведомления
        /// </summary>
        string Subject { get; }
    }
}