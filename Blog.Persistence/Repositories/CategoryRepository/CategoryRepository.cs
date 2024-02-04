using Blog.Domain.Entities;
using Blog.Domain.RepositoryContracts.CategoryRepositoryContract;
using Blog.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<CategoryRepository> _logger;

        public CategoryRepository(ApplicationDbContext db, ILogger<CategoryRepository> logger)
        {
            _db = db;
            _logger = logger;
        }
        ///<inheritdoc/>
        public async Task<Category> AddCategory(Category category)
        {
            _logger.LogInformation("Adding category to the database");
            _db.Categories.Add(category);
            await _db.SaveChangesAsync();
            _logger.LogInformation($"{category.Name} added to the database");
            return category;
        }

        public async Task<bool> DeleteCategoryById(Guid Id)
        {
            Category? category = await _db.Categories.FindAsync(Id);
            if(category == null)
            {
                return false;
            }

            category.DateDeleted = DateTime.Now;

            DeletedCategory deletedCategory = new DeletedCategory
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle,
                DateCreated = category.DateCreated,
                DateDeleted = category.DateDeleted,
                DateUpdated = category.DateUpdated
            };

            //Adding category to deleted categories table
            _db.DeletedCategories.Add(deletedCategory);

            //Removing category from categories table
            _db.Categories.Remove(category);

            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            List<Category> categories = await _db.Categories.Include(cat => cat.BlogPosts).OrderBy(x => x.UrlHandle).ToListAsync();
            return categories;
        }

        public async Task<Category?> GetCategoryById(Guid Id)
        {
            Category? category = await _db.Categories.Include(cat => cat.BlogPosts).FirstOrDefaultAsync(cat => cat.Id == Id);

            if (category == null)
            {
                _logger.LogInformation("No category found");
            }
            else
                _logger.LogInformation("Order item retrieved successfully");
            return category;
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            Category? existingCategory = await _db.Categories.FindAsync(category.Id);
            if (existingCategory == null)
            {
                throw new ArgumentException($"Category with Id {category.Id} does not exist.");
            }

            existingCategory.UrlHandle = category.UrlHandle;
            existingCategory.Name = category.Name;
            existingCategory.DateUpdated = DateTime.Now;

            await _db.SaveChangesAsync();

            return existingCategory;
        }
    }
}
