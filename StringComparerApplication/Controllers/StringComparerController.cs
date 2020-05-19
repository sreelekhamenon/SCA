using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StringComparerApplication.Services.Interfaces;

namespace StringComparerApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StringComparerController : ControllerBase
    {
         private readonly ILogger<StringComparerController> _logger;
        private readonly IStringComparerService _stringComparerService;

        public StringComparerController(ILogger<StringComparerController> logger, IStringComparerService stringComparerService)
        {
            _logger = logger;
            _stringComparerService = stringComparerService;
        }

        [HttpGet]
        public StringCompareResult Get(string inputText, string subText)
        {
            var returnResult = new StringCompareResult(){IsValid=true,Description= new List<string>()};

            returnResult=_stringComparerService.ValidateInputString(inputText,subText);

             if(returnResult.IsValid)
             {
                 var indices = _stringComparerService.GetAllIndicesOf(subText,inputText);
                 if(indices.Any())
                 {
                    returnResult.Description.AddRange(indices);
                 }
                 else{
                    returnResult.IsValid=false;
                    returnResult.Description.Add("No matching text found.");
                 }
             }

            return returnResult;
        }
        
    }
}
