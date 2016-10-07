using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    class BookShop
    {
        static void Main(string[] args)
        {
            Book book = new Book("Regular Book", "Generic author", 90M);
            GogldenEditionBook superbook = new GogldenEditionBook("Golden Book", "Paulo Koehlo", 100M);
            Console.WriteLine(book);
            Console.WriteLine(superbook);
        }
    }
}
