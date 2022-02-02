
namespace DL;
//traditionally DBrepo

using Microsoft.EntityFrameworkCore;


public class EFUserRepo : IUserRepo
{

    private string _bl;

    public EFUserRepo(string bl)
    {
        _bl = bl;
    }

    public List<User> GetAllUsers()
    {
        return _bl.Users.Select(r => r).ToList();
    }

     public async Task<User?> GetUserByIdAsync(int userId)
    {
        return await _bl.Users
        //.Include("Reviews")
        .FirstOrDefaultAsync(r => r.UserID == userId);
    }

    /*
    public object ChangeUserInfo(object entity)
    {
        _bl.Entry(entity).State = EntityState.Modified;
        // _bl.Update(entity);
        _bl.SaveChanges();
        _bl.ChangeTracker.Clear();
        return entity;
    }
    */

    public List<User> SearchUsers(string searchTerm)
    {
        return _bl.Users.Where(x => x.StoreName.ToLower().Contains(searchTerm.ToLower()) ||
        x.State.ToLower().Contains(searchTerm.ToLower()) ||
        x.City.ToLower().Contains(searchTerm.ToLower()))
        .ToList();
    }

    public void AddCustomer(Object entity)
    {

        _bl.Add(entity);
        _bl.SaveChanges();
        _bl.ChangeTracker.Clear();
        return entity;

    }

    
    public bool IsDuplicate(User IsUser)
    {
        User? dupe = _bl.Users.FirstOrDefault(r => r.UserName == IsUser.UserName && r.Password == IsUser.Password && r.Email == IsUser.Email);
        return dupe != null;
    }

    
    public void Delete(object entity){
        _bl.Remove(entity);
        _bl.SaveChanges();
        _bl.ChangeTracker.Clear();
    }



}

