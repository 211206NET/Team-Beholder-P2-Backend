using Microsoft.EntityFrameworkCore;

namespace DL;
//traditionally DBrepo




public class EFUserRepo : IUserRepo
{

    private DDDBContext _context;
    // private string _context;

    public EFUserRepo(DDDBContext  context)
    {
        _context = context;
    }

    public List<User> GetAllUsers()
    {
        return _context.Users.Select(r => r).ToList();
    }

     public async Task<User?> GetUserByIdAsync(int userId)
    {
        return await _context.Users
        //.Include("Reviews")
        .FirstOrDefaultAsync(r => r.UserID == userId);
    }

    /*
    public object ChangeUserInfo(object entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        // _context.Update(entity);
        _context.SaveChanges();
        _context.ChangeTracker.Clear();
        return entity;
    }
    */

    public List<User> SearchUsers(string searchTerm)
    {
        return _context.Users.Where(x => x.Username.ToLower().Contains(searchTerm.ToLower()))
        .ToList();
    }

    public object AddCustomer(Object entity)
    {

        _context.Add(entity);
        _context.SaveChanges();
        _context.ChangeTracker.Clear();
        return entity;

    }

    
    public bool IsDuplicate(User IsUser)
    {
        User? dupe = _context.Users.FirstOrDefault(r => r.Username == IsUser.Username && r.Password == IsUser.Password && r.Email == IsUser.Email);
        return dupe != null;
    }

    
    public void Delete(object entity){
        _context.Remove(entity);
        _context.SaveChanges();
        _context.ChangeTracker.Clear();
    }



}

