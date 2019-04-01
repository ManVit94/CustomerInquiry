using System;
using CustomerInquiry.DataAccess.DomainModel;
using CustomerInquiry.DataAccess.Enum;
using CustomerInquiry.Services.Extensions;

namespace CustomerInquiry.Services.DTOModel
{
    public class TransactionInfoDTO
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Amount { get; set; }
        public string Currency { get; set; }
        public string Status { get; set; }

        public static TransactionInfoDTO MapFromDomain(Transaction transaction)
        {
            return new TransactionInfoDTO
            {
                Id = transaction.TransactionID,
                Amount = transaction.Amount.ToFormattedString(),
                Currency = transaction.CurrencyCode,
                Date = transaction.TransactionTime.ToFormattedString(),
                Status = Enum.GetName(typeof(TransactionStatus), transaction.Status) ?? "Unknown"
            };
        }
    }
}
