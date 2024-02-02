using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.RepositoryContracts.BlogPostRepositoryContract
{
    public interface IBlogPostRepository
    {
        /// <summary>
        /// Adds a <see cref="BlogPost"/> to the repository
        /// </summary>
        /// <param name="blogPost"></param>
        /// <returns>Added <see cref="BlogPost"/> item</returns>
        Task<BlogPost> AddBlogPost(BlogPost blogPost);

        /// <summary>
        /// Retrieves all <see cref="BlogPost"/> items
        /// </summary>
        /// <returns>List of <see cref="BlogPost"/></returns>
        Task<List<BlogPost>> GetAllBlogPosts();

        /// <summary>
        /// Retrieves a <see cref="BlogPost"/> item based on the <paramref name="Id"/>
        /// </summary>
        /// <param name="Id"></param>
        /// <returns><see cref="BlogPost"/> item</returns>
        Task<BlogPost?> GetBlogPostById(Guid Id);


        Task<List<BlogPost>> GetBlogPostsById(Guid Id);

        /// <summary>
        /// Updates a <see cref="BlogPost"/> bases on provided <paramref name="blogPost"/>
        /// </summary>
        /// <param name="category"></param>
        /// <returns>Updated <see cref="BlogPost"/> item</returns>
        Task<BlogPost> UpdateBlogPost(BlogPost blogPost);

        /// <summary>
        /// Deletes a <see cref="BlogPost"/> based on <paramref name="Id"/>
        /// </summary>
        /// <param name="Id"></param>
        /// <returns><see cref="bool"/> value indicating whether deletion was successful</returns>
        Task<bool> DeleteBlogPostById(Guid Id);
    }
}
