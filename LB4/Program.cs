using System;
using System.Text;

namespace LB4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Library library = new Library();

            library.AddBook(new Book(1, "Місто", "Валер'ян Підмогильний"));
            library.AddBook(new Book(2, "Дюна", "Френк Герберт"));
            library.AddBook(new Book(3, "Соляріс", "Станіслав Лем"));

            library.AddUser(new User(1, "Ірина"));
            library.AddUser(new User(2, "Денис"));

            library.ShowAvailableBooks();

            Console.WriteLine();
            library.LendBook(1, 2);
            library.LendBook(2, 2);
            library.ShowBorrowedBooks();

            Console.WriteLine();
            library.ReturnBook(2, 2);
            library.ReturnBook(1, 2);
            library.ShowAvailableBooks();

            library.ShowAllBooks();
            library.ShowAllUsers();
        }
    }
}
