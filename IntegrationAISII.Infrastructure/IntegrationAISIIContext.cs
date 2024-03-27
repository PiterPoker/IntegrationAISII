using IntegrationAISII.Domain.AggregatesModel.AcknowledgementAggregate;
using IntegrationAISII.Domain.AggregatesModel.AcknowledgementAggregate.IncomingAcknowledgementAggregate;
using IntegrationAISII.Domain.AggregatesModel.AcknowledgementAggregate.OutgoingAcknowledgementAggregate;
using IntegrationAISII.Domain.AggregatesModel.CatalogAggregate.DocumentTypeAggregate;
using IntegrationAISII.Domain.AggregatesModel.CatalogAggregate.FileTypeAggregate;
using IntegrationAISII.Domain.AggregatesModel.CatalogAggregate.OrganizationAggregate;
using IntegrationAISII.Domain.AggregatesModel.CatalogAggregate.SedTypeAggregate;
using DocumentAggregate = IntegrationAISII.Domain.AggregatesModel.DocumentAggregate;
using IntegrationAISII.Domain.SeedWork;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.AddDocumentAggregate;
using IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.AddDocumentAggregate.IncomingAddDocumentAggregate;
using IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.AddDocumentAggregate.OutgoingAddDocumentAggregate;
using IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.DocumentAggregate.IncomingDocumentAggregate;
using IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.DocumentAggregate.OutgoingDocumentAggregate;
using IntegrationAISII.Domain.AggregatesModel.MailingTrackAggregate;
using IntegrationAISII.Domain.AggregatesModel.MailingTrackAggregate.IncomingMailingTrackAggregate;
using IntegrationAISII.Domain.AggregatesModel.MailingTrackAggregate.OutgoingMailingTrackAggregate;
using IntegrationAISII.Domain.AggregatesModel.MessageAggregate.IncomingMessageAggregate;
using IntegrationAISII.Domain.AggregatesModel.MessageAggregate.OutgoingMessageAggregate;
using IntegrationAISII.Domain.AggregatesModel.SubscriberAggregate;
using IntegrationAISII.Infrastructure.EntityConfigurations;

namespace IntegrationAISII.Infrastructure
{
    public class IntegrationAISIIContext : DbContext, IUnitOfWork
    {
        public const string DEFAULT_SCHEMA = "aisii";
        private readonly IMediator _mediator;

        public DbSet<IncomingAcknowledgement> IncomingAcknowledgements { get; set; }
        public DbSet<OutgoingAcknowledgement> OutgoingAcknowledgements { get; set; }
        public DbSet<AckStatus> AckStatuses { get; set; }
        public DbSet<NotificationType> NotificationTypes { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<DocumentTypeSync> DocumentTypeSyncs { get; set; }
        public DbSet<FileType> FileTypes { get; set; }
        public DbSet<FileTypeSync> FileTypeSyncs { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<OrganizationSync> OrganizationSyncs { get; set; }
        public DbSet<SedType> SedTypes { get; set; }
        public DbSet<SedTypeSync> SedTypeSyncs { get; set; }
        public DbSet<DocumentAggregate.Signature> Signatures { get; set; }
        public DbSet<DocumentAggregate.Version> Versions { get; set; }
        public DbSet<TypeMaterial> TypeMaterials { get; set; }
        public DbSet<IncomingAddDocument> IncomingAddDocuments { get; set; }
        public DbSet<OutgoingAddDocument> OutgoingAddDocuments { get; set; }
        public DbSet<IncomingDocument> IncomingDocuments { get; set; }
        public DbSet<OutgoingDocument> OutgoingDocuments { get; set; }
        public DbSet<TrackingStatus> TrackingStatuses { get; set; }
        public DbSet<IncomingMailingTrack> IncomingMailingTracks { get; set; }
        public DbSet<OutgoingMailingTrack> OutgoingMailingTracks { get; set; }
        public DbSet<IncomingMessage> IncomingMessages { get; set; }
        public DbSet<OutgoingMessage> OutgoingMessages { get; set; }
        public DbSet<Receiver> Receivers { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }

        private IDbContextTransaction _currentTransaction;

        public IntegrationAISIIContext(DbContextOptions<IntegrationAISIIContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;

        public bool HasActiveTransaction => _currentTransaction != null;

        public IntegrationAISIIContext(DbContextOptions<IntegrationAISIIContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));


            System.Diagnostics.Debug.WriteLine("IntegrationAISIIContext::ctor ->" + this.GetHashCode());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientRequestEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new IncomingAcknowledgementEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new IncomingMessageEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OutgoingAcknowledgementEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AckStatusEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new NotificationTypeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DocumentTypeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DocumentTypeSyncEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FileTypeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FileTypeSyncEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OrganizationEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OrganizationSyncEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SedTypeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SedTypeSyncEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SignatureEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new VersionEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new IncomingDocumentEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OutgoingDocumentEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TypeMaterialEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new IncomingAddDocumentEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OutgoingAddDocumentEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TrackingStatusEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new IncomingMailingTrackEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OutgoingMailingTrackEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ReceiverEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OutgoingMessageEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SubscriberEntityTypeConfiguration());
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            // Dispatch Domain Events collection. 
            // Choices:
            // A) Right BEFORE committing data (EF SaveChanges) into the DB will make a single transaction including  
            // side effects from the domain event handlers which are using the same DbContext with "InstancePerLifetimeScope" or "scoped" lifetime
            // B) Right AFTER committing data (EF SaveChanges) into the DB will make multiple transactions. 
            // You will need to handle eventual consistency and compensatory actions in case of failures in any of the Handlers. 
            await _mediator.DispatchDomainEventsAsync(this);

            // After executing this line all the changes (from the Command Handler and Domain Event Handlers) 
            // performed through the DbContext will be committed
            var result = await base.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            if (_currentTransaction != null) return null;

            _currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

            return _currentTransaction;
        }

        public async Task CommitTransactionAsync(IDbContextTransaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            if (transaction != _currentTransaction) throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");

            try
            {
                await SaveChangesAsync();
                transaction.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }
    }
}
