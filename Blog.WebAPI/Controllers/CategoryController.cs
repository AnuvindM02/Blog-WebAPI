﻿using Blog.Application.Features.CategoryFeatures.CreateCategory;
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
            if(!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }
            CreateCategoryResponse response = await _categoryAdderService.AddCategory(request);
            return Ok(response);
        }
    }
}
