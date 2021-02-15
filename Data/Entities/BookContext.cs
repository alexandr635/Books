﻿using Data.Entities;
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
                    new Genre ( 1, "Роман" ),
                    new Genre ( 2, "Рассказ" ),
                    new Genre ( 3, "Повесть" ),
                    new Genre ( 4, "Сказка" ),
                    new Genre ( 5, "Поэма" ),
                    new Genre ( 6, "Фэнтэзи" )
            });

            modelBuilder.Entity<BookStatus>().HasData(
                new BookStatus[]{
                    new BookStatus ( 1, "Черновик" ),
                    new BookStatus ( 2, "На рассмотрении" ),
                    new BookStatus ( 3, "Опубликовано" ),
                    new BookStatus ( 4, "Снято с публикации" ),
            });

            modelBuilder.Entity<Author>().HasData(
                new Author[]{
                    new Author (
                        1, "Александр", "Пушкин", "Сергеевич",
                        new DateTime(1799, 05, 26), new DateTime(1837, 01, 29),
                        "Москва, Российская империя",
                        "Происхождение Александра Сергеевича Пушкина идёт от разветвлённого нетитулованного дворянского рода Пушкиных, восходившего по генеалогической легенде к «мужу честну» Ратше. Пушкин неоднократно писал о своей родословной в стихах и прозе; он видел в своих предках образец истинной «аристократии», древнего рода, честно служившего отечеству, но не снискавшего благосклонности правителей и «гонимого». Не раз он обращался (в том числе в художественной форме) и к образу своего прадеда по матери — африканца Абрама Петровича Ганнибала, ставшего слугой и воспитанником Петра I, а потом военным инженером и генералом"
                    ),
                    new Author (
                        2, "Иван", "Тургенев", "Сергеевич",
                        new DateTime(1818, 10, 28), new DateTime(1883, 08, 22),
                        "Орёл, Российская империя",
                        "Семья Ивана Сергеевича Тургенева происходила из древнего рода тульских дворян Тургеневых. В памятной книжке мать будущего писателя записала: «1818 года 28 октября, в понедельник, родился сын Иван, ростом 12 вершков, в Орле, в своём доме, в 12 часов утра. Крестили 4-го числа ноября, Феодор Семёнович Уваров с сестрою Федосьей Николаевной Тепловой»"
                    ),
                    new Author (
                        3, "Федор", "Достоевский", "Михайлович",
                        new DateTime(1821, 10, 30), new DateTime(1881, 01, 28),
                        "Москва, Российская империя", 
                        "После смерти Достоевский был признан классиком русской литературы и одним из лучших романистов мирового значения, считается первым представителем персонализма в России. Творчество русского писателя оказало воздействие на мировую литературу, в частности на творчество ряда лауреатов Нобелевской премии по литературе, философов Фридриха Ницше и Жана-Поль Сартра, а также на становление экзистенциализма и фрейдизма"
                    ),
                    new Author (
                        4, "Джоан", "Роулинг", "Кэтлин",
                        new DateTime(1965, 07, 31), null,
                        "Йейт, Глостершир, Юго-Западная Англия, Англия, Великобритания",
                        "Роулинг работала научной сотрудницей и секретарём-переводчиком «Международной амнистии», когда во время поездки на поезде из Манчестера в Лондон в 1990 году у неё появилась идея романа о Гарри Поттере"
                    ),
                    new Author (
                        5, "Анджей", "Сапковский", "",
                        new DateTime(1948, 06, 21), null,
                        "Лодзь, Польская Народная Республика",
                        "Произведения Сапковского изданы на польском, чешском, русском, немецком, испанском, финском, литовском, французском, английском, португальском, болгарском, белорусском, итальянском, шведском, сербском, украинском и китайском языках."
                    )
            });

            modelBuilder.Entity<BookSeries>().HasData(
                new BookSeries[]{
                    new BookSeries ( 1, "Гарри Поттер"),
                    new BookSeries ( 2, "Ведьмак")
            });

            modelBuilder.Entity<Tag>().HasData(
                new Tag[]{
                    new Tag ( 1, "Первый тэг" ),
                    new Tag ( 2, "Второй тэг" ),
                    new Tag ( 3, "Третий тэг" )
        });

            modelBuilder.Entity<Book>().HasData(
                new Book[]{
                    new Book (
                        1,
                        "Гарри Поттер и философский камень",
                        "первый роман в серии книг про юного волшебника Гарри Поттера",
                        "Родителей годовалого Гарри Поттера убивает Волан-де-Морт, после чего исчезает при попытке убить самого Гарри. Поздно вечером директор школы волшебства Хогвартс Альбус Дамблдор и его заместитель Минерва МакГонагалл появляются возле дома Вернона и Петуньи Дурсль, единственных родственников Гарри.",
                        new DateTime(1997, 01, 01),
                        5, 4, 6, 3, 1),
                    new Book (
                        2,
                        "Гарри Поттер и тайная комната",
                        "второй роман в серии книг про юного волшебника Гарри Поттера",
                        "Книга рассказывает о втором учебном годе в школе чародейства и волшебства Хогвартс, на котором Гарри и его друзья — Рон Уизли и Гермиона Грейнджер — расследуют таинственные нападения на учеников школы, совершаемые неким «Наследником Слизерина». Объектами нападений являются ученики, среди родственников которых есть неволшебники.",
                        new DateTime(1998, 01, 01),
                        4.2, 4, 6, 3, 1),
                    new Book (
                        3,
                        "Меч Предназначения",
                        "Это второе произведение из цикла «Ведьмак» как по хронологии, так и по времени написания. В этой части Геральт впервые встречает Цири и находит своё предназначение.",
                        "В этом рассказе Геральт встречается с человеком по имени Борх Три Галки и двумя его телохранительницами из далёкой Зеррикании. Они отправляются по дороге, но наталкиваются на оцепление. Находящийся здесь же Лютик даёт разъяснения. В Голополье повадился летать зелёный дракон, а местный сапожник Козоед придумал, как его отравить.",
                        new DateTime(1992, 01, 01),
                        4.2, 5, 6, 3, 2),
                    new Book (
                        4,
                        "Последнее желание",
                        "сборник рассказов писателя Анджея Сапковского в жанре фэнтези",
                        "Это первое произведение из цикла «Ведьмак» как по хронологии, так и по времени написания. От первого издания в виде книги «Ведьмак» «Последнее желание» отличается связующей серией интерлюдий «Глас рассудка» и наличием рассказов «Последнее желание» и «Край света».",
                        new DateTime(1993, 01, 01),
                        4.4, 5, 6, 3, 2)
            });

            modelBuilder.Entity<Review>().HasData(
               new Review[]{
                    new Review ( 1, "Commentator1", "Интересно", 4.5, 1, 1 ),
                    new Review ( 2, "Commentator2", "Не очень", 2.5, 2, 1 ),
                    new Review ( 3, "Commentator3", "Прикольно", 4,  2, 4 )
           });

            modelBuilder.Entity<Role>().HasData(
                new Role[]{
                    new Role ( 1, "Администратор"),
                    new Role ( 2, "Проверяющий"),
                    new Role ( 3, "Писатель"),
                    new Role ( 4, "Читатель")
            });

            modelBuilder.Entity<User>().HasData(
                new User[]{
                    new User ( 1, "log1", "pass1", 1),
                    new User ( 2, "log2", "pass2", 2),
                    new User ( 3, "log3", "pass3", 3),
                    new User ( 4, "log4", "pass4", 4)
            });
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookStatus> BookStatuses { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<BookSeries> BookSeries { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
