using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.Entities;

namespace Blog.Application.ServiceContracts.BlogPostServiceContracts
{
    public interface IBlogPostDeleterService
    {
        /// <summary>
        /// Deletes <see cref="BlogPost"/> item
        /// </summary>
        /// <param name="Id"> <paramref name="Id"/> of <see cref="BlogPost"/></param>
        /// <returns><see cref="bool"/> indicating whether the deletion was successful</returns>
        Task<bool> DeleteBlogPostById(Guid Id);
    }
}
