using HandleData.Model;

namespace HandleData.Proxy
{
    public interface IExternalApiProxy
    {
        Task<Data?> GetAsync(string organizationNumber);
    }
}
