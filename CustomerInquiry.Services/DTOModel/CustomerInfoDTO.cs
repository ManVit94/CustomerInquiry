using System.Collections.Generic;
using CustomerInquiry.DataAccess.DomainModel;

namespace CustomerInquiry.Services.DTOModel
{
    public class CustomerInfoDTO
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public ICollection<TransactionInfoDTO> Transactions { get; set; }

        public static CustomerInfoDTO MapFromDomain(Customer customer, ICollection<TransactionInfoDTO> transactions)
        {
            return new CustomerInfoDTO
            {
                CustomerID = customer.CustomerID,
                Email = customer.ContactEmail,
                Mobile = customer.MobileNo.ToString(),
                Name = customer.CustomerName,
                Transactions = transactions
            };
        }
    }
}
