using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerInquiry.WebApi.Models
{
    public class CustomerRequestModel
    {
        public int CustomerId { get; set; }
        public string Email { get; set; }
    }
}
