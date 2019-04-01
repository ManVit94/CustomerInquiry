using System.Threading.Tasks;
using CustomerInquiry.Services.DTOModel;

namespace CustomerInquiry.Services
{
    public interface ICustomerService
    {
        Task<ServiceResult<CustomerInfoDTO>> GetCustomerInfoAsync(int customerId, int takeTransactionCount);
        Task<ServiceResult<CustomerInfoDTO>> GetCustomerInfoAsync(string customerEmail, int takeTransactionCount);
    }
}
