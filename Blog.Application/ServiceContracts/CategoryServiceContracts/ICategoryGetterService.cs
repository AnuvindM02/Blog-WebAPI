using Blog.Application.Features.CategoryFeatures;
using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.ServiceContracts.CategoryServiceContracts
{
    /// <summary>
    /// Service for retrieving categories
    /// </summary>
    public interface ICategoryGetterService
    {
        /// <summary>
        /// Retrieves all categories
        /// </summary>
        /// <returns></returns>
        Task<List<CategoryResponse>> GetAllCategories();

        /// <summary>
        /// Retrieves <see cref="CategoryResponse"/> based on <paramref name="id"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns><see cref="CategoryResponse"/> <see cref="Nullable"/> item</returns>
        Task<CategoryResponse?> GetCategoryById(Guid id);
    }
}
