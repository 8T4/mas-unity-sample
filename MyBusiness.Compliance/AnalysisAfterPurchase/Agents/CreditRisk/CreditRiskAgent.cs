using System.Collections.Generic;
using MasUnity.Agents;
using MasUnity.Decision.Abstractions;
using MasUnity.HostedService.Contracts;
using MyBusiness.Compliance.AnalysisAfterPurchase.Agents.CreditRisk.Actions;

namespace MyBusiness.Compliance.AnalysisAfterPurchase.Agents.CreditRisk
{
    public class CreditRiskAgent: ProactiveAgent
    {
        private readonly IAgentServiceScope _scope;

        public CreditRiskAgent(IAgentServiceScope scope, CreditRiskAgentSchedule schedule) : base(schedule)
        {
            _scope = scope;
        }

        protected override IEnumerable<IAction> RegisterActions()
        {
            yield return _scope.GetService<AllowCreditCardTransaction>();
            yield return _scope.GetService<DenyCreditCardTransaction>();
            yield return _scope.GetService<DenyCreditCardTransactionAfter20Pm>();
        }
    }
}