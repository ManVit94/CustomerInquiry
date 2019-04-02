using CustomerInquiry.WebApi.Models;

namespace CustomerInquiry.WebApi.Validators
{
    public static class CustomerControllerValidator
    {
        public static string ValidateGetCustomerRequest(CustomerRequestModel request)
        {
            if (request.Email == null)
            {
                if (request.CustomerId == 0) return "No inquiry criteria";

                if (request.CustomerId < 0) return "Invalid Customer ID";
            }

            else if (!IsValidEmail(request.Email) || request.Email.Length > 25) return "Invalid Email";

            return null;
        }

        static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
