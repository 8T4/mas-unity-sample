using System;

namespace MyBusiness.Compliance.AnalysisAfterPurchase.Agents.CreditRisk.Environments
{
    public static class ScheduleEnvironment
    {
        public static bool ItsNormalTransactionSchedule() =>
            !ItsRestrictedTransactionTime();
        
        public static bool ItsRestrictedTransactionTime()
        {
            return DateTime.Now.ItsRestrictedTransactionTime();
        }
        
        public static bool ItsRestrictedTransactionTime(this DateTime dateTime)
        {
            var currentTime = dateTime.TimeOfDay;
            var start = new TimeSpan(20, 0, 0);
            var end = new TimeSpan(8, 0, 0);

            return currentTime >= start || currentTime <= end;
        }        
    }
}