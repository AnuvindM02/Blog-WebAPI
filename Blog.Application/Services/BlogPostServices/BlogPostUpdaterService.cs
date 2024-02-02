using Blog.Application.Common.Helpers;
using Blog.Application.Features.BlogPostFeatures.CreateBlogPost;
using Blog.Application.Features.CategoryFeatures;
using Blog.Application.ServiceContracts.BlogPostServiceContracts;
using Blog.Domain.Entities;
using Blog.Domain.RepositoryContracts.BlogPostRepositoryContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Services.BlogPostServices
{
    public class BlogPostUpdaterService : IBlogPostUpdaterService
    {
        private readonly IBlogPostRepository _blogPostRepository;

        public BlogPostUpdaterService(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }

        public async Task<BlogPostResponse> UpdateBlogPost(BlogPostUpdateRequest blogPostUpdateRequest)
        {
            if (blogPostUpdateRequest == null) throw new ArgumentNullException(nameof(blogPostUpdateRequest));

            ValidationHelper.ModelValidation(blogPostUpdateRequest);

            BlogPost blogPost = blogPostUpdateRequest.ToBlogPost();
            BlogPost updatedBlogPost= await _blogPostRepository.UpdateBlogPost(blogPost);
            BlogPostResponse updatedBlogPostResponse = updatedBlogPost.ToBlogPostResponse();
            return updatedBlogPostResponse;
        }
    }
}
