using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFProject
{
    public static class BookRepository
    {
        private static AppContext db;
        public static bool IsEmpty()
        {
            using (db = new AppContext())
            {
                return db.Books.Count() == 0;
            }
        }
        public static void AddBook(Book book)
        {
            using (db = new AppContext())
            {
                db.Books.Add(book);
                db.SaveChanges();
            }
        }

        public static void AddBookRange(IEnumerable<Book> books)
        {
            using (db = new AppContext())
            {
                db.Books.AddRange(books);
                db.SaveChanges();
            }
        }

        public static List<Book> GetAllBooks()
        {
            using (db = new AppContext())
            {
                var allBooks = db.Books.ToList();
                return allBooks;
            }
        }

        public static Book GetBookById(int id)
        {
            using (db = new AppContext())
            {
                var book = db.Books.FirstOrDefault(book => book.Id == id);
                return book;
            }
        }

        public static void DeleteBookById(int id)
        {
            using (db = new AppContext())
            {
                var book = db.Books.FirstOrDefault(book => book.Id == id);
                if (book != null)
                    db.Books.Remove(book);
                else throw new Exception($"Книга с Id {id} не существует");
                db.SaveChanges();
            }
        }

        public static void UpdateBookYearById(int id, int year)
        {
            using (db = new AppContext())
            {
                var book = db.Books.FirstOrDefault(b => b.Id == id);
                if(book != null)
                    book.Year = year;
                else throw new Exception($"Книга с Id {id} не существует");                
                db.SaveChanges();
            }
        }

        public static List<Book> GetBooksByGenreAndYears(string genre, int firstYear, int lastYear)
        {
            using (db = new AppContext())
            {
                var books = db.Books.Where(b => (b.Genre.ToLower() == genre.ToLower()) && b.Year >= firstYear && b.Year <= lastYear ).ToList();
                return books;
            }
        }

        public static int CountOfBooksByAuthor(string author)
        {
            using (db = new AppContext())
            {
                int count = db.Books.Count(b => b.Author.Contains(author));
                return count;
            }
        }

        public static int CountOfBooksByGenre(string genre)
        {
            using (db = new AppContext())
            {
                int count = db.Books.Count(b => b.Genre.ToLower() == genre.ToLower());
                return count;
            }
        }

        public static bool ContainsByAuthorAndByTitle(string author, string title)
        {
            using (db = new AppContext())
            {
                bool flag = db.Books.Any(b => b.Author.Contains(author) && b.Title == title);
                return flag;
            }
        }

        public static bool ChekBookOnHands(int id)
        {
            using (db = new AppContext())
            {
                var book = db.Books.FirstOrDefault(book => book.Id == id);
                bool flag = (bool)book?.UserId.HasValue;
                return flag;
            }
        }

        public static int CountOfBooksOnHands()
        {
            using (db = new AppContext())
            {
                var count = db.Books.Count(b => b.UserId.HasValue);
                return count;
            }
        }

        public static Book GetBookLastYear()
        {
            using (db = new AppContext())
            {
                var book = db.Books.First(b => b.Year == db.Books.Max(b => b.Year));
                return book;
            }
        }

        public static List<Book> GetAllBooksOrderedByTitle()
        {
            using (db = new AppContext())
            {
                var books = db.Books.OrderBy(b => b.Title).ToList();
                return books;
            }
        }

        public static List<Book> GetAllBooksOrderedByYearDesc()
        {
            using (db = new AppContext())
            {
                var books = db.Books.OrderByDescending(b => b.Year).ToList();
                return books;
            }
        }

    }
}
