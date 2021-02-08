using Github.Services;
using IntegrationTest.Infra.Adapters;
using IntegrationTest.Models;
using IntegrationTest.Models.Contracts.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTest.Infra.Services
{
    public class RepositorioGithubService : IRepositorioGithubService
    {
        private readonly RepositoryService _externalService;

        public RepositorioGithubService(
            RepositoryService externalService
        )
        {
            _externalService = externalService;
        }

        public async Task<IEnumerable<RepositorioGithub>> ObterRepositorios()
        {
            var externalRepositories = await _externalService.GetRepositories();

            var internalRepositories = externalRepositories
                .Select(RepositoryAdapter.FromExternalApi)
                .ToList();

            return internalRepositories;
        }
    }
}
