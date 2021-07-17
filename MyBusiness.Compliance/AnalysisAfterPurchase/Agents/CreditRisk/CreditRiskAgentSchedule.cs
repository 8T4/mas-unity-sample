using System;
using MasUnity.Commons.Scheduling;

namespace MyBusiness.Compliance.AnalysisAfterPurchase.Agents.CreditRisk
{
    public class CreditRiskAgentSchedule: ISchedule
    {
        public DateTimeOffset? NextOccurrence()
        {
            return DateTimeOffset.Now.AddSeconds(10);
        }
    }
}