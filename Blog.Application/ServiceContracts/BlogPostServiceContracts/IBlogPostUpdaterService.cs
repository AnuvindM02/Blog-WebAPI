using Blog.Application.Features.BlogPostFeatures.CreateBlogPost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.ServiceContracts.BlogPostServiceContracts
{
    public interface IBlogPostUpdaterService
    {
        /// <summary>
        /// Updates an existing <see cref="BlogPost"/>
        /// </summary>
        /// <param name="blogPostUpdateRequest">blog post details to be updated</param>
        /// <returns><see cref="BlogPostResponse"/></returns>
        Task<BlogPostResponse> UpdateBlogPost(BlogPostUpdateRequest blogPostUpdateRequest);
    }
}
