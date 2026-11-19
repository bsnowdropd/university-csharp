namespace LB4
{
    internal class Book
    {
        public int Id { get; }
        public string Title { get; }
        public string Author { get; }
        public bool IsAvailable { get; private set; } = true;
        public int? BorrowedByUserId { get; private set; }

        public Book(int id, string title, string author)
        {
            Id = id;
            Title = title;
            Author = author;
        }

        public void Borrow(int userId)
        {
            IsAvailable = false;
            BorrowedByUserId = userId;
        }

        public void Return()
        {
            IsAvailable = true;
            BorrowedByUserId = null;
        }

        public override string ToString()
        {
            string status = IsAvailable ? "Доступна" : $"В оренді (читач ID {BorrowedByUserId})";
            return $"[{Id}] \"{Title}\" - {Author} ({status})";
        }
    }
}
