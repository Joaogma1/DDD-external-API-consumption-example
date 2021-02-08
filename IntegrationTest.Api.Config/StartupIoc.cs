using Github.Config;
using Github.Services;
using IntegrationTest.Infra.Services;
using IntegrationTest.Models.Contracts.Infra;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTest.Api.Config
{
    public static class StartupIoc
    {
        public static IServiceCollection AppAddIoCServices(this IServiceCollection services, IConfiguration config)
        {
            var githubConfig = new GithubConfig();

            config.GetSection("Integration").GetSection("Github").Bind("GitHubConfig", githubConfig);

            services.AddScoped<GithubConfig>(_ => githubConfig);
            services.AddScoped<IRepositorioGithubService, RepositorioGithubService>();
            services.AddScoped<RepositoryService, RepositoryService>();

            return services;
        }
    }
}
