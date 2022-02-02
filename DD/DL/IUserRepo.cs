namespace DL;
public interface IUserRepo
{

    void AddUser(Object entity);

    bool IsDuplicate(User IsUser);

}

