using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.BlogPostFeatures.CreateBlogPost
{
    public class BlogPostResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? ShortDescription { get; set; }
        public string Content { get; set; }
        public string? FeaturedImageUrl { get; set; }
        public string? UrlHandle { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Author { get; set; }
        public bool IsVisible { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; }
        public DateTimeOffset? DateDeleted { get; set; }
    }

    public static class BlogPostExtensions
    {
        public static BlogPostResponse ToBlogPostResponse(this BlogPost blogPost)
        {
            return new BlogPostResponse
            {
                Id = blogPost.Id,
                Title = blogPost.Title,
                ShortDescription = blogPost.ShortDescription,
                Content = blogPost.Content,
                FeaturedImageUrl = blogPost.FeaturedImageUrl,
                UrlHandle = blogPost.UrlHandle,
                PublishedDate = blogPost.PublishedDate,
                Author = blogPost.Author,
                DateCreated = blogPost.DateCreated,
                DateDeleted = blogPost.DateDeleted,
                DateUpdated = blogPost.DateUpdated
            };
        }

        public static List<BlogPostResponse> ToBlogPostResponseList(this List<BlogPost> blogPosts)
        {
            List<BlogPostResponse> blogPostResponses = blogPosts.Select(x=>x.ToBlogPostResponse()).ToList();
            return blogPostResponses;
        }
    }
}
