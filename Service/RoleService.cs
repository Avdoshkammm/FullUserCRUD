using Microsoft.EntityFrameworkCore;
using RememberTask.Data;
using RememberTask.Interface;
using RememberTask.Models;

namespace RememberTask.Service
{
    public class RoleService : ICRUD<Role>
    {
        private readonly UsersDBContext _dbContext;
        public RoleService(UsersDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public async Task<List<Role>> GetAll()
        {
            return await _dbContext.Roles.ToListAsync();
        }

        public async Task<Role> GetByID(int id)
        {
            Role role = await _dbContext.Roles.FindAsync(id);
            if(role == null)
            {
                Console.WriteLine("null");
                return null;
            }
            return role;
        }

        public async Task<Role> Create(Role name)
        {
            await _dbContext.Roles.AddAsync(name);
            await _dbContext.SaveChangesAsync();
            return name;
        }

        private bool RoleAvaliable(int id)
        {
            return (_dbContext.Roles?.Any(x => x.Id == id)).GetValueOrDefault();
        }

        public async Task<Role> Update(int id, Role name)
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
                if(!RoleAvaliable(id))
                {
                    Console.WriteLine(ex.Message.ToString());
                }
            }
            return name;
        }

        public async Task<Role> Delete(int id)
        {
            if(_dbContext == null)
            {
                Console.WriteLine("null");
            }
            var rol = await _dbContext.Roles.FindAsync(id);
            if(rol == null)
            {
                return null;
            }
            _dbContext.Roles.Remove(rol);
            await _dbContext.SaveChangesAsync();
            return rol;
        }
    }
}