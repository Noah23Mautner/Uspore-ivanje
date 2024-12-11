using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Uspoređivanje
{
    internal class Program
    {
        static void Main(string[] args)
        {

            XDocument booksFromFile = XDocument.Load(@"prvi.xml");
            Console.WriteLine("Sadržaj od prvi.xml:");
            Console.WriteLine(booksFromFile);

            XDocument booksFromFile1 = XDocument.Load(@"drugi.xml");
            Console.WriteLine("Sadržaj od drugi.xml:");
            Console.WriteLine(booksFromFile1);

            var prviBooks = booksFromFile.Descendants("book")
               .Select(b => new
               {
                   Id = (string)b.Attribute("id"),
                   Image = (string)b.Attribute("image"),
                   Name = (string)b.Attribute("name")
               }).ToList();

            var drugiBooks = booksFromFile1.Descendants("book")
                .Select(b => new
                {
                    Id = (string)b.Attribute("id"),
                    Image = (string)b.Attribute("image"),
                    Name = (string)b.Attribute("name")
                }).ToList();

            var differentBooks = prviBooks
                .Union(drugiBooks)
                .GroupBy(b => b.Id)
                .Where(g => g.Count() == 1 || g.First().Image != g.Last().Image || g.First().Name != g.Last().Name)
                .SelectMany(g => g)
                .ToList();

            if (differentBooks.Any())
            {
                Console.WriteLine("Razlike između XML dokumenata:");
                foreach (var book in differentBooks)
                {
                    Console.WriteLine($"ID: {book.Id}, Image: {book.Image}, Name: {book.Name}");
                }
            }
            else
            {
                Console.WriteLine("Nema razlika između XML dokumenata.");
            }

            Console.ReadKey();
        }
    }
}
