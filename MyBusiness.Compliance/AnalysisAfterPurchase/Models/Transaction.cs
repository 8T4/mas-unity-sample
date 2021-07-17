using System;
using System.Text;
using Newtonsoft.Json;

namespace MyBusiness.Compliance.AnalysisAfterPurchase.Models
{
    public class Transaction
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("N");
        public string DocumentId { get; set; }
        public TransactionChannel Chanell { get; set; } = TransactionChannel.None;
        public decimal Value { get; set; }
        public int ReliabilityRating { get; set; }
        public TransactionState State { get; set; } = TransactionState.None;
        public string StateDescription => State.ToString();
        public void Allow() => State = TransactionState.Allowed;
        public void Deny() => State = TransactionState.Denied;

        
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("".PadLeft(50, '*'));
            sb.AppendLine(State == TransactionState.Allowed ? "TRANSACTION ALLOWED" : "TRANSACTION DENIED");
            sb.AppendLine(JsonConvert.SerializeObject(this));
            sb.AppendLine("".PadLeft(50, '*'));

            return sb.ToString();
        }

        public static Transaction Build()
        {
            var channel = new Random().Next(1, 3) switch
            {
                1 => TransactionChannel.Credit,
                2 => TransactionChannel.Debit,
                3 => TransactionChannel.Cash,
                _ => TransactionChannel.None
            };
                
            return new Transaction
            {
                DocumentId = new Random().Next(0, 1000).ToString().PadLeft(10, '0'), 
                Chanell = channel, 
                ReliabilityRating = new Random().Next(0, 6),
                Value = new Random().Next(1000, 9000)
            };
        }
    }
}