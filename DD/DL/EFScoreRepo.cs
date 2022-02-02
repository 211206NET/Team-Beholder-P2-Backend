using Microsoft.EntityFrameworkCore;
//GetAllScoresAsync   GetScoreByIdAsync AddScore

namespace DL;
//traditionally DBrepo



public class EFScoreRepo : IScoreRepo
{
    private DDDBContext _context;
    // private string _context;

    public EFScoreRepo(DDDBContext  context)
    {
        _context = context;
    }

    public List<Scoreboard?> GetAllScores()
    {
        return _context.Scores.Select(r => r).ToList();
    }

    public async Task<Scoreboard?> GetScoreByIdAsync(string userId)
    {
        return await _context.Scores
        //.Include("Reviews")
        .FirstOrDefaultAsync(r => r.Username == userId);
    }

    /*
    public object ChangeScoreInfo(object entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        // _context.Update(entity);
        _context.SaveChanges();
        _context.ChangeTracker.Clear();
        return entity;
    }
    */

    public object AddScore(Object entity)
    {

        _context.Add(entity);
        _context.SaveChanges();
        _context.ChangeTracker.Clear();
        return entity;

    }

    /*
    public bool IsDuplicate(Score IsScore)
    {
        Score? dupe = _context.Scores.FirstOrDefault(r => r.ScoreName == IsScore.ScoreName && r.Password == IsScore.Password && r.Email == IsScore.Email);
        return dupe != null;
    }

    
    public void Delete(object entity){
        _context.Remove(entity);
        _context.SaveChanges();
        _context.ChangeTracker.Clear();
    }
    */



}

