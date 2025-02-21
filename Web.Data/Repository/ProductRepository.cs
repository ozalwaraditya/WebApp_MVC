using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Web.Data.Data;
using Web.Data.Repository.IRepository;
using Web.Models;

namespace Web.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }
      
        public void Update(Product obj)
        {
            _context.Products.Update(obj);
            return;
        }
    }
}
