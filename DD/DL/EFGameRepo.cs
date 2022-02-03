using Microsoft.EntityFrameworkCore;

namespace DL;
//traditionally DBrepo
//GetAllGames, GetGameByIdAsync, AddGame, ChangeGameInfo, Delete

public class EFGameRepo : IGameRepo
{

    private DDDBContext _context;
    // private string _context;

    public EFGameRepo(DDDBContext context)
    {
        _context = context;
    }

    public List<GameControl> GetAllGames()
    {
        return _context.Games.Select(r => r).ToList();
    }

    public async Task<GameControl> GetGameByIdAsync(int id)
    {
        // return await _context.Games
        // //.Include("Reviews")
        // .FirstOrDefaultAsync(r => r.Id == idn);
        return await _context.Games.FirstOrDefaultAsync(r => r.Id == id);

        
    }

    public object AddGame(Object entity)
    {
        _context.Add(entity);
        _context.SaveChanges();
        _context.ChangeTracker.Clear();
        return entity;

    }

    public object ChangeGameInfo(object entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        // _context.Update(entity);
        _context.SaveChanges();
        _context.ChangeTracker.Clear();
        return entity;
    }
    
    public void Delete(object entity)
    {
        _context.Remove(entity);
        _context.SaveChanges();
        _context.ChangeTracker.Clear();
    }

}

