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
    public class CategoryManipulatorTest
    {
        Mock<IUnitOfWork> _uof;
        Mock<IMapper> _mapper;
        CategoryManipulator _manipulator;
        public CategoryManipulatorTest()
        {
            _uof = new Mock<IUnitOfWork>();
            _mapper = new Mock<IMapper>();
            _manipulator = new CategoryManipulator(_uof.Object, _mapper.Object);
        }
        [Fact]
        public void CreateCategory_NormalValues_ReturnsTrues()
        {
            //Arrange
            _uof.Setup(p => p.Categories.CreateAsync(It.IsAny<UnitCategory>())).Returns(Task.CompletedTask);
            _uof.Setup(p => p.SaveAsync()).Returns(Task.CompletedTask);
            _mapper.Setup(p => p.Map<UnitCategory>(It.IsAny<CategoryBLL>())).Returns(new UnitCategory());

            //Act
            var expected = true;
            var result = _manipulator.CreateCategory(new CategoryBLL()).Result;

            //Assert
            _uof.VerifyAll();
            _mapper.VerifyAll();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void UpdateCategory_NormalValues_ReturnsTrues()
        {
            //Arrange
            _uof.Setup(p => p.Categories.UpdateAsync(It.IsAny<UnitCategory>())).Returns(Task.CompletedTask);
            _uof.Setup(p => p.SaveAsync()).Returns(Task.CompletedTask);
            _mapper.Setup(p => p.Map<UnitCategory>(It.IsAny<CategoryBLL>())).Returns(new UnitCategory());

            //Act
            var expected = true;
            var result = _manipulator.UpdateCategory(new CategoryBLL()).Result;

            //Assert
            _uof.VerifyAll();
            _mapper.VerifyAll();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void DeleteCategory_NormalValues_ReturnsTrues()
        {
            //Arrange
            _uof.Setup(p => p.Categories.DeleteAsync(It.IsAny<int>())).Returns(Task.CompletedTask);
            _uof.Setup(p => p.SaveAsync()).Returns(Task.CompletedTask);

            //Act
            var expected = true;
            var result = _manipulator.DeleteCategory(1).Result;

            //Assert
            _uof.VerifyAll();
            _mapper.VerifyAll();
            Assert.Equal(expected, result);
        }
    }
    }
