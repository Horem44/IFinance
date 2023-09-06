using FinanceManager.Domain.AggregatesModel.ExpenseAggregate;
using FinanceManager.Domain.AggregatesModel.RevenueAggregate;
using FinanceManager.Domain.SeedWork;
using FinanceManager.Infrastructure.EntityConfigurations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.VisualBasic;
using System;
using System.Data;

namespace FinanceManager.Infrastructure
{
    public class FinanceManagerContext : DbContext, IUnitOfWork
    {
        public DbSet<Revenue> Revenue { get; set; }
        public DbSet<Expense> Expense { get; set; }
        public DbSet<ExpenseVariety> ExpenseVariety { get; set; }
        public DbSet<ExpenseType> ExpenseType { get; set; }
        public DbSet<RevenueVariety> RevenueVariety { get; set; }
        public DbSet<RevenueType> RevenueType { get; set; }

        private readonly IMediator _mediator;
        private IDbContextTransaction? _currentTransaction;

        public IDbContextTransaction? GetCurrentTransaction() => _currentTransaction;

        public bool HasActiveTransaction => _currentTransaction != null;

        public FinanceManagerContext(
            DbContextOptions<FinanceManagerContext> options,
            IMediator mediator
        )
            : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

            System.Diagnostics.Debug.WriteLine("FinanceManagerContext::ctor ->" + GetHashCode());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ExpenseEntityConfiguration());
            modelBuilder.ApplyConfiguration(new RevenueEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ExpenseTypeEntityConfiguration());
            modelBuilder.ApplyConfiguration(new RevenueTypeEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ExpenseVarietyEntityConfiguration());
            modelBuilder.ApplyConfiguration(new RevenueVarietyEntityConfiguration());
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            await _mediator.DispatchDomainEventsAsync(this);

            var result = await base.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<IDbContextTransaction?> BeginTransactionAsync()
        {
            if (_currentTransaction != null)
                return null;

            _currentTransaction = await Database.BeginTransactionAsync(
                IsolationLevel.ReadCommitted
            );

            return _currentTransaction;
        }

        public async Task CommitTransactionAsync(IDbContextTransaction transaction)
        {
            if (transaction == null)
                throw new ArgumentNullException(nameof(transaction));
            if (transaction != _currentTransaction)
                throw new InvalidOperationException(
                    $"Transaction {transaction.TransactionId} is not current"
                );

            try
            {
                await SaveChangesAsync();
                await transaction.CommitAsync();
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
