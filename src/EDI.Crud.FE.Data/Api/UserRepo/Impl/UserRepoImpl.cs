using EDI.Crud.FE.Data.Api.UserRepo.Models;
using EDI.Crud.FE.Utilities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EDI.Crud.FE.Data.Api.UserRepo.Impl
{
    public class UserRepoImpl : IUserRepo
    {
        private readonly IHttpClientFactory _httpClient;

        public UserRepoImpl(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        private static string GenerateEndPoint(string route = "")
            => $"/User/{route}";

        public async Task<UserApiModel> Create(UserApiModel d, CancellationToken c)
        {
            HttpClient hc = _httpClient.CreateClient("EDI.Api");
            var resp = await hc.PostAsJsonAsync(GenerateEndPoint("setDatauser"), d, c);
            if (!resp.IsSuccessStatusCode)
            {
                if (resp.StatusCode != System.Net.HttpStatusCode.BadRequest)
                    throw new Exception();
                var msg = await resp.Content.ReadAsStringAsync();
                throw new DataApiLayerException(msg);
            }
            return await resp.Content.ReadAsAsync<UserApiModel>(c);
        }

        public async Task<UserDTResponseApiModel> DataTable(UserDTParamApiModel p, CancellationToken c)
        {
            HttpClient hc = _httpClient.CreateClient("EDI.Api");
            var resp = await hc.PostAsJsonAsync(GenerateEndPoint("Paging/DataTable"), p, c);
            if (!resp.IsSuccessStatusCode)
            {
                if (resp.StatusCode != System.Net.HttpStatusCode.BadRequest)
                    throw new Exception();
                var msg = await resp.Content.ReadAsStringAsync();
                throw new DataApiLayerException(msg);
            }
            return await resp.Content.ReadAsAsync<UserDTResponseApiModel>(c);
        }

        public async Task Delete(int id, CancellationToken c)
        {
            HttpClient hc = _httpClient.CreateClient("EDI.Api");
            var resp = await hc.DeleteAsync(GenerateEndPoint($"delDatauser/{id}"), c);
            if (!resp.IsSuccessStatusCode)
            {
                if (resp.StatusCode != System.Net.HttpStatusCode.BadRequest)
                    throw new Exception();
                var msg = await resp.Content.ReadAsStringAsync();
                throw new DataApiLayerException(msg);
            }
        }

        public async Task<UserApiModel> Read(int id, CancellationToken c)
        {
            HttpClient hc = _httpClient.CreateClient("EDI.Api");
            var resp = await hc.GetAsync(GenerateEndPoint($"getDatauser/{id}"), c);
            if (!resp.IsSuccessStatusCode)
            {
                if (resp.StatusCode != System.Net.HttpStatusCode.BadRequest)
                    throw new Exception();
                var msg = await resp.Content.ReadAsStringAsync();
                throw new DataApiLayerException(msg);
            }

            return await resp.Content.ReadAsAsync<UserApiModel>(c);
        }
    }
}
