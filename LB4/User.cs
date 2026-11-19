using System.Collections.Generic;
using System.Linq;

namespace LB4
{
    internal class User
    {
        public int Id { get; }
        public string Name { get; }
        public List<Book> BorrowedBooks { get; } = new List<Book>();

        public User(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            string books = BorrowedBooks.Count == 0
                ? "немає"
                : string.Join(", ", BorrowedBooks.Select(b => b.Title));
            return $"[{Id}] {Name} | Книги: {books}";
        }
    }
}
