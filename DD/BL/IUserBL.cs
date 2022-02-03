using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BL;
//was IBL in lessons
//GetAllGames, GetGameByIdAsync, AddGame, ChangeGameInfo, Delete
public interface IUserBL
{

    object AddCustomer(Object entity);

    bool IsDuplicate(User IsUser);

    List<User> GetAllUsers();

    Task<User?> GetUserByIdAsync(int userId);

    List<User> SearchUsers(string searchTerm);

    void Delete(object entity);

}