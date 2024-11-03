using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private IElasticClient _elasticClient;
        public SearchController(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }
        
        [HttpGet("ping")]
        public IActionResult PingElastic()
        {
            var pingResponse = _elasticClient.Ping();
            if (!pingResponse.IsValid)
                return BadRequest("Elasticsearch is not reachable.");
            return Ok("Elasticsearch is running.");
        }
        [HttpGet("search")]
        public IActionResult SearchCars(string query)
        {
            var searchResponse = _elasticClient.Search<Car>
                (s => s
    .Index("cars")
    .Query(q => q.MatchAll()));
            if (searchResponse.Documents.Count == 0)
                return BadRequest("matches not found");
            return Ok(searchResponse.Documents);
        }
    }
}
