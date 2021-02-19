using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AddData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Patronymic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfDie = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookSeries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeriesName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookSeries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionShort = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionLong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AverageRating = table.Column<double>(type: "float", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    BookStatusId = table.Column<int>(type: "int", nullable: false),
                    BookSeriesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_BookSeries_BookSeriesId",
                        column: x => x.BookSeriesId,
                        principalTable: "BookSeries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Books_BookStatuses_BookStatusId",
                        column: x => x.BookStatusId,
                        principalTable: "BookStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookToTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookToTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookToTags_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookToTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pseudonim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Biography", "DateOfBirth", "DateOfDie", "LastName", "Name", "Patronymic", "PlaceOfBirth" },
                values: new object[,]
                {
                    { 1, "Происхождение Александра Сергеевича Пушкина идёт от разветвлённого нетитулованного дворянского рода Пушкиных, восходившего по генеалогической легенде к «мужу честну» Ратше. Пушкин неоднократно писал о своей родословной в стихах и прозе; он видел в своих предках образец истинной «аристократии», древнего рода, честно служившего отечеству, но не снискавшего благосклонности правителей и «гонимого». Не раз он обращался (в том числе в художественной форме) и к образу своего прадеда по матери — африканца Абрама Петровича Ганнибала, ставшего слугой и воспитанником Петра I, а потом военным инженером и генералом", new DateTime(1799, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1837, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Пушкин", "Александр", "Сергеевич", "Москва, Российская империя" },
                    { 2, "Семья Ивана Сергеевича Тургенева происходила из древнего рода тульских дворян Тургеневых. В памятной книжке мать будущего писателя записала: «1818 года 28 октября, в понедельник, родился сын Иван, ростом 12 вершков, в Орле, в своём доме, в 12 часов утра. Крестили 4-го числа ноября, Феодор Семёнович Уваров с сестрою Федосьей Николаевной Тепловой»", new DateTime(1818, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1883, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Тургенев", "Иван", "Сергеевич", "Орёл, Российская империя" },
                    { 3, "После смерти Достоевский был признан классиком русской литературы и одним из лучших романистов мирового значения, считается первым представителем персонализма в России. Творчество русского писателя оказало воздействие на мировую литературу, в частности на творчество ряда лауреатов Нобелевской премии по литературе, философов Фридриха Ницше и Жана-Поль Сартра, а также на становление экзистенциализма и фрейдизма", new DateTime(1821, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1881, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Достоевский", "Федор", "Михайлович", "Москва, Российская империя" },
                    { 4, "Роулинг работала научной сотрудницей и секретарём-переводчиком «Международной амнистии», когда во время поездки на поезде из Манчестера в Лондон в 1990 году у неё появилась идея романа о Гарри Поттере", new DateTime(1965, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Роулинг", "Джоан", "Кэтлин", "Йейт, Глостершир, Юго-Западная Англия, Англия, Великобритания" },
                    { 5, "Произведения Сапковского изданы на польском, чешском, русском, немецком, испанском, финском, литовском, французском, английском, португальском, болгарском, белорусском, итальянском, шведском, сербском, украинском и китайском языках.", new DateTime(1948, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Сапковский", "Анджей", "", "Лодзь, Польская Народная Республика" }
                });

            migrationBuilder.InsertData(
                table: "BookSeries",
                columns: new[] { "Id", "SeriesName" },
                values: new object[,]
                {
                    { 1, "Гарри Поттер" },
                    { 2, "Ведьмак" }
                });

            migrationBuilder.InsertData(
                table: "BookStatuses",
                columns: new[] { "Id", "StatusName" },
                values: new object[,]
                {
                    { 1, "Черновик" },
                    { 2, "На рассмотрении" },
                    { 3, "Опубликовано" },
                    { 4, "Снято с публикации" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "GenreName" },
                values: new object[,]
                {
                    { 6, "Фэнтэзи" },
                    { 5, "Поэма" },
                    { 4, "Сказка" },
                    { 1, "Роман" },
                    { 2, "Рассказ" },
                    { 3, "Повесть" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { 1, "Администратор" },
                    { 2, "Проверяющий" },
                    { 3, "Писатель" },
                    { 4, "Читатель" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "TagName" },
                values: new object[,]
                {
                    { 2, "Второй тэг" },
                    { 1, "Первый тэг" },
                    { 3, "Третий тэг" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "AverageRating", "BookSeriesId", "BookStatusId", "DescriptionLong", "DescriptionShort", "GenreId", "PublishDate", "Title" },
                values: new object[,]
                {
                    { 5, 1, 4.5, null, 2, "«Капитанская дочка» принадлежит к числу произведений, которыми русские писатели 1830-х откликнулись на успех переводных романов Вальтера Скотта. Первым из исторических романов на русскую тему увидел свет «Юрий Милославский» М. Н. Загоскина (1829) (встреча Гринёва с вожатым, по мнению пушкиноведов, восходит к аналогичной сцене в романе Загоскина)", "исторический роман Александра Пушкина, действие которого происходит во время восстания Емельяна Пугачёва.", 1, new DateTime(1836, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Капитанская дочка" },
                    { 6, 1, 4.9000000000000004, null, 2, "В жанровом отношении повесть примыкает к таким (неоконченным) замыслам Пушкина, как «Египетские ночи», «Уединённый домик на Васильевском» и знаменитый отрывок «Гости съезжались на дачу…». Повесть неоднократно экранизирована.", "повесть Александра Сергеевича Пушкина с мистическими элементами, послужившая источником сюжета одноимённой оперы П. И. Чайковского.", 1, new DateTime(1834, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Пиковая дама" },
                    { 7, 3, 3.7999999999999998, null, 1, "Являлся одним из самых любимых произведений писателя, наиболее полно выразившим и нравственно-философскую позицию Достоевского, и его художественные принципы в 1860-х годах. Замысел романа обдумывался писателем во время пребывания за границей — в Германии и Швейцарии.", "роман Фёдора Михайловича Достоевского, впервые опубликованный в номерах журнала «Русский вестник» за 1868 год", 1, new DateTime(1868, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Идиот" },
                    { 8, 3, 3.6000000000000001, null, 1, "Роман был напечатан частями в журнале «Русский вестник». Достоевский задумывал роман как первую часть эпического романа «История Великого грешника». Произведение было окончено в ноябре 1880 года. Писатель умер через два месяца после публикации.", "последний роман Ф. М. Достоевского, который автор писал два года.", 1, new DateTime(1879, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Братья Карамазовы" },
                    { 9, 2, 4.2000000000000002, null, 4, "В обстановке «великих реформ» книга стала сенсацией и привлекла к себе всеобщее внимание, а образ главного героя Евгения Базарова был воспринят как воплощение нового, пореформенного поколения, став примером для подражания молодёжи 1860-х гг. Свойственные Базарову бескомпромиссность, отсутствие преклонения перед авторитетами и старыми истинами, приоритет полезного над прекрасным стали идеалами первого поколения пореформенной интеллигенции", "роман И. С. Тургенева, написанный в 1860—1861 годах и опубликованный в 1862 году в журнале «Русский вестник»", 1, new DateTime(1862, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Отцы и дети" },
                    { 1, 4, 5.0, 1, 4, "Родителей годовалого Гарри Поттера убивает Волан-де-Морт, после чего исчезает при попытке убить самого Гарри. Поздно вечером директор школы волшебства Хогвартс Альбус Дамблдор и его заместитель Минерва МакГонагалл появляются возле дома Вернона и Петуньи Дурсль, единственных родственников Гарри.", "первый роман в серии книг про юного волшебника Гарри Поттера", 6, new DateTime(1997, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Гарри Поттер и философский камень" },
                    { 2, 4, 4.2000000000000002, 1, 4, "Книга рассказывает о втором учебном годе в школе чародейства и волшебства Хогвартс, на котором Гарри и его друзья — Рон Уизли и Гермиона Грейнджер — расследуют таинственные нападения на учеников школы, совершаемые неким «Наследником Слизерина». Объектами нападений являются ученики, среди родственников которых есть неволшебники.", "второй роман в серии книг про юного волшебника Гарри Поттера", 6, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Гарри Поттер и тайная комната" },
                    { 3, 5, 4.2000000000000002, 2, 3, "В этом рассказе Геральт встречается с человеком по имени Борх Три Галки и двумя его телохранительницами из далёкой Зеррикании. Они отправляются по дороге, но наталкиваются на оцепление. Находящийся здесь же Лютик даёт разъяснения. В Голополье повадился летать зелёный дракон, а местный сапожник Козоед придумал, как его отравить.", "Это второе произведение из цикла «Ведьмак» как по хронологии, так и по времени написания. В этой части Геральт впервые встречает Цири и находит своё предназначение.", 6, new DateTime(1992, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Меч Предназначения" },
                    { 4, 5, 4.4000000000000004, 2, 3, "Это первое произведение из цикла «Ведьмак» как по хронологии, так и по времени написания. От первого издания в виде книги «Ведьмак» «Последнее желание» отличается связующей серией интерлюдий «Глас рассудка» и наличием рассказов «Последнее желание» и «Край света».", "сборник рассказов писателя Анджея Сапковского в жанре фэнтези", 6, new DateTime(1993, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Последнее желание" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Password", "RoleId" },
                values: new object[,]
                {
                    { 1, "log1", "pass1", 1 },
                    { 2, "log2", "pass2", 2 },
                    { 3, "log3", "pass3", 3 },
                    { 4, "log4", "pass4", 4 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "BookId", "Pseudonim", "Rating", "ReviewString", "UserId" },
                values: new object[] { 1, 1, "Commentator1", 4.5, "Интересно", 1 });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "BookId", "Pseudonim", "Rating", "ReviewString", "UserId" },
                values: new object[] { 2, 2, "Commentator2", 2.5, "Не очень", 1 });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "BookId", "Pseudonim", "Rating", "ReviewString", "UserId" },
                values: new object[] { 3, 2, "Commentator3", 4.0, "Прикольно", 4 });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookSeriesId",
                table: "Books",
                column: "BookSeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookStatusId",
                table: "Books",
                column: "BookStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_GenreId",
                table: "Books",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_BookToTags_BookId",
                table: "BookToTags",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookToTags_TagId",
                table: "BookToTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BookId",
                table: "Reviews",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookToTags");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "BookSeries");

            migrationBuilder.DropTable(
                name: "BookStatuses");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
