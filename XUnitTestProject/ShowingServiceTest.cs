using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Interfaces;
using UnitOfWork.Models;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.Models;
using AutoMapper;
using Xunit;
using Moq;

namespace XUnitTestProject
{
    public class ShowingServiceTest
    {
        Mock<IUnitOfWork> _uof;
        Mock<IMapper> _mapper;
        ShowingServices _service;
        public ShowingServiceTest()
        {
            _uof = new Mock<IUnitOfWork>();
            _mapper = new Mock<IMapper>();
            _service = new ShowingServices(_uof.Object, _mapper.Object);
        }
        [Fact]
        public async void GetAll_Returns_allProducts()
        {
            //Arrange
            _uof.Setup(p => p.Products.ReadAllAsync()).ReturnsAsync(await GetAllProducts());

            //Act
            var result = await _service.GetAll() as List<ProductBLL>;

            //Assert
            Assert.Equal(3, result.Count);
        }

        private async Task<List<UnitProduct>> GetAllProducts()
        {
            List<UnitProduct> products = new List<UnitProduct>()
            {
                new UnitProduct
                {
                    Id = 1,
                    Name = "Phone1",
                    Amount = 2
                },
                new UnitProduct
                {
                    Id = 2,
                    Name = "Phone2",
                    Amount = 3
                },
                new UnitProduct
                {
                    Id = 3,
                    Name = "Phone3",
                    Amount = 12
                }
            };
            return products;
        }
    }
}
