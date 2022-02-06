namespace BL;
//Was RRBL in lessons
//GetAllGames, GetGameByIdAsync, AddGame, ChangeGameInfo, Delete
public class EFGameBL : IGameBL
{

    private IGameRepo _dl;

    public EFGameBL(IGameRepo repo)
    {
        _dl = repo;

    }

    //------------------------------------------------------------------------------\\
    //<>                                Games                                     <>\\
    //------------------------------------------------------------------------------\\
    public List<GameControl?> GetAllGames()
    {
        return _dl.GetAllGames();
    }

    public async Task<GameControl?> GetGameByIdAsync(int id)
    {
        return await _dl.GetGameByIdAsync(id);
    }

    public object AddGame(Object entity)
    {
        return _dl.AddGame(entity);
    }

    public object ChangeGameInfo(Object entity)
    {
        return _dl.ChangeGameInfo(entity);
    }

    public void Delete(Object? entity)
    {
        _dl.Delete(entity);
    }


}