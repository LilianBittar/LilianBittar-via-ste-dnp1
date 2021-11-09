using System;
using System.Linq;
using Library.Models;
using Library.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Library
{
    class Program
    {

        private static void AddBookGenreAuthor()
        {
            Genres g = new Genres()
            {
                GenreName = "High Fantasy"
            };

            Author a = new Author()
            {
                FirstName = "Brandon",
                LastName = "Sanderson",
                Bio = "I write good stuff"
            };

            Books b = new Books()
            {
                Author = a,
                Genres = g,
                Title = "The way of kings",
                ISBN = 765326353,
                PublishDate = new DateTime(2010, 7, 31),
                TotalPages = 1007
            };
            using (LibraryContext lb = new LibraryContext())
            {
                lb.Books.Add(b);
                lb.SaveChanges();
            }
        }

        private static void AddAuthor()
        {
            Author a = new Author
            {
                FirstName = "Stephen",
                LastName = "King",
                Bio = "I am pretty famous"
            };
            using (LibraryContext lb = new LibraryContext())
            {
                lb.Authors.Add(a);
                lb.SaveChanges();
            }
        }

        private static void AddBookToAuthor()
        {
            using (LibraryContext lb = new LibraryContext())
            {
                Author a = lb.Authors.First(a => a.FirstName.Equals("Stephen") && a.LastName.Equals("King"));
                Books b = new Books
                {
                    Author = a,
                    Title = "The shining",
                    ISBN = 0450040186,
                    PublishDate = new DateTime(1980, 1, 28),
                    TotalPages = 659
                };
                lb.Books.Add(b);
                lb.SaveChanges();
            }
        }

        private static void GetBook()
        {
            using (LibraryContext lb = new LibraryContext())
            {
                Books first = lb.Books.Where(B => B.ISBN == 765326353).First();
                Console.WriteLine(first);
            }
        }

        private static void GetBookAndAll()
        {
            using (LibraryContext lb = new LibraryContext())
            {
                Books first = lb.Books.Include(books => books.Author).Include(books => books.Genres)
                    .First(books => books.ISBN == 765326353);
                Console.WriteLine(first);
            }
        }
        static void Main(string[] args)
        {
            //AddBookGenreAuthor();
            //AddAuthor();
            //AddBookToAuthor();
            GetBookAndAll();
        }
    }
}