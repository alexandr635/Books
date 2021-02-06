using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class Author
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime? DateOfDie { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Biography { get; set; }

        public HashSet<Book> Books { get; set; }

        public Author()
        {
            Books = new HashSet<Book>();
        }
    }
}
