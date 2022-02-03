namespace BL;
//GetAllGames, GetGameByIdAsync, AddGame, ChangeGameInfo, Delete

//traditionally IRepo
public interface IGameBL
{

    List<GameControl> GetAllGames();
    Task<GameControl?> GetGameByIdAsync(int id);
    object AddGame(Object entity);
    object ChangeGameInfo(object entity);
    void Delete(object entity);

}