using MyBusiness.Compliance.RiskAnalysis.Environment.Transactions;

namespace MyBusiness.Compliance.RiskAnalysis.Agents.CreditRisk.Knowledges
{
    public static class AboutCreditCardTransaction
    {
        public static bool IsCreditCardTransaction(this Transaction transaction) =>
            transaction.Chanell == TransactionChannel.Credit;
    }
}