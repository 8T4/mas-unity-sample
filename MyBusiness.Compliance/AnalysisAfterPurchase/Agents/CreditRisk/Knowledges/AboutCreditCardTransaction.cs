using MyBusiness.Compliance.AnalysisAfterPurchase.Models;

namespace MyBusiness.Compliance.AnalysisAfterPurchase.Agents.CreditRisk.Knowledges
{
    public static class AboutCreditCardTransaction
    {
        public static bool IsCreditCardTransaction(this Transaction transaction) =>
            transaction.Chanell == TransactionChannel.Credit;
    }
}