using Microsoft.EntityFrameworkCore;
using RememberTask.Data;
using RememberTask.Interface;
using RememberTask.Models;

namespace RememberTask.Service
{
    public class ProductService : ICRUD<Product>
    {
        private readonly UsersDBContext _dbContext;
        public ProductService(UsersDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product> GetByID(int id)
        {
            Product product = await _dbContext.Products.FindAsync(id);
            if(product == null)
            {
                Console.WriteLine("null");
                return null;
            }
            return product;
        }

        public async Task<Product> Create(Product name)
        {
            await _dbContext.Products.AddAsync(name);
            await _dbContext.SaveChangesAsync();
            return name;
        }

        private bool ProductAvaiable(int id)
        {
            return (_dbContext.Products?.Any(x => x.ID == id)).GetValueOrDefault();
        }

        public async Task<Product> Update(int id, Product name)
        {
            if(id != name.ID)
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
                if(!ProductAvaiable(id))
                {
                    Console.WriteLine("Error");
                }
                else
                {
                    throw;
                }
            }
            return name;
        }

        public async Task<Product> Delete(int id)
        {
            if(_dbContext == null)
            {
                Console.WriteLine("null");
            }
            var prod = await _dbContext.Products.FindAsync(id);
            if(prod == null)
            {
                return null;
            }
            _dbContext.Products.Remove(prod);
            await _dbContext.SaveChangesAsync();
            return prod;
        }
    }
}