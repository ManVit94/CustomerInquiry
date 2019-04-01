using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CustomerInquiry.DataAccess;
using CustomerInquiry.DataAccess.DomainModel;
using CustomerInquiry.Services.DTOModel;

namespace CustomerInquiry.Services.Implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerInquiryDbContext _context;

        public CustomerService(CustomerInquiryDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResult<CustomerInfoDTO>> GetCustomerInfoAsync(int customerId, int takeTransactionCount)
        {
            var result = new ServiceResult<CustomerInfoDTO>();

            try
            {
                var customer = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerID == customerId);

                result = await GetCustomerTransactionsInfoAsync(customer, takeTransactionCount);
            }
            catch
            {
                result.Status = ServiceResultStatus.Error;
            }

            return result;
        }

        public async Task<ServiceResult<CustomerInfoDTO>> GetCustomerInfoAsync(string customerEmail, int takeTransactionCount)
        {
            var result = new ServiceResult<CustomerInfoDTO>();

            try
            {
                var customer = await _context.Customers.FirstOrDefaultAsync(c => c.ContactEmail == customerEmail);

                result = await GetCustomerTransactionsInfoAsync(customer, takeTransactionCount);
            }
            catch
            {
                result.Status = ServiceResultStatus.Error;
            }

            return result;
        }

        private async Task<ServiceResult<CustomerInfoDTO>> GetCustomerTransactionsInfoAsync(Customer customer, int takeTransactions)
        {
            var result = new ServiceResult<CustomerInfoDTO>();

            if (customer == null)
            {
                result.Status = ServiceResultStatus.NotFound;
                return result;
            }

            var transactions = await _context.Transactions
                    .Where(t => t.CustomerID == customer.CustomerID)
                    .OrderByDescending(t => t.TransactionTime)
                    .Take(takeTransactions)
                    .ToListAsync();

            var transactionsDTO = transactions.Select(t => TransactionInfoDTO.MapFromDomain(t)).ToList();

            result.Data = CustomerInfoDTO.MapFromDomain(customer, transactionsDTO);
            result.Status = ServiceResultStatus.Success;

            return result;
        }
    }
}
