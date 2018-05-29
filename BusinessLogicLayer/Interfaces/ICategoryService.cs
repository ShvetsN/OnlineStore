using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Models;    

namespace BusinessLogicLayer.Interfaces
{
    //In future it will be Generic type
    public interface ICategoryService
    {
        Task<bool> CreateCategory(CategoryBLL category);
        Task<bool> UpdateCategory(CategoryBLL updCategory);
        Task<bool> DeleteCategory(int id);
    }
}
