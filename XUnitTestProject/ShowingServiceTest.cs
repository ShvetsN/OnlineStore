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
        ShowingService _service;
        public ShowingServiceTest()
        {
            _uof = new Mock<IUnitOfWork>();
            _mapper = new Mock<IMapper>();
            _service = new ShowingService(_uof.Object, _mapper.Object);
        }
        [Fact]
        public async void GetAll_Returns_allProducts()
        {
            //Arrange
            _uof.Setup(p => p.Products.ReadAllAsync()).ReturnsAsync(await GetAllProducts());
            _mapper.Setup(m => m.Map<IEnumerable<ProductBLL>>(It.IsAny<IEnumerable<UnitProduct>>())).Returns(await GetAllProductsInBll());

            //Act
            var result = await _service.GetAll() as List<ProductBLL>;
            
            //Assert
            Assert.Equal(5, result.Count);
        }

        [Fact]
        public async void GetForCategory_Returns_allProductsInCategory()
        {
            //Arrange
            _uof.Setup(p => p.Products.ReadAllAsync()).ReturnsAsync(await GetAllProducts());
            _mapper.Setup(m => m.Map<IEnumerable<ProductBLL>>(It.IsAny<IEnumerable<UnitProduct>>())).Returns(await GetAllProductsWithCAtegory());

            //Act
            var result = await _service.GetForCategory(1) as List<ProductBLL>;

            //Assert
            Assert.Equal(2, result.Count);
        }

        //[Fact]
        //public async void Search_Returns_allProductsThatMatch()
        //{
        //    //Arrange
        //    _uof.Setup(p => p.Products.ReadAllAsync()).ReturnsAsync(await GetAllProducts());

        //    //Act
        //    var result = await _service.Search("Phone") as List<ProductBLL>;

        //    //Assert
        //    Assert.Equal(5, result.Count);
        //}

        [Fact]
        public async void GetFilter_Returns_allProductsThatMatch()
        {
            //Arrange
            _uof.Setup(p => p.Products.ReadAllAsync()).ReturnsAsync(await GetAllProducts());
            _mapper.Setup(m => m.Map<IEnumerable<ProductBLL>>(It.IsAny<IEnumerable<UnitProduct>>())).Returns(await GetAllProductsWithCost());

            //Act
            var result = await _service.GetFilter(70, 230) as List<ProductBLL>;

            //Assert
            Assert.Equal(2, result.Count);
        }

        private async Task<List<UnitProduct>> GetAllProducts()
        {
            return new List<UnitProduct>()
            {
                new UnitProduct
                {
                    Id = 1,
                    Name = "Phone1",
                    CategoryId = 2,
                    Price = 10,
                    Amount = 2
                },
                new UnitProduct
                {
                    Id = 2,
                    Name = "Phone2",
                    CategoryId = 2,
                    Price = 50,
                    Amount = 2
                },
                new UnitProduct
                {
                    Id = 3,
                    Name = "Phone3",
                    CategoryId = 2,
                    Price = 250,
                    Amount = 2
                },
                new UnitProduct
                {
                    Id = 4,
                    Name = "Phone4",
                    CategoryId = 1,
                    Price = 200,
                    Amount = 3
                },
                new UnitProduct
                {
                    Id = 5,
                    Name = "Phone5",
                    CategoryId = 1,
                    Price = 100,
                    Amount = 12
                }
            };
        }

        private async Task<List<ProductBLL>> GetAllProductsInBll()
        {
            return new List<ProductBLL>()
            {
                new ProductBLL
                {
                    Id = 1,
                    Name = "Phone1",
                    CategoryId = 2,
                    Price = 10,
                    Amount = 2
                },
                new ProductBLL
                {
                    Id = 2,
                    Name = "Phone2",
                    CategoryId = 2,
                    Price = 50,
                    Amount = 2
                },
                new ProductBLL
                {
                    Id = 3,
                    Name = "Phone3",
                    CategoryId = 2,
                    Price = 250,
                    Amount = 2
                },
                new ProductBLL
                {
                    Id = 4,
                    Name = "Phone4",
                    CategoryId = 1,
                    Price = 200,
                    Amount = 3
                },
                new ProductBLL
                {
                    Id = 5,
                    Name = "Phone5",
                    CategoryId = 1,
                    Price = 100,
                    Amount = 12
                }
            };
        }

        private async Task<List<ProductBLL>> GetAllProductsWithCAtegory()
        {
            return new List<ProductBLL>()
            { 
                new ProductBLL
                {
                    Id = 4,
                    Name = "Phone4",
                    CategoryId = 1,
                    Price = 200,
                    Amount = 3
                },
                new ProductBLL
                {
                    Id = 5,
                    Name = "Phone5",
                    CategoryId = 1,
                    Price = 100,
                    Amount = 12
                }
            };
        }

        private async Task<List<ProductBLL>> GetAllProductsWithCost()
        {
            return new List<ProductBLL>()
            {
                new ProductBLL
                {
                    Id = 4,
                    Name = "Phone4",
                    CategoryId = 1,
                    Price = 200,
                    Amount = 3
                },
                new ProductBLL
                {
                    Id = 5,
                    Name = "Phone5",
                    CategoryId = 1,
                    Price = 100,
                    Amount = 12
                }
            };
        }
    }
}
