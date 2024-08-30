using Microsoft.EntityFrameworkCore;
using RememberTask.Data;
using RememberTask.Interface;
using RememberTask.Models;

namespace RememberTask.Service
{
    public class UserService : IUser<User>
    {
        public UsersDBContext _dbContext { get; set; }
        public UserService(UsersDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<User>> GetAllUsers()
        {
            //            User user = await _usersDbContext.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Login == login && u.Password == password);
            return await _dbContext.Users.Include(u => u.Role).ToListAsync();
        }
        public async Task<User> GetUser(int id)
        {
            User user = await _dbContext.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Id == id);
            if(user == null)
            {
                Console.WriteLine("null");
                return null;
            }
            return user;
        }
        public async Task<User> CreateUser(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        private bool UserAvaliable(int id)
        {
            return (_dbContext.Users?.Any(x => x.Id == id)).GetValueOrDefault();
        }
        public async Task<User> UpdateUser(int id, User user)
        {
            if(id != user.Id)
            {
                Console.WriteLine("null");
            }
            _dbContext.Entry(user).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                if(!UserAvaliable(id))
                {
                    Console.WriteLine(ex.Message.ToString());
                }
                else
                {
                    throw;
                }
            }
            return user;
        }
        public async Task<User> DeleteUser(int id)
        {
            if(_dbContext == null)
            {
                Console.WriteLine("null");
            }
            var delUs = await _dbContext.Users.FindAsync(id);
            if(delUs == null)
            {
                return null;
            }
            _dbContext.Users.Remove(delUs);
            await _dbContext.SaveChangesAsync();
            return delUs;
        }
    }
}
