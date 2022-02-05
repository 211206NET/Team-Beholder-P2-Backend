namespace DL;

//traditionally IRepo
public interface IUserRepo
{

    object AddCustomer(Object entity);

    bool IsDuplicate(User IsUser);

    List<User> GetAllUsers();

    Task<User?> GetUserByIdAsync(int userId);

    List<User> SearchUsers(string searchTerm);

    void Delete(object entity);

}

