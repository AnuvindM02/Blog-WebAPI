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
    ///<inheritdoc/>
    public class CategoryGetterService : ICategoryGetterService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryGetterService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        /// <summary>
        /// Retrieve all categories
        /// </summary>
        /// <returns></returns>
        public async Task<List<CategoryResponse>> GetAllCategories()
        {
            List<Category> categories = await _categoryRepository.GetAllCategories();
            List<CategoryResponse> categoriesResponseList = categories.ToCategoryResponseList();
            return categoriesResponseList;
        }

        public async Task<CategoryResponse?> GetCategoryById(Guid id)
        {
            Category? category = await _categoryRepository.GetCategoryById(id);
            if(category==null)
            {
                return null;
            }
            CategoryResponse? categoryResponse = category.ToCategoryResponse();
            return categoryResponse;
        }
    }
}
