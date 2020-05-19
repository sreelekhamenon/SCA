using System;
using Moq;
using NUnit.Framework;
using StringComparerApplication.Controllers;
using System.Linq;
using System.Collections.Generic;
using StringComparerApplication.Services.Interfaces;
using StringComparerApplication;
using Microsoft.Extensions.Logging;

namespace StringComparerApplicationTests
{   
    public class StringComparerControllerTests
    {
        private StringComparerApplication.Controllers.StringComparerController controller;
        private Mock<IStringComparerService> _stringComparerService;
        [SetUp]
        public void Setup()
        { _stringComparerService =  new Mock<IStringComparerService>();
        controller = new StringComparerApplication.Controllers.StringComparerController(null,_stringComparerService.Object);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void ShouldCallGetAllIndicesOnlyIfInputsAreValid(bool isValid)
        {
           
            _stringComparerService.Setup(s=>s.ValidateInputString(It.IsAny<string>(),It.IsAny<string>())).Returns(new StringCompareResult(){IsValid=isValid,Description= new List<string>()});
            _stringComparerService.Setup(s=>s.GetAllIndicesOf(It.IsAny<string>(),It.IsAny<string>())).Returns(new List<string>(){"0","1"});

            var result =controller.Get(It.IsAny<string>(),It.IsAny<string>());

            _stringComparerService.Verify(s => s.ValidateInputString(It.IsAny<string>(),It.IsAny<string>()), Times.Once());
            if(isValid)
            {
              _stringComparerService.Verify(s => s.GetAllIndicesOf(It.IsAny<string>(),It.IsAny<string>()), Times.Once());
                Assert.AreEqual(isValid, result.IsValid);
            }

        }


        [TestCase(true)]
        [TestCase(false)]
        public void ShouldReturnIsValidAsTrueIfIndicesFound(bool isValid)
        {
            _stringComparerService.Setup(s=>s.ValidateInputString(It.IsAny<string>(),It.IsAny<string>())).Returns(new StringCompareResult(){IsValid=true,Description= new List<string>()});
            if(isValid)
            {
             _stringComparerService.Setup(s=>s.GetAllIndicesOf(It.IsAny<string>(),It.IsAny<string>())).Returns(new List<string>(){"0","1"});
            }
            else{
            _stringComparerService.Setup(s=>s.GetAllIndicesOf(It.IsAny<string>(),It.IsAny<string>())).Returns(new List<string>());
            }

            var result =controller.Get(It.IsAny<string>(),It.IsAny<string>());
            Assert.AreEqual(isValid, result.IsValid);
        }
    }
}