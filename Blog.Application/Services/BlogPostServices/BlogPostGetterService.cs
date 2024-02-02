using Blog.Application.Features.BlogPostFeatures.CreateBlogPost;
using Blog.Application.Features.CategoryFeatures;
using Blog.Application.ServiceContracts.BlogPostServiceContracts;
using Blog.Domain.Entities;
using Blog.Domain.RepositoryContracts.BlogPostRepositoryContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Services.BlogPostServices
{
    public class BlogPostGetterService : IBlogPostGetterService
    {
        private readonly IBlogPostRepository _blogPostRepository;

        public BlogPostGetterService(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }

        public async Task<List<BlogPostResponse>> GetAllBlogPosts()
        {
            List<BlogPost> blogPosts = await _blogPostRepository.GetAllBlogPosts();
            List<BlogPostResponse> blogPostResponseList = blogPosts.ToBlogPostResponseList();
            return blogPostResponseList;
        }

        public async Task<BlogPostResponse?> GetBlogPostById(Guid id)
        {
            BlogPost? blogPost = await _blogPostRepository.GetBlogPostById(id);
            if (blogPost == null)
            {
                return null;
            }
            BlogPostResponse? blogPostResponse= blogPost.ToBlogPostResponse();
            return blogPostResponse;
        }
    }
}
