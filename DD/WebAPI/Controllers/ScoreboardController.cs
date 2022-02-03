using Microsoft.AspNetCore.Mvc;
using Models;
using BL;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreboardController : ControllerBase
    {
        private IScoreBL _bl;
        private IMemoryCache _memoryCache;
        public ScoreboardController(IScoreBL bl, IMemoryCache memoryCache)
        {
            _bl = bl;
            _memoryCache = memoryCache;
        }

        // GET: api/<ScoreboardController>
        [HttpGet]
        public List<Scoreboard?> Get()
        {
            List<Scoreboard?> allScore;
            if(!_memoryCache.TryGetValue("score", out allScore))
            {
                allScore = _bl.GetAllScores();
                _memoryCache.Set("score", allScore, new TimeSpan(0, 0, 30));
            }
            return allScore;
        }

        // GET api/<ScoreboardController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Scoreboard?>> GetAsync(string? username)
        {
            Scoreboard foundScore = await _bl.GetScoreByIdAsync(username);
            return(foundScore);
            // if(foundScore.ScoreID !=0)
            // {
            //     return Ok(foundScore);
            // }
            // else
            // {
            //     return NoContent();
            // }
        }

        // POST api/<ScoreboardController>
        [HttpPost]
        public ActionResult<Scoreboard> Post([FromBody] Scoreboard scoreObj)
        {
            _bl.AddScore(scoreObj);
            //Serilog.Log.Information("A Score was made!!!");
            return Created("Score added!!!", scoreObj);
        }

        /*
        // PUT api/<ScoreboardController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        */

        /*
        // DELETE api/<ScoreboardController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _bl.Delete(await _bl.GetScoreByIdAsync(id));
        }
        */
    }
}
