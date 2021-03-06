﻿using System;
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
    public class OrderManipulatorTest
    {
        Mock<IUnitOfWork> _uof;
        Mock<IMapper> _mapper;
        OrderService _manipulator;
        public OrderManipulatorTest()
        {
            _uof = new Mock<IUnitOfWork>();
            _mapper = new Mock<IMapper>();
            _manipulator = new OrderService(_uof.Object, _mapper.Object);
        }

        #region DecreaseAmountIfValid_MethodTest

        [Fact]
        public async void DecreaseAmountIfValid_NormalValues_UpdatedCollection()
        {
            //Arrange
            _uof.Setup(p => p.Orders.ReadWithProductsAsync(It.IsAny<int>())).ReturnsAsync(await GetUnitOrderWithProducts());

            //Act
            var expected = await GetUpdatedProducts() as List<UnitProduct>;
            var result = await _manipulator.DecreaseAmountIfValid(1) as List<UnitProduct>;

            //Assert
            Assert.Equal(expected.Count, result.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.Equal(expected[i].Amount, result[i].Amount);
            }
        }

        [Fact]
        public async void DecreaseAmountIfValid_AbnormalValues_ReturnNull()
        {
            //Arrange
            _uof.Setup(p => p.Orders.ReadWithProductsAsync(It.IsAny<int>())).ReturnsAsync(await GetUnitOrderWithLackProducts());

            //Act
            var result = await _manipulator.DecreaseAmountIfValid(1) as List<UnitProduct>;

            //Assert
            Assert.Null(result);
        }

        private async Task<UnitOrder> GetUnitOrderWithLackProducts()
        {
            UnitOrder order = new UnitOrder
            {
                Id = 1,
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
                            Amount = 0
                        }
                    }
                }
            };
            return order;
        }

        private async Task<UnitOrder> GetUnitOrderWithProducts()
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

            List<UnitProductOrder> productOrders = new List<UnitProductOrder>()
            {
                new UnitProductOrder
                {
                    OrderId = 1,
                    ProductId = 1,
                    Product = products[0]
                },
                new UnitProductOrder
                {
                    OrderId = 1,
                    ProductId = 1,
                    Product = products[0]
                },
                new UnitProductOrder
                {
                    OrderId = 1,
                    ProductId = 2,
                    Product = products[1]
                },
                new UnitProductOrder
                {
                    OrderId = 1,
                    ProductId = 3,
                    Product = products[2]
                },
            };

            UnitOrder order = new UnitOrder
            {
                Id = 1,
                CustomerId = 1,
                State = OrderState.InProcess,
                Products = productOrders
            };
            
            return order;
        }

        private async Task<IEnumerable<UnitProduct>> GetUpdatedProducts()
        {
            return new List<UnitProduct>
            {
                new UnitProduct
                {
                    Id = 1,
                    Name = "Phone1",
                    Amount = 0
                },
                new UnitProduct
                {
                    Id = 2,
                    Name = "Phone2",
                    Amount = 2
                },
                new UnitProduct
                {
                    Id = 3,
                    Name = "Phone3",
                    Amount = 11
                }
            };
        }

        #endregion

        #region Process_MethodTest
        [Fact]
        public async void Process_NormalValues_TrueAndUpdatedProducts()
        {
            //Arrange
            _uof.Setup(p => p.Orders.ReadWithProductsAsync(It.IsAny<int>())).ReturnsAsync(await GetUnitOrderWithProducts());
            _uof.Setup(p => p.Orders.ReadAsync(It.IsAny<int>())).ReturnsAsync(await GetUnitOrderWithProducts());
            _uof.Setup(p => p.Products.UpdateAsync(It.IsAny<UnitProduct>())).Returns(Task.CompletedTask);
            _uof.Setup(p => p.Orders.AcceptOrder(It.IsAny<int>())).Returns(Task.CompletedTask);
            _uof.Setup(p => p.SaveAsync()).Returns(Task.CompletedTask);

            //Act
            var expected = true;
            var result = await _manipulator.Process(1, true);


            //Assert
            _uof.VerifyAll();
            Assert.Equal(expected, result);
        }
        [Fact]
        public async void Process_ConfirmedOrder_ReturnFalse()
        {
            //Arrange
            _uof.Setup(p => p.Orders.ReadAsync(It.IsAny<int>())).ReturnsAsync(await GetConfirmedUnitOrder());
            
            //Act
            var expected = false;
            var result = await _manipulator.Process(1, true);

            //Assert
            Assert.Equal(result, expected);
        }

        [Fact]
        public async void Process_NoeEnoughProducts_ReturnsFalse()
        {
            //Arrange
            _uof.Setup(p => p.Orders.ReadWithProductsAsync(It.IsAny<int>())).ReturnsAsync(await GetUnitOrderWithLackProducts());
            _uof.Setup(p => p.Orders.ReadAsync(It.IsAny<int>())).ReturnsAsync(await GetUnitOrderWithProducts());
            _uof.Setup(p => p.Orders.DeclineOrder(It.IsAny<int>())).Returns(Task.CompletedTask);
            _uof.Setup(p => p.SaveAsync()).Returns(Task.CompletedTask);

            //Act
            var expected = true;
            var result = await _manipulator.Process(1, true);


            //Assert
            _uof.VerifyAll();
            Assert.Equal(expected, result);
        }

        private async Task<UnitOrder> GetConfirmedUnitOrder()
        {
            return  new UnitOrder { State = OrderState.Confirmed };
        }
        #endregion

        #region CreateOrder
        [Fact]
        public void CreateOrder_NormalValues_ReturnsTrue()
        {
            //Arrange
            _uof.Setup(p => p.Orders.CreateAsync(It.IsAny<UnitOrder>())).Returns(Task.CompletedTask);
            _uof.Setup(p => p.SaveAsync()).Returns(Task.CompletedTask);
            _mapper.Setup(p => p.Map<UnitOrder>(It.IsAny<OrderBLL>())).Returns(new UnitOrder());

            //Act
            var expected = true;
            var order = new OrderBLL
            {
                CustomerId = 1,
                Products = new List<ProductOrderBLL> { new ProductOrderBLL { ProductId = 1 }, new ProductOrderBLL { ProductId = 2 } },
                DeliveryType = TypeOfDeliveryBLL.CourierDelivery
            };
            var result = _manipulator.CreateOrder(order).Result;


            //Assert
            _uof.VerifyAll();
            Assert.Equal(expected, result);
        }
        #endregion

    }
}
