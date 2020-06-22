using System.Collections.Generic;

namespace TestApplication.Interfaces
{
    public interface IParseService
    {
        public IEnumerable<string> TransformInputData(IEnumerable<string> data);
        public IEnumerable<string> TransfromOutputData(Dictionary<string, IEnumerable<string>> data);
    }
}
