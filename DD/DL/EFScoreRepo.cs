//GetAllScoresAsync   GetScoreByIdAsync AddScore

namespace DL;
//traditionally DBrepo

using Microsoft.EntityFrameworkCore;


public class EFScoreRepo : IScoreRepo
{

    private string _bl;

    public EFScoreRepo(string bl)
    {
        _bl = bl;
    }

    public async Task<Scoreboard?> GetAllScoresAsync()
    {
        return await _bl.Scores.Select(r => r).ToList();
    }

     public async Task<Scoreboard?> GetScoreByIdAsync(int scoreId)
    {
        return await _bl.Scores
        //.Include("Reviews")
        .FirstOrDefaultAsync(r => r.ScoreID == scoreId);
    }

    /*
    public object ChangeScoreInfo(object entity)
    {
        _bl.Entry(entity).State = EntityState.Modified;
        // _bl.Update(entity);
        _bl.SaveChanges();
        _bl.ChangeTracker.Clear();
        return entity;
    }
    */

    public void AddScore(Object entity)
    {

        _bl.Add(entity);
        _bl.SaveChanges();
        _bl.ChangeTracker.Clear();
        return entity;

    }

    /*
    public bool IsDuplicate(Score IsScore)
    {
        Score? dupe = _bl.Scores.FirstOrDefault(r => r.ScoreName == IsScore.ScoreName && r.Password == IsScore.Password && r.Email == IsScore.Email);
        return dupe != null;
    }

    
    public void Delete(object entity){
        _bl.Remove(entity);
        _bl.SaveChanges();
        _bl.ChangeTracker.Clear();
    }
    */



}

