using Blog.Application.Features.CategoryFeatures;
using Blog.Application.Features.CategoryFeatures.CreateCategory;
using Blog.Application.ServiceContracts.CategoryServiceContracts;
using Blog.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebAPI.Controllers
{
    public class CategoriesController : CustomControllerBase
    {
        private readonly ICategoryAdderService _categoryAdderService;
        private readonly ICategoryGetterService _categoryGetterService;
        private readonly ICategoryDeleterService _categoryDeleterService;
        private readonly ICategoryUpdaterService _categoryUpdaterService;

        public CategoriesController(ICategoryAdderService categoryAdderService, ICategoryGetterService categoryGetterService,
            ICategoryDeleterService categoryDeleterService,ICategoryUpdaterService categoryUpdaterService)
        {
            _categoryAdderService = categoryAdderService;
            _categoryGetterService = categoryGetterService;
            _categoryDeleterService = categoryDeleterService;
            _categoryUpdaterService = categoryUpdaterService;
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

        [HttpGet("{Id}")]
        public async Task<ActionResult> GetCategoryById([FromRoute]Guid Id)
        {
            CategoryResponse? categoryResponse = await _categoryGetterService.GetCategoryById(Id);
            if(categoryResponse == null)
            {
                return Problem(statusCode: 404, title: "Not Found", detail: $"Category with ID {Id} was not found.");
            }
            return Ok(categoryResponse);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult> UpdateCategory(CategoryUpdateRequest categoryUpdateRequest, Guid Id)
        {
            if(Id!=categoryUpdateRequest.Id)
                return BadRequest("Id doesn't match");

            CategoryResponse updatedOrderItem = await _categoryUpdaterService.UpdateCategory(categoryUpdateRequest);
            return Ok(updatedOrderItem);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteCategory(Guid Id)
        {
            var isDeleted = await _categoryDeleterService.DeleteCategoryById(Id);
            if(!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
