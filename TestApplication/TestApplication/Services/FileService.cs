using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TestApplication.Interfaces;

namespace TestApplication.Services
{
    public class TextFileService : IFileService<string>
    {
        public async Task<IEnumerable<string>> ReadAsync(string fileName)
        {
            return await File.ReadAllLinesAsync(fileName);
        }

        public async Task WriteAsync(string fileName, IEnumerable<string> lines)
        {
            using (StreamWriter file = new StreamWriter(fileName))
            {
                foreach (string line in lines)
                {
                    await file.WriteLineAsync(line);
                }
            }
        }
    }
}
