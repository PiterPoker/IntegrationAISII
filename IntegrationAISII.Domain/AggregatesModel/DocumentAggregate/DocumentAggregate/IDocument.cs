using IntegrationAISII.Domain.AggregatesModel.CatalogAggregate.DocumentTypeAggregate;
using IntegrationAISII.Domain.AggregatesModel.MessageAggregate;

namespace IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.DocumentAggregate
{
    public interface IDocument
    {
        long Id { get; }
        /// <summary>
        /// Регистрационный идентификатор документа
        /// </summary>
        Guid DocumentGuid { get; }
        /// <summary>
        /// Регистрационный идентификатор вида документа
        /// </summary>
        Guid DocumentKind { get; }
        /// <summary>
        /// Идентификатор вида документа
        /// </summary>
        DocumentType DocumentType { get; }
        /// <summary>
        /// Уникальный служебный идентификационный номер документа в передающей системе
        /// </summary>
        string IdNumber { get; }
        /// <summary>
        /// Признак ограниченного доступа к документу
        /// </summary>
        bool IsConfident { get; }
        /// <summary>
        /// Общее количество листов только  основного документа либо основного документа с приложениями включительно
        /// </summary>
        int Pages { get; }
        /// <summary>
        /// Дата регистрации документа/задачи в системе отправителя
        /// </summary>
        DateTime RegDate { get; }
        /// <summary>
        /// Рег. номер документа/задачи в системе отправителя
        /// </summary>
        string RegNumber { get; }
        /// <summary>
        /// Заголовок текста (краткое содержание)
        /// </summary>
        string Title { get; }
        /// <summary>
        /// Версия документа
        /// </summary>
        Version Version { get; }
        /// <summary>
        /// Сообщение документа
        /// </summary>
        Message Message { get; }
        /// <summary>
        /// Основное сообщение
        /// </summary>
        Message MainMessage { get; }
        /// <summary>
        /// Родительское сообщение
        /// </summary>
        Message ParentMessage { get; }
    }
}