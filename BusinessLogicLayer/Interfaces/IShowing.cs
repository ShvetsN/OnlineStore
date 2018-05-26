using BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    interface IShowing
    {
        Task<IEnumerable<ProductBLL>> GetAll();
        Task<IEnumerable<ProductBLL>> GetForCategory(string category);
        Task<IEnumerable<ProductBLL>> Search(string request);
        Task<IEnumerable<ProductBLL>> GetFilter(int min, int max);
    }
}
