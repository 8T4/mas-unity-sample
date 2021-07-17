using System;

namespace MyBusiness.Compliance.AnalysisAfterPurchase.Application
{
    public class TransactionHolder
    {
        private TransactionBroker _broker;
        public TransactionBroker Broker => _broker ??= GetContext().Value;

        private static Lazy<TransactionBroker> GetContext()
        {
            return new(() => new TransactionBroker());
        }
    }
}