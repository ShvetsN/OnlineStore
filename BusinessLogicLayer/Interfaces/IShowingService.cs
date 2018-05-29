using BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IShowingService
    {
        Task<IEnumerable<ProductBLL>> GetAll();
        Task<IEnumerable<ProductBLL>> GetForCategory(int categoryId);
        Task<IEnumerable<ProductBLL>> Search(string request);
        Task<IEnumerable<ProductBLL>> GetFilter(int min, int max);
    }
}
