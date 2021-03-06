using Books.Infrastructure.Pagination;
using System.Collections.Generic;

namespace Books.Application.DTO
{
    public class IndexViewModelDTO
    {
        public List<BookDTO> Books { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public BookDTO Pattern { get; set; }
    }
}
