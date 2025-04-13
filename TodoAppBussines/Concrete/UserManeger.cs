using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppBussines.Abstract;
using TodoAppDataAccess.Abstract;
using TodoAppDataAccess.concrete;
using TodoAppEntities;

namespace TodoAppBussines.Concrete
{
    public class UserManeger : IUserService
    {
        private IUserRepository _userRepository;

        public UserManeger()
        {
            _userRepository = new UserRepository();
        }

        public User CreateUser(User user)
        {
            return _userRepository.CreateUser(user);
        }

        public void DeleteUser(int user)
        {
            _userRepository.DeleteUser(user);
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public User GetUserById(int id)
        {
            if (id > 0)
                return _userRepository.GetUserById(id);
            throw new Exception("id can not be less than 1");
        }

        public User UpdateUser(User user)
        {
            return _userRepository.UpdateUser(user);
        }
    }
}
