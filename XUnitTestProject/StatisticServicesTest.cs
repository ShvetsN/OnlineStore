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
    public class StatisticServicesTest
    {
        Mock<IUnitOfWork> _uof;
        Mock<IMapper> _mapper;
        StatisticServices _service;
        public StatisticServicesTest()
        {
            _uof = new Mock<IUnitOfWork>();
            _mapper = new Mock<IMapper>();
            _service = new StatisticServices(_uof.Object, _mapper.Object);
        }

        [Fact]
        public async void GetOrdersOfSpecialDay_Returns_ListOfProducts()
        {
            //Arrange
            _uof.Setup(p => p.Orders.ReadAllAsync()).Returns( GetAllOrders());
            _mapper.Setup(m => m.Map<IEnumerable<OrderBLL>>(It.IsAny<IEnumerable<UnitOrder>>())).Returns(await GetAllOrdersWithDate());

            //Act
            var result = await _service.GetOrdersOfSpecialDay(new DateTime(2018, 5, 28)) as List<OrderBLL>;

            //Assert
            Assert.Equal(1, result.Count);
        }

        private async Task<IEnumerable<UnitOrder>> GetAllOrders()
        {
            return  new List<UnitOrder> {
            new UnitOrder
            {
                Id = 1,
                Date = new DateTime(2018, 5, 28),
                CustomerId = 1,
                Products = new List<UnitProductOrder>
                {
                    new UnitProductOrder
                    {
                        OrderId = 1,
                        ProductId = 1,
                        Product = new UnitProduct
                        {
                            Id = 1,
                            Amount = 10
                        }
                    }
                }
            },
            new UnitOrder
            {
                Id = 2,
                CustomerId = 2,
                Date = new DateTime(2018, 7, 28),
                Products = new List<UnitProductOrder>
                {
                    new UnitProductOrder
                    {
                        OrderId = 2,
                        ProductId = 3,
                        Product = new UnitProduct
                        {
                            Id = 3,
                            Amount = 10
                        }
                    }
                }
            }
        };
        }
        private async Task<IEnumerable<OrderBLL>> GetAllOrdersWithDate()
        {
            return new List<OrderBLL> {
            new OrderBLL
            {
                Id = 1,
                Date = new DateTime(2018, 5, 28),
                CustomerId = 1,
                Products = new List<ProductOrderBLL>
                {
                    new ProductOrderBLL
                    {
                        OrderId = 1,
                        ProductId = 1,
                        Product = new ProductBLL
                        {
                            Id = 1,
                            Amount = 10
                        }
                    }
                }
            }

            };
        }
    }
}
