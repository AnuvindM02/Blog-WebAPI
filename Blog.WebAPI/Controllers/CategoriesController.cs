using Blog.Application.Features.CategoryFeatures;
using Blog.Application.Features.CategoryFeatures.CreateCategory;
using Blog.Application.ServiceContracts.CategoryServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebAPI.Controllers
{
    public class CategoriesController : CustomControllerBase
    {
        private readonly ICategoryAdderService _categoryAdderService;
        private readonly ICategoryGetterService _categoryGetterService;

        public CategoriesController(ICategoryAdderService categoryAdderService, ICategoryGetterService categoryGetterService)
        {
            _categoryAdderService = categoryAdderService;
            _categoryGetterService = categoryGetterService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequest request)
        {
            if(!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }
            CategoryResponse response = await _categoryAdderService.AddCategory(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            List<CategoryResponse> categoryResponseList = await _categoryGetterService.GetAllCategories();
            return Ok(categoryResponseList);
        }
    }
}
