using Microsoft.AspNetCore.Mvc;
using Models;
using BL;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//GetAllGames, GetGameByIdAsync, AddGame, ChangeGameInfo, Delete

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        //===================================================() Initialize ()===================================================\\
        private IGameBL _bl;
        private IMemoryCache _memoryCache;
        public GameController(IGameBL bl, IMemoryCache memoryCache)
        {
            _bl = bl;
            _memoryCache = memoryCache;
        }

        //------------------------------------------------<> GetAllGames <>---------------------------------------------------\\
        // GET: api/<GameController>
        [HttpGet]
        public List<Game?> Get()
        {
            List<Game?> allGames;
            if (!_memoryCache.TryGetValue("score", out allGames))
            {
                allGames = _bl.GetAllGames();
                _memoryCache.Set("score", allGames, new TimeSpan(0, 0, 30));
            }
            return allGames;
        }

        //---------------------------------------------<> GetGameByIdAsync <>--------------------------------------------------\\
        // GET api/<UserController>/5 Get value or something abse don id e.g 5    
        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetAsync(int id)
        {
            User foundUser = await _bl.GetGameByIdAsync(id);
            if (foundUser.UserID != 0)
            {
                return Ok(foundUser);
            }
            else
            {
                return NoContent();
            }
        }

        //------------------------------------------------<> AddGame <>-------------------------------------------------------\\
        // POST api/<UserController> Upload
        [HttpPost]
        public ActionResult<Game> Post([FromBody] Game GameToAdd)
        {
            //try
            //{
            _bl.AddCustomer(GameToAdd);
            //Serilog.Log.Information("A User was made!!!");
            return Created("Game added!!!", GameToAdd);
            //}
            //catch (DuplicateRecordException ex)//Doesn't catch, I used the duplicate method in DBRepo to catch it instead
            //{
            //return Conflict(ex.Message);
            //}
        }

        //-------------------------------------------------<> ChangeGameInfo <>--------------------------------------------------\\
        // PUT api/<GameController>/5
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] Game changeGameInfo)
        {
            try
            {
                _bl.ChangeUserInfo(changeGameInfo);
                return Created("Game updated", changeGameInfo);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }

        }

        //-------------------------------------------------<> Delete <>--------------------------------------------------\\
        // DELETE api/<RestaurantController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            _bl.Delete(await _bl.GetGameByIdAsync(id));
        }
    }
}
