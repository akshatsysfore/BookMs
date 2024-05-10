namespace Model
{
    public class Books
    {
        public Books(BooksDto books)
        {
            GenreId = books.GenreId;
            this.Title = books.Title;
            this.ISBN = books.ISBN;
            this.Price=books.Price;
            this.Description = books.Description;
            this.Language = books.Language;
            this.Publisher = books.Publisher;
            this.PageCount = books.PageCount;
            this.AvgRating = books.AvgRating;
            this.CreatedDate = DateTime.Now;
            this.LastUpdated = DateTime.Now;
            BookId = Guid.NewGuid();
        }
        public Books()
        {
            BookId = Guid.NewGuid();

        }
        public Guid BookId { get; set; }

        public int GenreId { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public string ISBN { get; set; }

        public int Price { get; set; }

        public string Language { get; set; }

        public string Publisher { get; set; }

        public float AvgRating  { get; set; }

        public int PageCount { get; set; }

        public DateTime LastUpdated { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
