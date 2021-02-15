namespace Data.Entities
{
    public class Review
    {
        public int Id { get; protected set; }
        public string Pseudonim { get; protected set; }
        public string ReviewString { get; protected set; }
        public double Rating { get; protected set; }

        public int BookId { get; protected set; }
        public int UserId { get; protected set; }

        public Book Book { get; protected set; }
        public User User { get; protected set; }

        public Review()
        {

        }

        public Review(int id, string pseudonim, string review, double rating, int book, int user)
        {
            Id = id;
            Pseudonim = pseudonim;
            ReviewString = review;
            Rating = rating;
            BookId = book;
            UserId = user;
        }

        public void SetPseudonim(string pseudonim)
        {
            Pseudonim = pseudonim;
        }

        public void SetReviewString(string review)
        {
            ReviewString = review;
        }

        public void SetRating(double rating)
        {
            Rating = rating;
        }

        public void SetBook(int id)
        {
            BookId = id;
        }

        public void SetUser(int id)
        {
            UserId = id;
        }
    }
}
