using Blog.Application.ServiceContracts.BlogPostServiceContracts;
using Blog.Domain.RepositoryContracts.BlogPostRepositoryContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Services.BlogPostServices
{
    public class BlogPostDeleterService : IBlogPostDeleterService
    {
        private readonly IBlogPostRepository _blogPostRepository;

        public BlogPostDeleterService(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }

        public async Task<bool> DeleteBlogPostById(Guid Id)
        {
            bool isDeleted = await _blogPostRepository.DeleteBlogPostById(Id);
            return isDeleted;
        }
    }
}
