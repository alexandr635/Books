using Application.DTO;  
using System.Collections.Generic;

namespace Application.Pagination
{
    public class IndexViewModel
    {
        public List<BookDTO> Books { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
