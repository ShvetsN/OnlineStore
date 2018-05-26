using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Models;

namespace BusinessLogicLayer.Interfaces
{
    public interface IProductManipulator
    {
        Task<bool> CreateProduct(ProductBLL product);
        Task<bool> UpdateProduct(ProductBLL updProduct);
        Task<bool> DeleteProduct(int id);   
    }
}
