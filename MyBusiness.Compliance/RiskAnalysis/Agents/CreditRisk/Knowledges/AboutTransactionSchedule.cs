using System;

namespace MyBusiness.Compliance.RiskAnalysis.Agents.CreditRisk.Knowledges
{
    public static class AboutTransactionSchedule
    {
        public static bool ItsNormalTransactionSchedule() =>
            !ItsRestrictedTransactionTime();
        
        public static bool ItsRestrictedTransactionTime() =>
            DateTime.Now.ItsRestrictedTransactionTime();

        private static bool ItsRestrictedTransactionTime(this DateTime dateTime)
        {
            var currentTime = dateTime.TimeOfDay;
            var start = new TimeSpan(20, 0, 0);
            var end = new TimeSpan(8, 0, 0);

            return currentTime >= start || currentTime <= end;
        }        
    }
}