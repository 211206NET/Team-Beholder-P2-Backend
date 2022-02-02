using Microsoft.AspNetCore.Mvc;
using Models;
using BL;
using Microsoft.Extensions.Caching.Memory;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreboardController : ControllerBase
    {
        private IUserBL _bl;
        private IMemoryCache _memoryCache;
        public ScoreboardController(IUserBL bl, IMemoryCache memoryCache)
        {
            _bl = bl;
            _memoryCache = memoryCache;
        }

        // GET: api/<ScoreboardController>
        [HttpGet]
        public async Task<List<User>> GetAsync()
        {
            List<User> allScore;
            if(!_memoryCache.TryGetValue("score", out allScore))
            {
                allScore = await _bl.GetAllScoresAsync();
                _memoryCache.Set("score", allScore, new TimeSpan(0, 0, 30));
            }
            return _bl;
        }

        // GET api/<ScoreboardController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetAsync(int id)
        {
            User foundUser = await _bl.GetScoreByIdAsync(id);
            if(foundUser.UserID !=0)
            {
                return Ok(foundUser);
            }
            else
            {
                return NoContent();
            }
        }

        // POST api/<ScoreboardController>
        [HttpPost]
        public ActionResult<User> Post([FromBody] Scoreboard scoreObj)
        {
                _bl.AddScore(scoreObj);
                //Serilog.Log.Information("A User was made!!!");
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
