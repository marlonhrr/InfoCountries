using InfoCountries.Prism.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfoCountries.Prism.Services
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
