using Microsoft.EntityFrameworkCore;
using RememberTask.Data;
using RememberTask.Interface;
using RememberTask.Models;

namespace RememberTask.Service
{
    public class UserService : ICRUD<User>
    {
        public UsersDBContext _dbContext { get; set; }
        public UserService(UsersDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<User>> GetAll()
        {
            return await _dbContext.Users.Include(u => u.Role).ToListAsync();
        }

        public async Task<User> GetByID(int id)
        {
            User user = await _dbContext.Users.Include(u =>u.Role).FirstOrDefaultAsync(u => u.Id == id);
            if(user == null)
            {
                Console.WriteLine("null");
                return null;
            }
            return user;
        }

        public async Task<User> Create(User name)
        {
            await _dbContext.Users.AddAsync(name);
            await _dbContext.SaveChangesAsync();
            return name;
        }
        private bool UserAvaliable(int id)
        {
            return (_dbContext.Users?.Any(x => x.Id == id)).GetValueOrDefault();
        }
        public async Task<User> Update(int id, User name)
        {
            if(id != name.Id)
            {
                Console.WriteLine("null");
            }
            _dbContext.Entry(name).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                if (!UserAvaliable(id))
                {
                    Console.WriteLine(ex.Message.ToString());
                }
            }
            return name;
        }

        public async Task<User> Delete(int id)
        {
            if(_dbContext == null)
            {
                Console.WriteLine("null");
            }
            var delUs = await _dbContext.Users.FindAsync(id);
            if (delUs != null)
            {
                return null;
            }
            _dbContext.Users.Remove(delUs);
            await _dbContext.SaveChangesAsync();
            return delUs;
        }
    }
}