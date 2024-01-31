using Blog.Application.Common.Helpers;
using Blog.Application.Features.CategoryFeatures;
using Blog.Application.Features.CategoryFeatures.CreateCategory;
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
    public class CategoryAdderService : ICategoryAdderService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryAdderService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<CategoryResponse> AddCategory(CreateCategoryRequest request)
        {
            if(request == null) throw new ArgumentNullException(nameof(request));

            ValidationHelper.ModelValidation(request);

            Category category = request.ToCategory();
            category.Id = Guid.NewGuid();
            category.DateCreated = DateTime.Now;

            await _categoryRepository.AddCategory(category);

            return category.ToCreateCategoryResponse();
        }
    }
}
