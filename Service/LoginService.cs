
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

        public async Task<User> Login(string login, string password)
        {
            User user = await _usersDbContext.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Login == login && u.Password == password);

            if (user == null)
            {
                Console.WriteLine("null");
            }
            else
            {
                Console.WriteLine(user.Id);
            }
            return user;
        }

        public async Task<User> Register(User user) 
        {
            var addUser = new User
            {
                Name = user.Name,
                Login = user.Login,
                Password = user.Password,
                RoleId = 2
            };

            await _usersDbContext.Users.AddAsync(addUser);
            await _usersDbContext.SaveChangesAsync();
            return addUser;
            //await _usersDbContext.Users.AddAsync(user);
            //await _usersDbContext.SaveChangesAsync();
            //Console.WriteLine("User success add");

            //return user;
        }
    }
}
