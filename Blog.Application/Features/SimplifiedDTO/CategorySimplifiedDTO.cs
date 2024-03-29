﻿using Blog.Application.Features.CategoryFeatures;
using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.SimplifiedDTO
{
    //DTO for eliminating circular reference with blog post
    public class CategorySimplifiedDTO
    {
        public Guid Id { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; }
        public DateTimeOffset? DateDeleted { get; set; }
        public string Name { get; set; }
        public string UrlHandle { get; set; }
    }

    public static class CategoryExtensionCategorySimplifiedDTO
    {
        public static CategorySimplifiedDTO ToCategorySimplfied(this Category category)
        {
            return new CategorySimplifiedDTO{ Id = category.Id, Name = category.Name, UrlHandle = category.UrlHandle, DateCreated = category.DateCreated, DateDeleted = category.DateDeleted, DateUpdated = category.DateUpdated };
        }
    }
}
