using System;
using System.Collections.Generic;
using System.Linq;

namespace LB4
{
    internal class Library
    {
        private readonly List<Book> _books = new List<Book>();
        private readonly List<User> _users = new List<User>();

        public void AddBook(Book book) => _books.Add(book);
        public void AddUser(User user) => _users.Add(user);

        public void LendBook(int userId, int bookId)
        {
            User? user = _users.FirstOrDefault(u => u.Id == userId);
            Book? book = _books.FirstOrDefault(b => b.Id == bookId);

            if (user == null || book == null)
            {
                Console.WriteLine("Помилка: користувача або книгу не знайдено.");
                return;
            }

            if (!book.IsAvailable)
            {
                Console.WriteLine($"Книга \"{book.Title}\" вже в оренді.");
                return;
            }

            book.Borrow(user.Id);
            user.BorrowedBooks.Add(book);
            Console.WriteLine($"Книгу \"{book.Title}\" видано користувачу {user.Name}.");
        }

        public void ReturnBook(int userId, int bookId)
        {
            User? user = _users.FirstOrDefault(u => u.Id == userId);
            Book? book = _books.FirstOrDefault(b => b.Id == bookId);

            if (user == null || book == null)
            {
                Console.WriteLine("Помилка: користувача або книгу не знайдено.");
                return;
            }

            if (book.IsAvailable || book.BorrowedByUserId != user.Id)
            {
                Console.WriteLine($"{user.Name} не орендував книгу \"{book.Title}\".");
                return;
            }

            book.Return();
            user.BorrowedBooks.Remove(book);
            Console.WriteLine($"Книгу \"{book.Title}\" повернено.");
        }

        public void ShowAllBooks()
        {
            Console.WriteLine("\nУсі книги:");
            foreach (Book b in _books) Console.WriteLine(b);
        }

        public void ShowAvailableBooks()
        {
            Console.WriteLine("\nДоступні книги:");
            foreach (Book b in _books.Where(b => b.IsAvailable)) Console.WriteLine(b);
        }

        public void ShowBorrowedBooks()
        {
            Console.WriteLine("\nКниги в оренді:");
            foreach (Book b in _books.Where(b => !b.IsAvailable)) Console.WriteLine(b);
        }

        public void ShowAllUsers()
        {
            Console.WriteLine("\nКористувачі:");
            foreach (User u in _users) Console.WriteLine(u);
        }
    }
}
