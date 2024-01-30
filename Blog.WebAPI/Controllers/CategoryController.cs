using Blog.Application.Features.CategoryFeatures.CreateCategory;
using Blog.Application.ServiceContracts.CategoryServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebAPI.Controllers
{
    public class CategoryController : CustomControllerBase
    {
        private readonly ICategoryAdderService _categoryAdderService;

        public CategoryController(ICategoryAdderService categoryAdderService)
        {
            _categoryAdderService = categoryAdderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequest request)
        {
            CreateCategoryResponse response = _categoryAdderService.AddCategory(request);
            return Ok();
        }
    }
}
