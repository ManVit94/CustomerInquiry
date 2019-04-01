using CustomerInquiry.DataAccess.Enum;
using System;

namespace CustomerInquiry.DataAccess.DomainModel
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public DateTime TransactionTime { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public TransactionStatus Status { get; set; }

        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
