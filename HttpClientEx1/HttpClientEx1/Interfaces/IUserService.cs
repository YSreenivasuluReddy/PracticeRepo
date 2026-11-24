using HttpClientEx1.Models;

namespace HttpClientEx1.Interfaces
{
    public interface IUserService
    {
        List<User> getUserDetails();

        User? getUserById(int id);

        User AddNewUser(User user);
    }
}
