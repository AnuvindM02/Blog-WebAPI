using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.BlogPostFeatures.CreateBlogPost
{
    public class CreateBlogPostRequest
    {
        [Required(ErrorMessage ="Title can't be blank")]
        public string Title { get; set; } = string.Empty;

        public string? ShortDescription { get; set; }

        [Required(ErrorMessage = "Content can't be blank")]
        public string Content { get; set; } = string.Empty;

        public string? FeaturedImageUrl { get; set; }

        public string? UrlHandle { get; set; }

        [Required(ErrorMessage = "Author can't be blank")]
        public string Author { get; set; } = string.Empty;

        public bool IsVisible { get; set; }

        public List<Guid> Categories { get; set; }

        public BlogPost ToBlogPost()
        {
            return new BlogPost
            {
                Title = Title,
                ShortDescription = ShortDescription,
                Content = Content,
                Author = Author,
                FeaturedImageUrl = FeaturedImageUrl,
                UrlHandle = UrlHandle,
                IsVisible = IsVisible
            };
        }
    }
}
