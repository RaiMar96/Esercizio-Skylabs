using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestWebApi.Models;

namespace TestWebApi.Services
{
    public interface ICommunicationGateway
    {
        Task<int> CreateItemAsync(TestWebItem testWebItem);
        Task<List<TestWebItem>> GetItemAsync(string name);
    }
}
