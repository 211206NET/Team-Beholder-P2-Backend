using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//GetAllGames, GetGameByIdAsync, AddGame, ChangeGameInfo, Delete

namespace DL;
//traditionally DBrepo


public class EFGameRepo : IGameRepo
{

    private DDDBContext _context;
    // private string _context;

    public EFGameRepo(DDDBContext context)
    {
        _context = context;
    }

    public List<Game> GetAllGames()
    {
        return _context.Games.Select(r => r).ToList();
    }

    public async Task<Game?> GetGameByIdAsync(int gameId)
    {
        return await _context.Games
        //.Include("Reviews")
        .FirstOrDefaultAsync(r => r.GameID == gameId);
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

