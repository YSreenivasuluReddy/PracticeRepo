using HttpClientEx1.InMemory;
using HttpClientEx1.Interfaces;
using HttpClientEx1.Models;
using Microsoft.AspNetCore.Identity;

namespace HttpClientEx1.Services
{
    public class UserService : IUserService
    {
        private readonly UsersStore _userstore;

        //UsersStore userdetails = new UsersStore();
        public UserService(UsersStore userstore)
        {
            _userstore = userstore;
        }

        //here i am implementing the method to get the details.
        public List<User> getUserDetails()
        {
            //UsersStore userdetails = new UsersStore();

            var user = _userstore.usersData;
            return user;
        }

        //here i am implementing the method to get the user details by id.

        public User? getUserById(int id)
        {
            var user = _userstore.usersData.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                user = null;
            }

            return user;
        }

        //here i am implementing the logic to add the new user.
        public User AddNewUser(User user)
        {
            user.Id = _userstore.usersData.Count + 1;

            _userstore.usersData.Add(user);

            return user;
        }
    }
}
