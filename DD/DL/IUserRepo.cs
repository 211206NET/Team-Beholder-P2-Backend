namespace DL;

//traditionally IRepo
public interface IUserRepo
{

    void AddCustomer(Object entity);

    bool IsDuplicate(User IsUser);

}

