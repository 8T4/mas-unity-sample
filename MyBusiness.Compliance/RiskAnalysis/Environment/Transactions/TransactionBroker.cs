using System.Collections.Concurrent;

namespace MyBusiness.Compliance.RiskAnalysis.Environment.Transactions
{
    public class TransactionBroker
    {
        public ConcurrentQueue<Transaction> Transactions { get; }
        public ConcurrentQueue<Transaction> ForbiddenTransactions { get; }
        public ConcurrentQueue<Transaction> ApprovedTransactions { get;  }
        
        public TransactionBroker()
        {
            Transactions = new ConcurrentQueue<Transaction>();
            ForbiddenTransactions = new ConcurrentQueue<Transaction>();
            ApprovedTransactions = new ConcurrentQueue<Transaction>();
            
            CreateTransactions(100);
        }

        private void CreateTransactions(int size)
        {
            for (var i = 0; i < size; i++)
            {
                Transactions.Enqueue(Transaction.Build());
            }
        }
    }
}