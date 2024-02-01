using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.Entities;


namespace Blog.Application.ServiceContracts.CategoryServiceContracts
{
    public interface ICategoryDeleterService
    {
        /// <summary>
        /// Deletes <see cref="Category"/> item
        /// </summary>
        /// <param name="Id"> <paramref name="Id"/> of <see cref="Category"/></param>
        /// <returns><see cref="bool"/> indicating whether the deletion was successful</returns>
        Task<bool> DeleteCategoryById(Guid Id);
    }
}
