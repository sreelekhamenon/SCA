using System.Collections.Generic;

namespace StringComparerApplication.Services.Interfaces
{
    public interface IStringComparerService
    {
        StringCompareResult ValidateInputString(string inputText, string subText);
        IEnumerable<string> GetAllIndicesOf(string subText, string inputText);
    }
}

