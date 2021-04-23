using System.Collections.Generic;
using System.Threading.Tasks;
using TestWebApi.Models.DTO;

namespace TestWebApi.Services
{
    public interface ICommunicationGateway
    {
        Task<int> CreateItemAsync(DTOTestWebItem testWebItem);
        Task<List<DTOTestWebItem>> GetItemAsync(string name);
    }
}
