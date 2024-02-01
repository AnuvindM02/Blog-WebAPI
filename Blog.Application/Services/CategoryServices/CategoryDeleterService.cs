using Blog.Application.ServiceContracts.CategoryServiceContracts;
using Blog.Domain.RepositoryContracts.CategoryRepositoryContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Services.CategoryServices
{
    public class CategoryDeleterService : ICategoryDeleterService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryDeleterService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> DeleteCategoryById(Guid Id)
        {
            bool isDeleted = await _categoryRepository.DeleteCategoryById(Id);
            return isDeleted;
        }
    }
}
