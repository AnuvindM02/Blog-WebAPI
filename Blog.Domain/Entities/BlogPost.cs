using Blog.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Entities
{
    public sealed class BlogPost : BaseEntity
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
    }
}
