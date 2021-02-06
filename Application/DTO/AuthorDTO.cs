using System;

namespace Application.DTO
{
    public class AuthorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime? DateOfDie { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Biography { get; set; }
    }
}
