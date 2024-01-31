﻿using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.RepositoryContracts.CategoryRepositoryContract
{
    public interface ICategoryRepository
    {
        Task<Category> AddCategory(Category category);
        Task<List<Category>> GetAllCategories();
    }
}
