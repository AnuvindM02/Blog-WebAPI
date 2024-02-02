using Blog.Application.Common.Helpers;
using Blog.Application.Features.BlogPostFeatures.CreateBlogPost;
using Blog.Application.ServiceContracts.BlogPostServiceContracts;
using Blog.Domain.Entities;
using Blog.Domain.RepositoryContracts.BlogPostRepositoryContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Services.BlogPostServices
{
    public class BlogPostAdderService : IBlogPostAdderService
    {
        private readonly IBlogPostRepository _blogPostRepository;

        public BlogPostAdderService(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }

        public async Task<BlogPostResponse> AddBlogPost(CreateBlogPostRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            ValidationHelper.ModelValidation(request);

            BlogPost blogPost = request.ToBlogPost();
            blogPost.Id = Guid.NewGuid();
            blogPost.DateCreated = DateTime.Now;
            blogPost.PublishedDate = DateTime.Now;
            

            await _blogPostRepository.AddBlogPost(blogPost);

            return blogPost.ToBlogPostResponse();
        }
    }
}
