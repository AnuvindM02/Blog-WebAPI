using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.CategoryFeatures.CreateCategory
{
    public class CreateCategoryResponse
    {
        public Guid Id { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; }
        public DateTimeOffset? DateDeleted { get; set; }
        public string Name { get; set; }
        public string UrlHandle { get; set; }
    }

    public static class CategoryExtensions
    {
        public static CreateCategoryResponse ToCreateCategoryResponse(this Category category)
        {
            return new CreateCategoryResponse { Id = category.Id, Name = category.Name, UrlHandle = category.UrlHandle,DateCreated = category.DateCreated, DateDeleted = category.DateDeleted, DateUpdated = category.DateUpdated };
        }
    }
}
