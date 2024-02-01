using Blog.Application.Features.CategoryFeatures;
using Blog.Domain.Entities;

namespace Blog.Application.ServiceContracts.CategoryServiceContracts
{
    public interface ICategoryUpdaterService
    {
        /// <summary>
        /// Updates an existing <see cref="Category"/>
        /// </summary>
        /// <param name="categoryUpdateRequest">Category details to be updated</param>
        /// <returns><see cref="CategoryResponse"/></returns>
        Task<CategoryResponse> UpdateCategory(CategoryUpdateRequest categoryUpdateRequest);
    }
}
