﻿using System;
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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }
      
        public void Update(Category obj)
        {
            _context.Categories.Update(obj);
            return;
        }
    }
}
