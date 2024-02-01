using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.RepositoryContracts.CategoryRepositoryContract
{
    public interface ICategoryRepository
    {
        /// <summary>
        /// Adds a <see cref="Category"/> to the repository
        /// </summary>
        /// <param name="category"></param>
        /// <returns>Added <see cref="Category"/> item</returns>
        Task<Category> AddCategory(Category category);

        /// <summary>
        /// Retrieves all <see cref="Category"/> items
        /// </summary>
        /// <returns>List of <see cref="Category"/></returns>
        Task<List<Category>> GetAllCategories();

        /// <summary>
        /// Retrieves a <see cref="Category"/> item based on the <paramref name="Id"/>
        /// </summary>
        /// <param name="Id"></param>
        /// <returns><see cref="Category"/> item</returns>
        Task<Category?> GetCategoryById(Guid Id);

        /// <summary>
        /// Updates a <see cref="Category"/> bases on provided <paramref name="category"/>
        /// </summary>
        /// <param name="category"></param>
        /// <returns>Updated <see cref="Category"/> item</returns>
        Task<Category> UpdateCategory(Category category);

        /// <summary>
        /// Deletes a <see cref="Category"/> based on <paramref name="Id"/>
        /// </summary>
        /// <param name="Id"></param>
        /// <returns><see cref="bool"/> value indicating whether deletion was successful</returns>
        Task<bool> DeleteCategoryById(Guid Id);
    }
}
