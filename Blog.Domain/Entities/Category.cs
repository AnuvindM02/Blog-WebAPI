using Blog.Domain.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Entities
{
    public sealed class Category : BaseEntity
    {
        public string Name { get; set; }
        public string UrlHandle { get; set; }

        public ICollection<BlogPost> BlogPosts { get; set; } = new List<BlogPost>();
    }
}
