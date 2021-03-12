using System;
using System.Collections.Generic;

namespace Books.Application.DTO
{
    public class FilterAuthorDTO
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfDie { get; set; }

        public int MaxYearOfBirth { get; set; }
        public int MinYearOfBirth { get; set; }

        public int PageCount { get; set; }
        public int Page { get; set; }

        public List<AuthorDTO> Authors { get; set; }
    }
}
