using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uspoređivanje
{
    internal class Book
    {
        
        public int BookID { get; set; }
        public String Name { get; set; }
        public int Image { get; set; }
        public Book(int bookId, string name, int image)
        {
            this.BookID = bookId;
            this.Name = name;
            this.Image = image;
        }
    }
}
