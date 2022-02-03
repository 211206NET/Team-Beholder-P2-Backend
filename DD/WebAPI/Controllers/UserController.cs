using Microsoft.AspNetCore.Mvc;
using Models;
using BL;
//using CustomExceptions;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Authorization;
//using Serilog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
/*
for serilog
dotnet add package Serilog
dotnet add package Serilog.Sinks.Console
dotnet add package Serilog.Sinks.File
*/

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //===================================================() Initialize ()===================================================\\
        private IUserBL _bl;
        private IMemoryCache _memoryCache; 

        public UserController(IUserBL bl, IMemoryCache memoryCache)//, ILogger<UserController> logger)
        {
            _bl = bl;
            _memoryCache = memoryCache;
        }

        //------------------------------------------------<> GetAllUsers <>---------------------------------------------------\\
        // GET: api/<UserController>  get a list
        [HttpGet]
        public List<User> Get()//Get All
        {
            List<User> allUsers;// = _bl.GetAllUsers();
            if (!_memoryCache.TryGetValue("User", out allUsers))//null ref
            {
                allUsers = _bl.GetAllUsers();
                _memoryCache.Set("User", allUsers, new TimeSpan(0, 0, 30));
            }
            return allUsers;
        }

        //---------------------------------------------<> GetUserByIdAsync <>--------------------------------------------------\\
        // GET api/<UserController>/5 Get value or something abse don id e.g 5    
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetAsync(int id)
        {
            User foundUser = await _bl.GetUserByIdAsync(id);
            if (foundUser.UserID != 0)
            {
                return Ok(foundUser);
            }
            else
            {
                return NoContent();
            }
        }

        //------------------------------------------------<> Search <>-------------------------------------------------------\\
        [HttpGet("search/{term}")]
        public List<User> Search(string term)
        {
            return _bl.SearchUsers(term);
        }

        //------------------------------------------------<> AddUser <>-------------------------------------------------------\\
        // POST api/<UserController> Upload
        [HttpPost]
        public ActionResult<User> Post([FromBody] User UserToAdd)
        {
            //try
            //{
                _bl.AddCustomer(UserToAdd);
                //Serilog.Log.Information("A User was made!!!");
                return Created("User added!!!", UserToAdd);
            //}
            //catch (DuplicateRecordException ex)//Doesn't catch, I used the duplicate method in DBRepo to catch it instead
            //{
                //return Conflict(ex.Message);
            //}
        }

        //-------------------------------------------------<> ChangeUserInfo <>--------------------------------------------------\\
        // PUT api/<UserController>/5  add to something
        //[Authorize]
        /*
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] User changeUserInfo)
        {
            try
            {
                _bl.ChangeUserInfo(changeUserInfo);
                return Created("User updated", changeUserInfo);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }

        }
        */
        
        //-------------------------------------------------<> Delete <>--------------------------------------------------\\
        // DELETE api/<RestaurantController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            _bl.Delete(await _bl.GetUserByIdAsync(id));
        }
    }
}
