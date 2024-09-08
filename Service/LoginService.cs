using Microsoft.EntityFrameworkCore;
using RememberTask.Data;
using RememberTask.Interface;
using RememberTask.Models;

namespace RememberTask.Service
{
    public class LoginService : GenericInterface<string, User>
    {
        private readonly UsersDBContext _usersDbContext;
        public LoginService(UsersDBContext usersDBContext)
        {
            _usersDbContext = usersDBContext;
        }

        public async Task<string> GetUserRole(int userID)
        {
            var user = await _usersDbContext.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Id == userID);
            if(user == null)
            {
                Console.WriteLine("Пользователь не найден");
                return null;
            }
            return user.Role?.Name;
        }

        public async Task<User> Login(string login, string password)
        {
            User user = await _usersDbContext.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Login == login && u.Password == password);
            if (user != null)
            {
                Console.WriteLine("Nice");
            }
            return user;
        }

        public async Task<User> Register(User user)
        {
            User exsistingUser = await _usersDbContext.Users.FirstOrDefaultAsync(u => u.Login == user.Login);
            if (exsistingUser != null)
            {
                Console.WriteLine("пользователь с таким логином уже существует");
                return null;
            }

            User addUser = new User
            {
                Name = user.Name,
                Login = user.Login,
                Password = user.Password,
                RoleId = 2,
                IsVerify = 2
            };

            await _usersDbContext.Users.AddAsync(addUser);
            await _usersDbContext.SaveChangesAsync();
            return user;
        }

        public async Task<bool> Verify(int id)
        {
            User user = await _usersDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if(user == null)
            {
                Console.WriteLine("User is null");
                return false;
            }
            
            if(user.IsVerify == 1)
            {
                Console.WriteLine("User is verify");
                return true;
            }

            user.IsVerify = 1;
            await _usersDbContext.SaveChangesAsync();

            Console.WriteLine("user is verified");
            return true;
        }




        //сделать метод который будет чисто возвращать роль указанного в него пользователя
        //сделать метод который будет возвращать админку
    }
}