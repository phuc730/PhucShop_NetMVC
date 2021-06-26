using PhucShop.ViewModels.Catalog.Category;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhucShop.Application.Catalog.Categories
{
    public interface IcategoryService
    {
        Task<List<CategoryViewModel>> GetAll(string languageId);
    }
}