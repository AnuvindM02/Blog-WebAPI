using Blog.Domain.Entities;
using Blog.Domain.RepositoryContracts.CategoryRepositoryContract;
using Blog.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Persistence.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public Category AddCategory(Category category)
        {
            _db.Add(category);
            _db.SaveChanges();
            return category;
        }
    }
}
