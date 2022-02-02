namespace BL;
//Was RRBL in lessons

public class EFUserBL : IUserBL
{

    private IUserRepo _dl;

    public EFUserBL(IUserRepo repo)
    {
        _dl = repo;
    
    }

    //------------------------------------------------------------------------------\\
    //<>                                Users                                     <>\\
    //------------------------------------------------------------------------------\\
    public void AddCustomer(Object entity)
    {
        _dl.AddCustomer(entity);
    }

    public bool IsDuplicate(User IsUser)
    {
        return _dl.IsDuplicate(IsUser);
    }

    public List<User> GetAllUsers()
    {
        return _dl.GetAllUsers();
    }

    public Task<User?> GetUserByIdAsync(int userId)
    {
        return _dl.GetUserByIdAsync(userId);
    }

    public List<User> SearchUsers(string searchTerm)
    {
        return _dl.SearchUsers(searchTerm);
    }

    public void Delete(object entity)
    {
        _dl.Delete(entity);
    }

}