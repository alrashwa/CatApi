using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatController : ControllerBase
    {
        private readonly ILogger<CatController> logger;

        public CatController(ILogger<CatController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization 
                = new AuthenticationHeaderValue("4238d93b-5de3-4a0a-9eaa-6cabd1a05387");

            var breedResponse = await httpClient.GetAsync("https://api.thecatapi.com/v1/breeds");
            var breedInfo = await breedResponse.Content.ReadAsStringAsync();

            return Ok(breedInfo);
        }
    }
}