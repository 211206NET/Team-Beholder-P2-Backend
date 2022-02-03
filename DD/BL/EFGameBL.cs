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
    public List<Game?> GetAllGames()
    {
        return _dl.GetAllGames();
    }

    public async Task<Game?> GetGameByIdAsync(string id)
    {
        return await _dl.GetGameByIdAsync(id);
    }

    public void AddGame(Object entity)
    {
        _dl.AddGame(entity);
    }

    public object ChangeGameInfo(object entity)
    {
        return _dl.ChangeGameInfo(entity);
    }

    public void Delete(object entity)
    {
        _dl.Delete(entity);
    }


}