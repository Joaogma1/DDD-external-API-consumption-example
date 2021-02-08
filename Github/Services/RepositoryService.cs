using Github.Config;
using Github.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Github.Services
{
    public class RepositoryService
    {
        private readonly HttpClient _client;

        public RepositoryService(GithubConfig config)
        {
            // TODO: Usar HttpClientFactory
            // TODO: Criar um BaseService que irá configurar o Authorization, setar basePath e outros headers que todas requisições irão utilizar
            // TODO: Usar mesma versão de newtonsoft / outras libs, assim como a versão do dotnetcore

            _client = new HttpClient();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", config.OAuthToken);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
            _client.BaseAddress = new Uri(config.RootUrlEndpoint);
        }

        public async Task<IEnumerable<Repository>> GetRepositories()
        {
            var response = await _client.GetAsync("user/repos");

            var repositoriesJsonString = await response.Content.ReadAsStringAsync();

            var repositories = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Repository>>(repositoriesJsonString);

            return repositories;
        }
    }
}
