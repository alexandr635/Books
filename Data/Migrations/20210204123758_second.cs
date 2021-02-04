using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Biography", "DateOfBirth", "DateOfDie", "LastName", "Name", "Patronymic", "PlaceOfBirth" },
                values: new object[,]
                {
                    { 1, "Происхождение Александра Сергеевича Пушкина идёт от разветвлённого нетитулованного дворянского рода Пушкиных, восходившего по генеалогической легенде к «мужу честну» Ратше. Пушкин неоднократно писал о своей родословной в стихах и прозе; он видел в своих предках образец истинной «аристократии», древнего рода, честно служившего отечеству, но не снискавшего благосклонности правителей и «гонимого». Не раз он обращался (в том числе в художественной форме) и к образу своего прадеда по матери — африканца Абрама Петровича Ганнибала, ставшего слугой и воспитанником Петра I, а потом военным инженером и генералом", new DateTime(1799, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1837, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Пушкин", "Александр", "Сергеевич", "Москва, Российская империя" },
                    { 2, "Семья Ивана Сергеевича Тургенева происходила из древнего рода тульских дворян Тургеневых. В памятной книжке мать будущего писателя записала: «1818 года 28 октября, в понедельник, родился сын Иван, ростом 12 вершков, в Орле, в своём доме, в 12 часов утра. Крестили 4-го числа ноября, Феодор Семёнович Уваров с сестрою Федосьей Николаевной Тепловой»", new DateTime(1818, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1883, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Тургенев", "Иван", "Сергеевич", "Орёл, Российская империя" },
                    { 3, "После смерти Достоевский был признан классиком русской литературы и одним из лучших романистов мирового значения, считается первым представителем персонализма в России. Творчество русского писателя оказало воздействие на мировую литературу, в частности на творчество ряда лауреатов Нобелевской премии по литературе, философов Фридриха Ницше и Жана-Поль Сартра, а также на становление экзистенциализма и фрейдизма", new DateTime(1821, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1881, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Достоевский", "Федор", "Михайлович", "Москва, Российская империя" }
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
                    { 1, "Роман" },
                    { 2, "Рассказ" },
                    { 3, "Повесть" },
                    { 4, "Сказка" },
                    { 5, "Поэма" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BookStatuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BookStatuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BookStatuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BookStatuses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
