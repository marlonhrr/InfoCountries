using InfoCountries.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfoCountries.Common.Services
{
    public interface IApiService
    {
        Task<bool> CheckConnection(string url);
        Task<Response<object>> GetListAsync<T>(
            string urlBase,
            string servicePrefix,
            string controller);
    }
}
