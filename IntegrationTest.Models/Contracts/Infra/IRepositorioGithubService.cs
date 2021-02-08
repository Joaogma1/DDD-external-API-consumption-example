using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTest.Models.Contracts.Infra
{
    public interface IRepositorioGithubService
    {
        Task<IEnumerable<RepositorioGithub>> ObterRepositorios();
    }
}
