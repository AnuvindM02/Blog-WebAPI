using Blog.Application.Common.Helpers;
using Blog.Application.Features.BlogPostFeatures.CreateBlogPost;
using Blog.Application.Features.CategoryFeatures;
using Blog.Application.ServiceContracts.BlogPostServiceContracts;
using Blog.Application.ServiceContracts.CategoryServiceContracts;
using Blog.Domain.Entities;
using Blog.Domain.RepositoryContracts.BlogPostRepositoryContract;
using Blog.Domain.RepositoryContracts.CategoryRepositoryContract;
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
        private readonly ICategoryRepository _categoryRepository;

        public BlogPostAdderService(IBlogPostRepository blogPostRepository, ICategoryRepository categoryRepository)
        {
            _blogPostRepository = blogPostRepository;
            _categoryRepository= categoryRepository;
        }

        public async Task<BlogPostResponse> AddBlogPost(CreateBlogPostRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            ValidationHelper.ModelValidation(request);


            //Maping categoryId into category

            List<Category>? categories = new List<Category>();

            if (request.Categories.Any())
            {
                foreach (Guid categoryId in request.Categories)
                {
                    Category? category = await _categoryRepository.GetCategoryById(categoryId);

                    //If category is found, adding it into the list of categories
                    if (category!=null)
                    {
                        categories.Add(category);
                    }
                }
            }
                
                  
            BlogPost blogPost = request.ToBlogPost();
            blogPost.Id = Guid.NewGuid();
            blogPost.DateCreated = DateTime.Now;
            blogPost.PublishedDate = DateTime.Now;
            blogPost.Categories = categories;

            
            

            await _blogPostRepository.AddBlogPost(blogPost);

            return blogPost.ToBlogPostResponse();
        }
    }
}
