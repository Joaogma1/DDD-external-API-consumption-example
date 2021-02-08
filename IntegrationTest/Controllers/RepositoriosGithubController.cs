using IntegrationTest.Models;
using IntegrationTest.Models.Contracts.Infra;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepositoriosGithubController : ControllerBase
    {
        private readonly IRepositorioGithubService _githubService;

        public RepositoriosGithubController(
            IRepositorioGithubService githubService
        )
        {
            _githubService = githubService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RepositorioGithub>>> Get()
        {
            var repositorios = await _githubService.ObterRepositorios();
            
            return new ObjectResult(repositorios);
        }
    }
}
