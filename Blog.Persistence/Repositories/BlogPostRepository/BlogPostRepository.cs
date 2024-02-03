using Blog.Domain.Entities;
using Blog.Domain.RepositoryContracts.BlogPostRepositoryContract;
using Blog.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Persistence.Repositories.BlogPostRepository
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<BlogPostRepository> _logger;

        public BlogPostRepository(ApplicationDbContext db, ILogger<BlogPostRepository> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<BlogPost> AddBlogPost(BlogPost blogPost)
        {
            _logger.LogInformation("Adding blog post to the database");
            _db.BlogPosts.Add(blogPost);
            await _db.SaveChangesAsync();
            _logger.LogInformation($"{blogPost.Title} added to the database");
            return blogPost;
        }

        public async Task<bool> DeleteBlogPostById(Guid Id)
        {
            BlogPost? blogPost = await _db.BlogPosts.FindAsync(Id);
            if (blogPost == null)
            {
                return false;
            }

            blogPost.DateDeleted = DateTime.Now;

            DeletedBlogPosts deletedBlogPosts= new DeletedBlogPosts
            {
                Id = blogPost.Id,
                Title = blogPost.Title,
                UrlHandle = blogPost.UrlHandle,
                DateCreated = blogPost.DateCreated,
                DateDeleted = blogPost.DateDeleted,
                DateUpdated = blogPost.DateUpdated,
                Author = blogPost.Author,
                Content = blogPost.Content,
                FeaturedImageUrl = blogPost.FeaturedImageUrl,
                IsVisible = blogPost.IsVisible,
                PublishedDate = blogPost.PublishedDate,
                ShortDescription = blogPost.ShortDescription
            };

            //Adding category to deleted blog posts table
            _db.DeletedBlogPosts.Add(deletedBlogPosts);

            //Removing blog post from blog posts table
            _db.BlogPosts.Remove(blogPost);

            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<List<BlogPost>> GetAllBlogPosts()
        {
            List<BlogPost> blogPosts = await _db.BlogPosts.Include(bp => bp.Categories).OrderByDescending(x => x.DateCreated).ToListAsync();
            return blogPosts;
        }

        public async Task<BlogPost?> GetBlogPostById(Guid Id)
        {
            BlogPost? blogPost = await _db.BlogPosts.Include(bp => bp.Categories).FirstOrDefaultAsync(bp => bp.Id == Id);

            if (blogPost == null)
            {
                _logger.LogInformation("No blog post found");
            }
            else
                _logger.LogInformation("blog post retrieved successfully");
            return blogPost;
        }

        public Task<List<BlogPost>> GetBlogPostsById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<BlogPost> UpdateBlogPost(BlogPost blogPost)
        {
            BlogPost? existingBlogPost= await _db.BlogPosts.FindAsync(blogPost.Id);
            if (existingBlogPost== null)
            {
                throw new ArgumentException($"Blog post with Id {blogPost.Id} does not exist.");
            }

            existingBlogPost.Author = blogPost.Author;
            existingBlogPost.ShortDescription = blogPost.ShortDescription;
            existingBlogPost.Content = blogPost.Content;
            existingBlogPost.FeaturedImageUrl = blogPost.FeaturedImageUrl;
            existingBlogPost.IsVisible = blogPost.IsVisible;
            existingBlogPost.UrlHandle = blogPost.UrlHandle;
            existingBlogPost.Title = blogPost.Title;
            existingBlogPost.DateUpdated = DateTime.Now;

            await _db.SaveChangesAsync();

            return existingBlogPost;
        }
    }
}
