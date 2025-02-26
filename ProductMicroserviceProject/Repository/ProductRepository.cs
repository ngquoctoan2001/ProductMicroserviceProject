using Microsoft.EntityFrameworkCore;
using ProductMicroserviceProject.Models;

namespace ProductMicroserviceProject.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;
        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }
        public void DeleteProduct(int productId)
        {
            var product = _context.Products.Find(productId);
            _context.Products.Remove(product);
            Save(); 
        }

        public Product GetProductById(int productId)
        {
            return _context.Products.Find(productId);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public void InsertProduct(Product product)
        {
            _context.Add(product);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            Save();
        }
    }
}
