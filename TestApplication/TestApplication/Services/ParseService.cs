using System.Collections.Generic;
using System.Data;
using System.Linq;
using TestApplication.Common;
using TestApplication.Interfaces;

namespace TestApplication.Services
{
    public class ParseService : IParseService
    {
        public IEnumerable<string> TransformInputData(IEnumerable<string> data)
        {
            data = RemoveFirstRow(data);
            data = data.Select(d => d.ToLower());

            var result = data.Select(line =>
            {
                var split = line.Split('\t');
                return split[1];
             });

            return result;
        }

        public IEnumerable<string> TransfromOutputData(Dictionary<string, IEnumerable<string>> data)
        {
            var result = new List<string>();
            AddFirstRow(result);

            foreach (var item in data)  
            {
                var countOfWords = item.Value.Count();
                var firstPart = countOfWords > 1 ? item.Value.GetAllItemsWithComa() : item.Key;
                var secondPart = countOfWords > 1 ? $"разбили на {countOfWords} части" : "невозможно разбить";
                var line = $"de\t{firstPart} // {secondPart}"; 
                result.Add(line);
            }

            return result;
        }

        private void AddFirstRow(List<string> lines)
        {
            var row = "ss\tcountry";
            lines.Add(row);
        }

        private IEnumerable<string> RemoveFirstRow(IEnumerable<string> lines)
        {
           return lines.Skip(1);
        }
    }
}
