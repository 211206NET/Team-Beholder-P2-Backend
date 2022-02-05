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
        public List<GameControl?> Get()
        {
            List<GameControl?> allGames;
            if (!_memoryCache.TryGetValue("score", out allGames))
            {
                allGames = _bl.GetAllGames();
                _memoryCache.Set("score", allGames, new TimeSpan(0, 0, 30));
            }
            return allGames;
        }

        //---------------------------------------------<> GetGameByIdAsync <>--------------------------------------------------\\
        // GET api/<GameController>/5 Get value or something abse don id e.g 5    
        [HttpGet("{id}")]
        public async Task<ActionResult<GameControl>> GetAsync(int id)
        {
            GameControl foundGame = await _bl.GetGameByIdAsync(id);
            if (foundGame.Id != 0)
            {
                return Ok(foundGame);
            }
            else
            {
                return NoContent();
            }
        }

        //------------------------------------------------<> AddGame <>-------------------------------------------------------\\
        // POST api/<GameController> Upload
        [HttpPost]
<<<<<<< HEAD
        public ActionResult<GameControl> Post([FromForm] GameControl GameToAdd) //Was From Body
=======
        public ActionResult<GameControl> Post([FromForm] GameControl GameToAdd) //Was FromBody
>>>>>>> main
        {
            //try
            //{
            _bl.AddGame(GameToAdd);
            //Serilog.Log.Information("A GameControl was made!!!");
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
        public ActionResult Put([FromForm] GameControl entity) //FromBody, FromForm, FromHeader, FromQuery, FromRoute, FromServices
        {
            try
            {
                _bl.ChangeGameInfo(entity);
                return Created("GameControl updated", entity);
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
