using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//GetAllGames, GetGameByIdAsync, AddGame, ChangeGameInfo, Delete
namespace DL;

//traditionally IRepo
public interface IGameRepo
{

    List<Game> GetAllGames();
    Task<Game?> GetGameByIdAsync(int userId);
    object AddGame(Object entity);
    object ChangeGameInfo(object entity);
    void Delete(object entity);

}