namespace BL;
//Was RRBL in lessons

public class EFScoreBL : IScoreBL
{

    private IScoreRepo _dl;

    public EFScoreBL(IScoreRepo repo)
    {
        _dl = repo;
    
    }

    //------------------------------------------------------------------------------\\
    //<>                                Scores                                     <>\\
    //------------------------------------------------------------------------------\\
 


    public List<Scoreboard?> GetAllScores()
    {
        return  _dl.GetAllScores();
    }

    public async Task<Scoreboard?> GetScoreByIdAsync(int id)
    {
        return await _dl.GetScoreByIdAsync(id);
    }

    public object ChangeScoreInfo(Object entity)
    {
        return _dl.ChangeScoreInfo(entity);
    }

    public void AddScore(Object entity)
    {
        _dl.AddScore(entity);
    }

    /*
    public void Delete(object entity)
    {
        _dl.Delete(entity);
    }

    public bool IsDuplicate(Scoreboard IsScore)
    {
        return _dl.IsDuplicate(IsScore);
    }
    */
}