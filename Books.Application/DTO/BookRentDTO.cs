using System;

namespace Books.Application.DTO
{
    public class BookRentDTO : UserToBookDTO
    {
        public DateTime EndDate { get; protected set; }
    }
}
