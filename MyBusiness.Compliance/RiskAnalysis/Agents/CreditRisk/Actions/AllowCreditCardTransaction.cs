using System;
using System.Threading;
using System.Threading.Tasks;
using MasUnity.Decision;
using MasUnity.Decision.Abstractions;
using MasUnity.Decision.Actions;
using MasUnity.HostedService.Contracts;
using MyBusiness.Compliance.RiskAnalysis.Agents.CreditRisk.Knowledges;
using MyBusiness.Compliance.RiskAnalysis.Environment.Transactions;

namespace MyBusiness.Compliance.RiskAnalysis.Agents.CreditRisk.Actions
{
    public class AllowCreditCardTransaction : IAction
    {
        private Transaction Transaction { get; set; }
        private PendingTransactions Queue { get; }
        private AboutCreditCardTransactionBetween8AmAnd20Pm Knowledge { get; }

        public AllowCreditCardTransaction(IAgentServiceScope serviceScope)
        {
            Queue = serviceScope.GetService<PendingTransactions>();
            Knowledge = serviceScope.GetService<AboutCreditCardTransactionBetween8AmAnd20Pm>();
        }        
        
        public Task<Perception> Realize(AgentContext context, CancellationToken cancellation)
        {
            Transaction = Queue.GetNext();

            return Perception.Assertion(
                ("It's a credit card transaction", Transaction.IsCreditCardTransaction()),
                ("It's normal transaction time", AboutTransactionSchedule.ItsNormalTransactionSchedule()),
                ("Has safe credit card transactions", Knowledge.IsSafeTransaction(Transaction))
            );
        }

        public async Task<AgentResult> Execute(AgentContext context, CancellationToken cancellation)
        {
            await Queue.SaveAsApprovedTransaction(Transaction);
            Console.WriteLine(Transaction.ToString(context));
            return AgentResult.Ok($"{Transaction.Id} Allowed");
        }
    }
}