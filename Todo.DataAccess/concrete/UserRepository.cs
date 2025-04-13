using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoAppDataAccess.Abstract;
using TodoAppEntities;

namespace TodoAppDataAccess.concrete
{
    public class UserRepository : IUserRepository
    {
        public User CreateUser(User user)
        {
            using (var UserDbContext = new TodoDbContext())
            {
                UserDbContext.users.Add(user);
                UserDbContext.SaveChanges();
                return user;
            }
        }

        public User UpdateUser(User user)
        {
            using (var UserDbContext = new TodoDbContext())
            {
                UserDbContext.users.Update(user);
                UserDbContext.SaveChanges();
                return user;
            }
        }

        public List<User> GetAllUsers()
        {
            using (var UserDbContext = new TodoDbContext())
            {
                return UserDbContext.users.ToList();
            }
        }

        public User GetUserById(int id)
        {
            using (var UserDbContext = new TodoDbContext())
            {
                var user = UserDbContext.users
                           .Include(u => u.ToDos)
                           .FirstOrDefault(u => u.Id == id);

                return user;
            }
        }

        public void DeleteUser(int user)
        {
            using (var UserDbContext = new TodoDbContext())
            {
                var deletedUser= GetUserById(user);
                UserDbContext.users.Remove(deletedUser);
                UserDbContext.SaveChanges();
            }
        }
    }
}
