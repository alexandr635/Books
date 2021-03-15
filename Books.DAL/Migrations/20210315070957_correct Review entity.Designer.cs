﻿// <auto-generated />
using System;
using Books.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Books.DAL.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20210315070957_correct Review entity")]
    partial class correctReviewentity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Books.Domain.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Biography")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfDie")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlaceOfBirth")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Biography = "Происхождение Александра Сергеевича Пушкина идёт от разветвлённого нетитулованного дворянского рода Пушкиных, восходившего по генеалогической легенде к «мужу честну» Ратше. Пушкин неоднократно писал о своей родословной в стихах и прозе; он видел в своих предках образец истинной «аристократии», древнего рода, честно служившего отечеству, но не снискавшего благосклонности правителей и «гонимого». Не раз он обращался (в том числе в художественной форме) и к образу своего прадеда по матери — африканца Абрама Петровича Ганнибала, ставшего слугой и воспитанником Петра I, а потом военным инженером и генералом",
                            DateOfBirth = new DateTime(1799, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfDie = new DateTime(1837, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Пушкин",
                            Name = "Александр",
                            Patronymic = "Сергеевич",
                            PlaceOfBirth = "Москва, Российская империя"
                        },
                        new
                        {
                            Id = 2,
                            Biography = "Семья Ивана Сергеевича Тургенева происходила из древнего рода тульских дворян Тургеневых. В памятной книжке мать будущего писателя записала: «1818 года 28 октября, в понедельник, родился сын Иван, ростом 12 вершков, в Орле, в своём доме, в 12 часов утра. Крестили 4-го числа ноября, Феодор Семёнович Уваров с сестрою Федосьей Николаевной Тепловой»",
                            DateOfBirth = new DateTime(1818, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfDie = new DateTime(1883, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Тургенев",
                            Name = "Иван",
                            Patronymic = "Сергеевич",
                            PlaceOfBirth = "Орёл, Российская империя"
                        },
                        new
                        {
                            Id = 3,
                            Biography = "После смерти Достоевский был признан классиком русской литературы и одним из лучших романистов мирового значения, считается первым представителем персонализма в России. Творчество русского писателя оказало воздействие на мировую литературу, в частности на творчество ряда лауреатов Нобелевской премии по литературе, философов Фридриха Ницше и Жана-Поль Сартра, а также на становление экзистенциализма и фрейдизма",
                            DateOfBirth = new DateTime(1821, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfDie = new DateTime(1881, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Достоевский",
                            Name = "Федор",
                            Patronymic = "Михайлович",
                            PlaceOfBirth = "Москва, Российская империя"
                        },
                        new
                        {
                            Id = 4,
                            Biography = "Роулинг работала научной сотрудницей и секретарём-переводчиком «Международной амнистии», когда во время поездки на поезде из Манчестера в Лондон в 1990 году у неё появилась идея романа о Гарри Поттере",
                            DateOfBirth = new DateTime(1965, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Роулинг",
                            Name = "Джоан",
                            Patronymic = "Кэтлин",
                            PlaceOfBirth = "Йейт, Глостершир, Юго-Западная Англия, Англия, Великобритания"
                        },
                        new
                        {
                            Id = 5,
                            Biography = "Произведения Сапковского изданы на польском, чешском, русском, немецком, испанском, финском, литовском, французском, английском, португальском, болгарском, белорусском, итальянском, шведском, сербском, украинском и китайском языках.",
                            DateOfBirth = new DateTime(1948, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Сапковский",
                            Name = "Анджей",
                            Patronymic = "",
                            PlaceOfBirth = "Лодзь, Польская Народная Республика"
                        });
                });

            modelBuilder.Entity("Books.Domain.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<double>("AverageRating")
                        .HasColumnType("float");

                    b.Property<int?>("BookSeriesId")
                        .HasColumnType("int");

                    b.Property<int>("BookStatusId")
                        .HasColumnType("int");

                    b.Property<string>("DescriptionLong")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionShort")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BookSeriesId");

                    b.HasIndex("BookStatusId");

                    b.HasIndex("GenreId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 4,
                            AverageRating = 5.0,
                            BookSeriesId = 1,
                            BookStatusId = 4,
                            DescriptionLong = "Родителей годовалого Гарри Поттера убивает Волан-де-Морт, после чего исчезает при попытке убить самого Гарри. Поздно вечером директор школы волшебства Хогвартс Альбус Дамблдор и его заместитель Минерва МакГонагалл появляются возле дома Вернона и Петуньи Дурсль, единственных родственников Гарри.",
                            DescriptionShort = "первый роман в серии книг про юного волшебника Гарри Поттера",
                            GenreId = 6,
                            PublishDate = new DateTime(1997, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Гарри Поттер и философский камень"
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 4,
                            AverageRating = 4.2000000000000002,
                            BookSeriesId = 1,
                            BookStatusId = 4,
                            DescriptionLong = "Книга рассказывает о втором учебном годе в школе чародейства и волшебства Хогвартс, на котором Гарри и его друзья — Рон Уизли и Гермиона Грейнджер — расследуют таинственные нападения на учеников школы, совершаемые неким «Наследником Слизерина». Объектами нападений являются ученики, среди родственников которых есть неволшебники.",
                            DescriptionShort = "второй роман в серии книг про юного волшебника Гарри Поттера",
                            GenreId = 6,
                            PublishDate = new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Гарри Поттер и тайная комната"
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 5,
                            AverageRating = 4.2000000000000002,
                            BookSeriesId = 2,
                            BookStatusId = 3,
                            DescriptionLong = "В этом рассказе Геральт встречается с человеком по имени Борх Три Галки и двумя его телохранительницами из далёкой Зеррикании. Они отправляются по дороге, но наталкиваются на оцепление. Находящийся здесь же Лютик даёт разъяснения. В Голополье повадился летать зелёный дракон, а местный сапожник Козоед придумал, как его отравить.",
                            DescriptionShort = "Это второе произведение из цикла «Ведьмак» как по хронологии, так и по времени написания. В этой части Геральт впервые встречает Цири и находит своё предназначение.",
                            GenreId = 6,
                            PublishDate = new DateTime(1992, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Меч Предназначения"
                        },
                        new
                        {
                            Id = 4,
                            AuthorId = 5,
                            AverageRating = 4.4000000000000004,
                            BookSeriesId = 2,
                            BookStatusId = 3,
                            DescriptionLong = "Это первое произведение из цикла «Ведьмак» как по хронологии, так и по времени написания. От первого издания в виде книги «Ведьмак» «Последнее желание» отличается связующей серией интерлюдий «Глас рассудка» и наличием рассказов «Последнее желание» и «Край света».",
                            DescriptionShort = "сборник рассказов писателя Анджея Сапковского в жанре фэнтези",
                            GenreId = 6,
                            PublishDate = new DateTime(1993, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Последнее желание"
                        },
                        new
                        {
                            Id = 5,
                            AuthorId = 1,
                            AverageRating = 4.5,
                            BookStatusId = 2,
                            DescriptionLong = "«Капитанская дочка» принадлежит к числу произведений, которыми русские писатели 1830-х откликнулись на успех переводных романов Вальтера Скотта. Первым из исторических романов на русскую тему увидел свет «Юрий Милославский» М. Н. Загоскина (1829) (встреча Гринёва с вожатым, по мнению пушкиноведов, восходит к аналогичной сцене в романе Загоскина)",
                            DescriptionShort = "исторический роман Александра Пушкина, действие которого происходит во время восстания Емельяна Пугачёва.",
                            GenreId = 1,
                            PublishDate = new DateTime(1836, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Капитанская дочка"
                        },
                        new
                        {
                            Id = 6,
                            AuthorId = 1,
                            AverageRating = 4.9000000000000004,
                            BookStatusId = 2,
                            DescriptionLong = "В жанровом отношении повесть примыкает к таким (неоконченным) замыслам Пушкина, как «Египетские ночи», «Уединённый домик на Васильевском» и знаменитый отрывок «Гости съезжались на дачу…». Повесть неоднократно экранизирована.",
                            DescriptionShort = "повесть Александра Сергеевича Пушкина с мистическими элементами, послужившая источником сюжета одноимённой оперы П. И. Чайковского.",
                            GenreId = 1,
                            PublishDate = new DateTime(1834, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Пиковая дама"
                        },
                        new
                        {
                            Id = 7,
                            AuthorId = 3,
                            AverageRating = 3.7999999999999998,
                            BookStatusId = 1,
                            DescriptionLong = "Являлся одним из самых любимых произведений писателя, наиболее полно выразившим и нравственно-философскую позицию Достоевского, и его художественные принципы в 1860-х годах. Замысел романа обдумывался писателем во время пребывания за границей — в Германии и Швейцарии.",
                            DescriptionShort = "роман Фёдора Михайловича Достоевского, впервые опубликованный в номерах журнала «Русский вестник» за 1868 год",
                            GenreId = 1,
                            PublishDate = new DateTime(1868, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Идиот"
                        },
                        new
                        {
                            Id = 8,
                            AuthorId = 3,
                            AverageRating = 3.6000000000000001,
                            BookStatusId = 1,
                            DescriptionLong = "Роман был напечатан частями в журнале «Русский вестник». Достоевский задумывал роман как первую часть эпического романа «История Великого грешника». Произведение было окончено в ноябре 1880 года. Писатель умер через два месяца после публикации.",
                            DescriptionShort = "последний роман Ф. М. Достоевского, который автор писал два года.",
                            GenreId = 1,
                            PublishDate = new DateTime(1879, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Братья Карамазовы"
                        },
                        new
                        {
                            Id = 9,
                            AuthorId = 2,
                            AverageRating = 4.2000000000000002,
                            BookStatusId = 4,
                            DescriptionLong = "В обстановке «великих реформ» книга стала сенсацией и привлекла к себе всеобщее внимание, а образ главного героя Евгения Базарова был воспринят как воплощение нового, пореформенного поколения, став примером для подражания молодёжи 1860-х гг. Свойственные Базарову бескомпромиссность, отсутствие преклонения перед авторитетами и старыми истинами, приоритет полезного над прекрасным стали идеалами первого поколения пореформенной интеллигенции",
                            DescriptionShort = "роман И. С. Тургенева, написанный в 1860—1861 годах и опубликованный в 1862 году в журнале «Русский вестник»",
                            GenreId = 1,
                            PublishDate = new DateTime(1862, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Отцы и дети"
                        });
                });

            modelBuilder.Entity("Books.Domain.Entities.BookSeries", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SeriesName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BookSeries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            SeriesName = "Гарри Поттер"
                        },
                        new
                        {
                            Id = 2,
                            SeriesName = "Ведьмак"
                        });
                });

            modelBuilder.Entity("Books.Domain.Entities.BookStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StatusName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BookStatuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            StatusName = "Черновик"
                        },
                        new
                        {
                            Id = 2,
                            StatusName = "На рассмотрении"
                        },
                        new
                        {
                            Id = 3,
                            StatusName = "Опубликовано"
                        },
                        new
                        {
                            Id = 4,
                            StatusName = "Снято с публикации"
                        });
                });

            modelBuilder.Entity("Books.Domain.Entities.BookToTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("TagId");

                    b.ToTable("BookToTags");
                });

            modelBuilder.Entity("Books.Domain.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GenreName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GenreName = "Роман"
                        },
                        new
                        {
                            Id = 2,
                            GenreName = "Рассказ"
                        },
                        new
                        {
                            Id = 3,
                            GenreName = "Повесть"
                        },
                        new
                        {
                            Id = 4,
                            GenreName = "Сказка"
                        },
                        new
                        {
                            Id = 5,
                            GenreName = "Поэма"
                        },
                        new
                        {
                            Id = 6,
                            GenreName = "Фэнтэзи"
                        });
                });

            modelBuilder.Entity("Books.Domain.Entities.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<string>("ReviewString")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookId = 1,
                            Rating = 4.5,
                            ReviewString = "Интересно",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            BookId = 2,
                            Rating = 2.5,
                            ReviewString = "Не очень",
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            BookId = 2,
                            Rating = 4.0,
                            ReviewString = "Прикольно",
                            UserId = 4
                        });
                });

            modelBuilder.Entity("Books.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RoleName = "Администратор"
                        },
                        new
                        {
                            Id = 2,
                            RoleName = "Проверяющий"
                        },
                        new
                        {
                            Id = 3,
                            RoleName = "Писатель"
                        },
                        new
                        {
                            Id = 4,
                            RoleName = "Читатель"
                        });
                });

            modelBuilder.Entity("Books.Domain.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TagName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            TagName = "Первый тэг"
                        },
                        new
                        {
                            Id = 2,
                            TagName = "Второй тэг"
                        },
                        new
                        {
                            Id = 3,
                            TagName = "Третий тэг"
                        });
                });

            modelBuilder.Entity("Books.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Login = "log1",
                            Password = "pass1",
                            RoleId = 1
                        },
                        new
                        {
                            Id = 2,
                            Login = "log2",
                            Password = "pass2",
                            RoleId = 2
                        },
                        new
                        {
                            Id = 3,
                            Login = "log3",
                            Password = "pass3",
                            RoleId = 3
                        },
                        new
                        {
                            Id = 4,
                            Login = "log4",
                            Password = "pass4",
                            RoleId = 4
                        });
                });

            modelBuilder.Entity("Books.Domain.Entities.UserToBook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId2")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.HasIndex("UserId2");

                    b.ToTable("UserToBooks");

                    b.HasDiscriminator<string>("Discriminator").HasValue("UserToBook");
                });

            modelBuilder.Entity("Books.Domain.Entities.BookRent", b =>
                {
                    b.HasBaseType("Books.Domain.Entities.UserToBook");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId1")
                        .HasColumnType("int");

                    b.HasIndex("UserId1");

                    b.HasDiscriminator().HasValue("BookRent");
                });

            modelBuilder.Entity("Books.Domain.Entities.Book", b =>
                {
                    b.HasOne("Books.Domain.Entities.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Books.Domain.Entities.BookSeries", "BookSeries")
                        .WithMany("Books")
                        .HasForeignKey("BookSeriesId");

                    b.HasOne("Books.Domain.Entities.BookStatus", "BookStatus")
                        .WithMany("Books")
                        .HasForeignKey("BookStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Books.Domain.Entities.Genre", "Genre")
                        .WithMany("Books")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("BookSeries");

                    b.Navigation("BookStatus");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("Books.Domain.Entities.BookToTag", b =>
                {
                    b.HasOne("Books.Domain.Entities.Book", "Book")
                        .WithMany("BookToTags")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Books.Domain.Entities.Tag", "Tag")
                        .WithMany("BookToTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Books.Domain.Entities.Review", b =>
                {
                    b.HasOne("Books.Domain.Entities.Book", "Book")
                        .WithMany("Reviews")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Books.Domain.Entities.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Books.Domain.Entities.User", b =>
                {
                    b.HasOne("Books.Domain.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Books.Domain.Entities.UserToBook", b =>
                {
                    b.HasOne("Books.Domain.Entities.Book", "Book")
                        .WithMany("UserToBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Books.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Books.Domain.Entities.User", null)
                        .WithMany("UserToBooks")
                        .HasForeignKey("UserId2");

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Books.Domain.Entities.BookRent", b =>
                {
                    b.HasOne("Books.Domain.Entities.User", null)
                        .WithMany("BookRents")
                        .HasForeignKey("UserId1");
                });

            modelBuilder.Entity("Books.Domain.Entities.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Books.Domain.Entities.Book", b =>
                {
                    b.Navigation("BookToTags");

                    b.Navigation("Reviews");

                    b.Navigation("UserToBooks");
                });

            modelBuilder.Entity("Books.Domain.Entities.BookSeries", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Books.Domain.Entities.BookStatus", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Books.Domain.Entities.Genre", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Books.Domain.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Books.Domain.Entities.Tag", b =>
                {
                    b.Navigation("BookToTags");
                });

            modelBuilder.Entity("Books.Domain.Entities.User", b =>
                {
                    b.Navigation("BookRents");

                    b.Navigation("Reviews");

                    b.Navigation("UserToBooks");
                });
#pragma warning restore 612, 618
        }
    }
}