using MasUnity.Decision.Abstractions;
using MyBusiness.Compliance.AnalysisAfterPurchase.Models;

namespace MyBusiness.Compliance.AnalysisAfterPurchase.Agents.CreditRisk.Knowledges
{
    public class AboutCreditCardTransactionBetween8AmAnd20Pm : IKnowledge
    {
        public bool IsSafeTransaction(Transaction transaction) =>
            transaction.IsCreditCardTransaction() && !IsUnsafeTransaction(transaction);

        public bool IsUnsafeTransaction(Transaction transaction) =>
            transaction.IsCreditCardTransaction() && transaction.Value >= 4500 && transaction.ReliabilityRating < 3;
    }
}