using Blog.Application.Features.CategoryFeatures;
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
        Task<List<CategoryResponse>> GetAllCategories();
    }
}
