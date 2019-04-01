using System.Collections.Generic;

namespace CustomerInquiry.DataAccess.DomainModel
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string ContactEmail { get; set; }
        public int MobileNo { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
