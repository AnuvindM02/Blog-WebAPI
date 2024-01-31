using Blog.Application.Features.CategoryFeatures;
using Blog.Application.Features.CategoryFeatures.CreateCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.ServiceContracts.CategoryServiceContracts
{
    /// <summary>
    /// Services for adding category
    /// </summary>
    public interface ICategoryAdderService
    {
        /// <summary>
        /// Add a category
        /// </summary>
        /// <param name="request"></param>
        /// <returns><see cref="CategoryResponse"/> Class</returns>
        Task<CategoryResponse> AddCategory(CreateCategoryRequest request);
    }
}
