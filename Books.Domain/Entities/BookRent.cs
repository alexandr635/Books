using System;

namespace Books.Domain.Entities
{
    public class BookRent : UserToBook
    {
        public DateTime EndDate { get; protected set; }

        public BookRent(int user, int book, DateTime end)
            :base()
        {
            BookId = book;
            UserId = user;
            EndDate = end;
        }

        public BookRent()
        {

        }
    }
}
