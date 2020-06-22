using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestApplication.Interfaces
{
    public interface IFileService<T>
    {
        Task<IEnumerable<T>> ReadAsync(string fileName);
        Task WriteAsync(string fileName, IEnumerable<T> data);
    }
}
