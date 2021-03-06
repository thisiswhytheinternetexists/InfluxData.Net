﻿using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using InfluxData.Net.Common.Infrastructure;

namespace InfluxData.Net.Kapacitor.RequestClients
{
    public interface IKapacitorRequestClient
    {
        Task<IInfluxDataApiResponse> GetAsync(string path, IDictionary<string, string> requestParams = null);

        Task<IInfluxDataApiResponse> PostAsync(string path, IDictionary<string, string> requestParams = null, string content = null);

        Task<IInfluxDataApiResponse> DeleteAsync(string path, IDictionary<string, string> requestParams = null);

        Task<IInfluxDataApiResponse> RequestAsync(
            HttpMethod method,
            string path,
            IDictionary<string, string> requestParams = null,
            HttpContent content = null,
            bool includeAuthToQuery = true,
            bool headerIsBody = false);
    }
}