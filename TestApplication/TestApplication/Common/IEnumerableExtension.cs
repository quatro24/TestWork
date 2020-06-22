using System.Collections.Generic;

namespace TestApplication.Common
{
    public static class IEnumerableExtension
    {
        public static string GetAllItemsWithComa(this IEnumerable<string> items)
        {
            return string.Join(", ", items);
        }
    }
}
