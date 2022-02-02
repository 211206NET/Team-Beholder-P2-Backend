namespace BL;
//was IBL in lessons

public interface IUserBL
{

    object AddCustomer(Object entity);

    bool IsDuplicate(User IsUser);

    List<User> GetAllUsers();

    Task<User?> GetUserByIdAsync(int userId);

    List<User> SearchUsers(string searchTerm);

    void Delete(object entity);

}