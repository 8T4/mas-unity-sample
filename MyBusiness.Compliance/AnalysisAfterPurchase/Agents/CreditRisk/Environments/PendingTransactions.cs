using System.Threading.Tasks;
using MasUnity.Decision.Abstractions;
using MyBusiness.Compliance.AnalysisAfterPurchase.Application;
using MyBusiness.Compliance.AnalysisAfterPurchase.Models;

namespace MyBusiness.Compliance.AnalysisAfterPurchase.Agents.CreditRisk.Environments
{
    public class PendingTransactions : IEnvironment
    {
        private readonly TransactionBroker _broker;

        public PendingTransactions(TransactionHolder holder)
        {
            _broker = holder.Broker;
        }

        public Transaction GetNext()
        {
            var result = _broker.Transactions.TryDequeue(out var transaction);
            return result ? transaction : new Transaction();
        }
        
        public Task SaveAsForbiddenTransaction(Transaction transaction)
        {
            transaction.Deny();
            _broker.ForbiddenTransactions.Enqueue(transaction);
            return Task.CompletedTask;
        }

        public Task SaveAsApprovedTransaction(Transaction transaction)
        {
            transaction.Allow();
            _broker.ApprovedTransactions.Enqueue(transaction);
            return Task.CompletedTask;
        }
    }
}