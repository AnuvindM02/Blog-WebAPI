using Blog.Application.Features.CategoryFeatures.CreateCategory;
using Blog.Application.Features.CategoryFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Application.Features.BlogPostFeatures.CreateBlogPost;

namespace Blog.Application.ServiceContracts.BlogPostServiceContracts
{
    public interface IBlogPostAdderService
    {
        /// <summary>
        /// Add a blog post
        /// </summary>
        /// <param name="request"></param>
        /// <returns><see cref="BlogPostResponse"/> Class</returns>
        Task<BlogPostResponse> AddBlogPost(CreateBlogPostRequest request);
    }
}
