namespace DL;

//traditionally IRepo
public interface IUserRepo
{

<<<<<<< HEAD
    void AddUser(Object entity);
=======
    object AddCustomer(Object entity);
>>>>>>> origin/main

    bool IsDuplicate(User IsUser);

    List<User> GetAllUsers();

    Task<User?> GetUserByIdAsync(int userId);

    List<User> SearchUsers(string searchTerm);

    void Delete(object entity);

}

