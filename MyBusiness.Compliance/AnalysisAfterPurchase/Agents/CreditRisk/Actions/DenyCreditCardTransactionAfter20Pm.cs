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
    public class DenyCreditCardTransactionAfter20Pm: IAction
    {
        private Transaction Transaction { get; set; }
        private PendingTransactions Queue { get; }
        private AboutCreditCardTransactionAfter20Pm Knowledge { get; }
        
        
        public DenyCreditCardTransactionAfter20Pm(PendingTransactions queue, AboutCreditCardTransactionAfter20Pm knowledge)
        {
            Queue = queue;
            Knowledge = knowledge;
        }
        
        public Task<Perception> Realize(AgentContext context, CancellationToken cancellation)
        {
            Transaction = Queue.GetNext();
            
            return Perception.Assertion(
                ("It's a credit card transaction", Transaction.IsCreditCardTransaction()),
                ("It's restricted transaction time", ScheduleEnvironment.ItsRestrictedTransactionTime()),
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