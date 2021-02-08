using Github.Models;
using IntegrationTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTest.Infra.Adapters
{
    public static class RepositoryAdapter
    {
        public static RepositorioGithub FromExternalApi(Repository repository)
        {
            return new RepositorioGithub
            {
                Nome = repository.full_name
            };
        }
        public static Repository FromInternalApi(RepositorioGithub repositorio)
        {
            return new Repository
            {
                full_name = repositorio.Nome
            };
        }
    }
}
