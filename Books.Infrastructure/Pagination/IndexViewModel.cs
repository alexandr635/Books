using Books.Domain.Entities;
using System.Collections.Generic;

namespace Books.Infrastructure.Pagination
{
    public class IndexViewModel
    {
        public List<Book> Books { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public Book Pattern { get; set; }
    }
}
