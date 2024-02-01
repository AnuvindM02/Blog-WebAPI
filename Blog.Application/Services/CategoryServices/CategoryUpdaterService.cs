using Blog.Application.Features.CategoryFeatures;
using Blog.Application.ServiceContracts.CategoryServiceContracts;
using Blog.Domain.Entities;
using Blog.Domain.RepositoryContracts.CategoryRepositoryContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Services.CategoryServices
{
    public class CategoryUpdaterService : ICategoryUpdaterService
    {
        private readonly ICategoryRepository _categoryRespository;

        public CategoryUpdaterService(ICategoryRepository categoryRespository)
        {
            _categoryRespository = categoryRespository;
        }

        public async Task<CategoryResponse> UpdateCategory(CategoryUpdateRequest categoryUpdateRequest)
        {
            Category category = categoryUpdateRequest.ToCategory();
            Category updatedCategory = await _categoryRespository.UpdateCategory(category);
            CategoryResponse updatedCategoryResponse = updatedCategory.ToCategoryResponse();
            return updatedCategoryResponse;
        }
    }
}
