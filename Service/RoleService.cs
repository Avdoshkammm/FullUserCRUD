using Microsoft.EntityFrameworkCore;
using RememberTask.Data;
using RememberTask.Interface;
using RememberTask.Models;

namespace RememberTask.Service
{
    public class RoleService : IRole<Role>
    {
        private readonly UsersDBContext _dbContext;
        public RoleService(UsersDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public async Task<List<Role>> GetAllRole()
        {
            return await _dbContext.Roles.ToListAsync();
        }
        public async Task<Role> GetRoleByID(int id)
        {
            Role role = await _dbContext.Roles.FindAsync(id);
            if (role == null)
            {
                Console.WriteLine("null");
                return null;
            }
            return role;
        }
        public async Task<Role> CreateRole(Role role)
        {
            await _dbContext.Roles.AddAsync(role);
            await _dbContext.SaveChangesAsync();
            return role;
        }

        private bool RoleAvaliable(int id)
        {
            return(_dbContext.Roles?.Any(x => x.Id == id)).GetValueOrDefault();
        }

        public async Task<Role> UpdateRole(int id, Role role)
        {
            if(id != role.Id)
            {
                Console.WriteLine("null");
            }
            _dbContext.Entry(role).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                if (!RoleAvaliable(id))
                {
                    Console.WriteLine(ex.Message.ToString());
                }
                else
                {
                    throw;
                }
            }
            return role;
        }
        public async Task<Role> DeleteRole(int id)
        {
            if(_dbContext == null)
            {
                Console.WriteLine("null to del");
            }
            var ROL = await _dbContext.Roles.FindAsync(id);
            if( ROL == null)
            {
                return null;
            }
            _dbContext.Roles.Remove(ROL);

            await _dbContext.SaveChangesAsync();
            return ROL;
        }
    }
}