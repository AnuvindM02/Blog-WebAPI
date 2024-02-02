using Blog.Application.Features.BlogPostFeatures.CreateBlogPost;
using Blog.Application.Features.CategoryFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.ServiceContracts.BlogPostServiceContracts
{
    public interface IBlogPostGetterService
    {
        /// <summary>
        /// Retrieves all blog posts
        /// </summary>
        /// <returns></returns>
        Task<List<BlogPostResponse>> GetAllBlogPosts();

        /// <summary>
        /// Retrieves <see cref="BlogPostResponse"/> based on <paramref name="id"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns><see cref="BlogPostResponse"/> <see cref="Nullable"/> item</returns>
        Task<BlogPostResponse?> GetBlogPostById(Guid id);
    }
}
