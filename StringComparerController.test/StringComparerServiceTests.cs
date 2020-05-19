using System;
using Moq;
using NUnit.Framework;
using StringComparerApplication.Controllers;
using System.Linq;
using System.Collections.Generic;
using StringComparerApplication.Services;
using StringComparerApplication.Services.Interfaces;
using StringComparerApplication;
using Microsoft.Extensions.Logging;

namespace StringComparerApplicationTests
{
    public class StringComparerServiceTests
    {
        private IStringComparerService _stringComparerService;
        [SetUp]
        public void Setup()
        { _stringComparerService =  new StringComparerService();
        }
        
        [TestCase(""," ",false)]
        [TestCase("","abcd",false)]
        [TestCase("abcd","",false)]
        [TestCase("abcd","       ",false)]
        [TestCase("abcd","abcdabcdabcd",false)]
        [TestCase("abcd","abcd",true)]
        [TestCase("abcd","abd",true)]
        public void ShouldReturnFalseIfInputsAreNotValid(string inputText, string subText, bool isValid)
        { 
            var result =_stringComparerService.ValidateInputString(inputText,subText);
            Assert.AreEqual(isValid, result.IsValid);
        }



        [TestCase("qbcd","bc",1)]
        [TestCase("bc","bc",1)]
        [TestCase("qbcd qbcdqbcdqbcd","bc",4)]
        [TestCase("qbcd qbcdqbcdqbcd","cd ",1)]
        [TestCase("qbcd qbcdqbcdqbcd ","cd ",2)]
        [TestCase(" bcqbcd qbcdqbcdqbcd "," bc",1)]
        [TestCase(" bcqbcd bcdqbcdqbcd "," bc",2)]
        [TestCase(" bcqbcd bcdqbcdqbcd ","  bc",0)]
        [TestCase(" bcqbcd  bcdqbcdqbcd ","  bc",1)]
        [TestCase(" bcqbcd  bcdqbcdqbcd "," mn",0)]
        public void ShouldReturnIndexIfFound(string inputText, string subText, int numberOfIndices)
        {
            var result =_stringComparerService.GetAllIndicesOf(subText,inputText);
            Assert.AreEqual(numberOfIndices, result.Count());
        }
    }
}