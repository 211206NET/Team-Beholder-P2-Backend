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
 


    public async Task<Scoreboard> GetAllScoresAsync()
    {
        return await _dl.GetAllScoresAsync();
    }

    public async Task<Scoreboard?> GetScoreByIdAsync(int scoreId)
    {
        return await _dl.GetScoreByIdAsync(scoreId);
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