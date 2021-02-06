using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
                new Genre[]{
                    new Genre { Id = 1, GenreName = "Роман" },
                    new Genre { Id = 2, GenreName = "Рассказ" },
                    new Genre { Id = 3, GenreName = "Повесть" },
                    new Genre { Id = 4, GenreName = "Сказка" },
                    new Genre { Id = 5, GenreName = "Поэма" }
            });

            modelBuilder.Entity<BookStatus>().HasData(
                new BookStatus[]{
                    new BookStatus{ Id = 1, StatusName = "Черновик" },
                    new BookStatus{ Id = 2, StatusName = "На рассмотрении" },
                    new BookStatus{ Id = 3, StatusName = "Опубликовано" },
                    new BookStatus{ Id = 4, StatusName = "Снято с публикации" },
            });

            modelBuilder.Entity<Author>().HasData(
                new Author[]{
                    new Author{
                        Id = 1,
                        Name = "Александр",
                        LastName = "Пушкин",
                        Patronymic = "Сергеевич",
                        DateOfBirth = new DateTime(1799, 05, 26),
                        DateOfDie = new DateTime(1837, 01, 29),
                        PlaceOfBirth = "Москва, Российская империя",
                        Biography = "Происхождение Александра Сергеевича Пушкина идёт от разветвлённого нетитулованного дворянского рода Пушкиных, восходившего по генеалогической легенде к «мужу честну» Ратше. Пушкин неоднократно писал о своей родословной в стихах и прозе; он видел в своих предках образец истинной «аристократии», древнего рода, честно служившего отечеству, но не снискавшего благосклонности правителей и «гонимого». Не раз он обращался (в том числе в художественной форме) и к образу своего прадеда по матери — африканца Абрама Петровича Ганнибала, ставшего слугой и воспитанником Петра I, а потом военным инженером и генералом"
                    },
                    new Author{
                        Id = 2,
                        Name = "Иван",
                        LastName = "Тургенев",
                        Patronymic = "Сергеевич",
                        DateOfBirth = new DateTime(1818, 10, 28),
                        DateOfDie = new DateTime(1883, 08, 22),
                        PlaceOfBirth = "Орёл, Российская империя",
                        Biography = "Семья Ивана Сергеевича Тургенева происходила из древнего рода тульских дворян Тургеневых. В памятной книжке мать будущего писателя записала: «1818 года 28 октября, в понедельник, родился сын Иван, ростом 12 вершков, в Орле, в своём доме, в 12 часов утра. Крестили 4-го числа ноября, Феодор Семёнович Уваров с сестрою Федосьей Николаевной Тепловой»"
                    },
                    new Author{
                        Id = 3,
                        Name = "Федор",
                        LastName = "Достоевский",
                        Patronymic = "Михайлович",
                        DateOfBirth = new DateTime(1821, 10, 30),
                        DateOfDie = new DateTime(1881, 01, 28),
                        PlaceOfBirth = "Москва, Российская империя",
                        Biography = "После смерти Достоевский был признан классиком русской литературы и одним из лучших романистов мирового значения, считается первым представителем персонализма в России. Творчество русского писателя оказало воздействие на мировую литературу, в частности на творчество ряда лауреатов Нобелевской премии по литературе, философов Фридриха Ницше и Жана-Поль Сартра, а также на становление экзистенциализма и фрейдизма"
                    }
            });
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookStatus> BookStatuses { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<BookSeries> BookSeries { get; set; }
        public DbSet<Review> Reviews { get; set; }
        
    }
}
