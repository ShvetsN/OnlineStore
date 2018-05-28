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
    public class ProductManipulatorTest
    {
        Mock<IUnitOfWork> _uof;
        Mock<IMapper> _mapper;
        ProductManipulator _manipulator;
        public ProductManipulatorTest()
        {
            _uof = new Mock<IUnitOfWork>();
            _mapper = new Mock<IMapper>();
            _manipulator = new ProductManipulator(_uof.Object, _mapper.Object);
        }
        [Fact]
        public void CreateProduct_NormalValues_ReturnsTrues()
        {
            //Arrange
            _uof.Setup(p => p.Products.CreateAsync(It.IsAny<UnitProduct>())).Returns(Task.CompletedTask);
            _uof.Setup(p => p.SaveAsync()).Returns(Task.CompletedTask);
            _mapper.Setup(p => p.Map<UnitProduct>(It.IsAny<ProductBLL>())).Returns(new UnitProduct());

            //Act
            var expected = true;
            var result = _manipulator.CreateProduct(new ProductBLL()).Result;

            //Assert
            _uof.VerifyAll();
            _mapper.VerifyAll();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void UpdateProduct_NormalValues_ReturnsTrues()
        {
            //Arrange
            _uof.Setup(p => p.Products.UpdateAsync(It.IsAny<UnitProduct>())).Returns(Task.CompletedTask);
            _uof.Setup(p => p.SaveAsync()).Returns(Task.CompletedTask);
            _mapper.Setup(p => p.Map<UnitProduct>(It.IsAny<ProductBLL>())).Returns(new UnitProduct());

            //Act
            var expected = true;
            var result = _manipulator.UpdateProduct(new ProductBLL()).Result;

            //Assert
            _uof.VerifyAll();
            _mapper.VerifyAll();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void DeleteProduct_NormalValues_ReturnsTrues()
        {
            //Arrange
            _uof.Setup(p => p.Products.DeleteAsync(It.IsAny<int>())).Returns(Task.CompletedTask);
            _uof.Setup(p => p.SaveAsync()).Returns(Task.CompletedTask);

            //Act
            var expected = true;
            var result = _manipulator.DeleteProduct(1).Result;

            //Assert
            _uof.VerifyAll();
            _mapper.VerifyAll();
            Assert.Equal(expected, result);
        }
    }
}
