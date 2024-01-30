using Blog.Application.Features.CategoryFeatures.CreateCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.ServiceContracts.CategoryServiceContracts
{
    public interface ICategoryAdderService
    {
        Task<CreateCategoryResponse> AddCategory(CreateCategoryRequest request);
    }
}
