using System;
using System.Collections.Generic;
using StringComparerApplication.Services.Interfaces;

namespace StringComparerApplication.Services
{
    public class StringComparerService : IStringComparerService
    {
         public IEnumerable<string> GetAllIndicesOf(string subText, string inputText)
        {   
            for (int index = 0;; index += subText.Length) 
            {
                index = inputText.IndexOf(subText, index,StringComparison.InvariantCultureIgnoreCase);
                if (index == -1)
                    break;
                yield return index.ToString();
            }
        }

        public StringCompareResult ValidateInputString(string inputText, string subText)
        {
            var returnResult = new StringCompareResult(){IsValid=true,Description= new List<string>()};
            //Validate inputs
            if(string.IsNullOrEmpty(inputText) )
            {
             returnResult.IsValid=false;
              returnResult.Description.Add("Input text should not be empty");
            }   

            if(string.IsNullOrEmpty(subText))
            {
                returnResult.IsValid=false;
                returnResult.Description.Add("Sub text should not be empty");
            }
            if(subText.Length>inputText.Length)
            {
                returnResult.IsValid=false;
                returnResult.Description.Add("Sub text is longer than the input text.");
            }
            return returnResult;
        }
    }
}

