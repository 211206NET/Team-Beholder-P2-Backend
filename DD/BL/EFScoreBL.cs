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

    public async Task<Scoreboard?> GetScoreByIdAsync(string userId)
    {
        return await _dl.GetScoreByIdAsync(userId);
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