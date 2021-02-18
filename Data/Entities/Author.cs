using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public class Author
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public string LastName { get; protected set; }
        public string Patronymic { get; protected set; }
        public DateTime DateOfBirth { get; protected set; }
        public DateTime? DateOfDie { get; protected set; }
        public string PlaceOfBirth { get; protected set; }
        public string Biography { get; protected set; }

        public List<Book> Books { get; protected set; }

        public Author()
        {
            Books = new List<Book>();
        }

        public Author(int id, string name, string lastName, string patronymic, 
                      DateTime dateOfBirth, DateTime? dateOfDie, string placeOfBirth, string biography)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Patronymic = patronymic;
            DateOfBirth = dateOfBirth;
            DateOfDie = dateOfDie;
            PlaceOfBirth = placeOfBirth;
            Biography = biography;

            Books = new List<Book>();
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetLastName(string name)
        {
            LastName = name;
        }

        public void SetPatronymic(string patronymic)
        {
            Patronymic = patronymic;
        }

        public void SetDateOfBirth(DateTime date)
        {
            DateOfBirth = date;
        }

        public void SetDateOfDie(DateTime? date)
        {
            DateOfDie = date;
        }

        public void SetPlaceOfBirth(string place)
        {
            PlaceOfBirth = place;
        }

        public void SetBiography(string biography)
        {
            Biography = biography;
        }
    }
}
