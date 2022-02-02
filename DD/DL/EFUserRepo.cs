using Microsoft.EntityFrameworkCore;

namespace DL;

public class EFUserRepo : IUserRepo
{

    private string _bl;

    public EFUserRepo(string bl)
    {
        _bl = bl;
    }


    public void AddUser(Object entity)
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



}