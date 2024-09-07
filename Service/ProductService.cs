using Microsoft.EntityFrameworkCore;
using RememberTask.Data;
using RememberTask.Interface;
using RememberTask.Models;

namespace RememberTask.Service
{
    public class ProductService : IProduct<Product>
    {
        private readonly UsersDBContext _dbContext;
        public ProductService(UsersDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public async Task<List<Product>> GetAllProduct()
        {
            return await _dbContext.Products.ToListAsync();
        }
        public async Task<Product> GetProductByID(int id)
        {
            Product product = await _dbContext.Products.FindAsync(id);
            if(product == null)
            {
                Console.WriteLine("null");
                return null;
            }
            return product;
        }
        public async Task<Product> CreateProduct(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }

        private bool ProductAvaliable(int id)
        {
            return (_dbContext.Products?.Any(x => x.ID == id)).GetValueOrDefault();
        }
        public async Task<Product> UpdateProduct(int id, Product product)
        {
            if(id != product.ID)
            {
                Console.WriteLine("null");
            }
            _dbContext.Entry(product).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                if(!ProductAvaliable(id))
                {
                    Console.WriteLine(ex.Message.ToString());
                }
                else
                {
                    throw;
                }
            }
            return product;
        }
        public async Task<Product> DeleteProduct(int id)
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