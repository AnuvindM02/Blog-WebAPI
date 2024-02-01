using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.CategoryFeatures
{
    public class CategoryUpdateRequest
    {
        [Required(ErrorMessage ="Category Id is required")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Category name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Url is required")]
        public string UrlHandle { get; set; }

        public Category ToCategory()
        {
            return new Category { Name = Name, UrlHandle = UrlHandle, Id = Id };
        }
    }

    public static class CategoryExtensionsForUpdate
    {
        public static Category ToCategory(this Category category)
        {
            return new Category { Name = category.Name, UrlHandle = category.UrlHandle };
        }
    }
}
