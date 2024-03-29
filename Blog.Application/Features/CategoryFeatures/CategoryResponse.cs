﻿using Blog.Application.Features.BlogPostFeatures.CreateBlogPost;
using Blog.Application.Features.SimplifiedDTO;
using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.CategoryFeatures
{
    public class CategoryResponse
    {
        public Guid Id { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; }
        public DateTimeOffset? DateDeleted { get; set; }
        public string Name { get; set; }
        public string UrlHandle { get; set; }
        public ICollection<BlogPostSimplifiedDTO>? BlogPosts { get; set; }

        public Category ToCategory()
        {
            return new Category
            {
                Id = Id,
                DateCreated = DateCreated,
                DateUpdated = DateUpdated,
                Name = Name,
                UrlHandle = UrlHandle,
                DateDeleted = DateDeleted
            };
        }
    }

    public static class CategoryExtensions
    {
        /// <summary>
        /// Converts <see cref="Category"/> object into <see cref="CategoryResponse"/> object
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public static CategoryResponse ToCategoryResponse(this Category category)
        {
            return new CategoryResponse { Id = category.Id, Name = category.Name, UrlHandle = category.UrlHandle, DateCreated = category.DateCreated, DateDeleted = category.DateDeleted, DateUpdated = category.DateUpdated,
            BlogPosts = category.BlogPosts.Select(bp=>bp.ToBlogPostSimplfied()).ToList()};
        }

        /// <summary>
        /// Converts <see cref="Category"/> object into List of <see cref="CategoryResponse"/>
        /// </summary>
        /// <param name="categories"></param>
        /// <returns>List of <see cref="CategoryResponse"/></returns>
        public static List<CategoryResponse> ToCategoryResponseList(this List<Category> categories)
        {
            List<CategoryResponse> categoryResponses = new List<CategoryResponse>();
            foreach (Category category in categories)
            {
                categoryResponses.Add(category.ToCategoryResponse());
            }
            return categoryResponses;
        }
    }
}
