using InfoCountries.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfoCountries.Common.Services
{
    public interface IApiService
    {
        Task<Response> CheckConnection();
        Task<Response> GetListAsync<T>(
            string urlBase,
            string servicePrefix,
            string controller);
    }
}
