using MasUnity.Decision.Abstractions;
using MyBusiness.Compliance.AnalysisAfterPurchase.Models;

namespace MyBusiness.Compliance.AnalysisAfterPurchase.Agents.CreditRisk.Knowledges
{
    public class AboutCreditCardTransactionAfter20Pm : IKnowledge
    {
        public bool IsUnsafeTransaction(Transaction transaction) =>
            transaction.IsCreditCardTransaction() && transaction.Value >= 2500 && transaction.ReliabilityRating <= 3;
    }
}