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
        private IBL _bl;
        private IMemoryCache _memoryCache;
        public ScoreboardController(IBL bl, IMemoryCache memoryCache)
        {
            _bl = bl;
            _memoryCache = memoryCache;
        }

        // GET: api/<ScoreboardController>
        [HttpGet]
        public async Task<List<User>> GetAsync()
        {
            List<User> user;
            if(!_memoryCache.TryGetValue("user", out allUsers))
            {
                allUsers = await _bl.GetAllUsersAsync();
                _memoryCache.Set("user", allUsers, new TimeSpan(0, 0, 30));
            }
            return _bl;
        }

        // GET api/<ScoreboardController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetAsync(int id)
        {
            User foundUser = await _bl.GetUserByIdAsync(id);
            if(foundUser.Id !=0)
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
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ScoreboardController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ScoreboardController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
