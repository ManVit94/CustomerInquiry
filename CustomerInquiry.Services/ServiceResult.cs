namespace CustomerInquiry.Services
{
    public enum ServiceResultStatus
    {
        Success,
        NotFound,
        Error
    }

    public class ServiceResult
    {
        public ServiceResultStatus Status { get; set; }
        public string Message { get; set; }
    }

    public class ServiceResult<T> : ServiceResult
    {
        public T Data { get; set; }
    }
}
