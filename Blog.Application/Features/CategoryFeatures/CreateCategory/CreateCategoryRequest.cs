using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.CategoryFeatures.CreateCategory
{
    public class CreateCategoryRequest
    {
        [Required(ErrorMessage = "Category name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Url is required")]
        public string UrlHandle { get; set; }

        public Category ToCategory()
        {
            return new Category { Name = Name, UrlHandle = UrlHandle };
        }
    }
}
