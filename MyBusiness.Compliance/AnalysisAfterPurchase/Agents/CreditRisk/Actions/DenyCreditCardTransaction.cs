using System;
using System.Threading;
using System.Threading.Tasks;
using MasUnity.Decision;
using MasUnity.Decision.Abstractions;
using MasUnity.Decision.Actions;
using MyBusiness.Compliance.AnalysisAfterPurchase.Agents.CreditRisk.Environments;
using MyBusiness.Compliance.AnalysisAfterPurchase.Agents.CreditRisk.Knowledges;
using MyBusiness.Compliance.AnalysisAfterPurchase.Models;

namespace MyBusiness.Compliance.AnalysisAfterPurchase.Agents.CreditRisk.Actions
{
    public class DenyCreditCardTransaction: IAction
    {
        private Transaction Transaction { get; set; }
        private PendingTransactions Queue { get; }
        private AboutCreditCardTransactionBetween8AmAnd20Pm Knowledge { get; }
        
        public DenyCreditCardTransaction(PendingTransactions queue, AboutCreditCardTransactionBetween8AmAnd20Pm knowledge)
        {
            Queue = queue;
            Knowledge = knowledge;
        }

        public Task<Perception> Realize(AgentContext context, CancellationToken cancellation)
        {
            Transaction = Queue.GetNext();
            
            return Perception.Assertion(
                ("It's a credit card transaction", Transaction.IsCreditCardTransaction()),
                ("It's normal transaction time", ScheduleEnvironment.ItsNormalTransactionSchedule()),
                ("It's an unsafe credit card transactions", Knowledge.IsUnsafeTransaction(Transaction))
            );
        }

        public async Task<AgentResult> Execute(AgentContext context, CancellationToken cancellation)
        {
            await Queue.SaveAsForbiddenTransaction(Transaction);
            Console.WriteLine(Transaction.ToString());

            return AgentResult.Ok($"{Transaction.Id} Denied");            
        }        
    }
}