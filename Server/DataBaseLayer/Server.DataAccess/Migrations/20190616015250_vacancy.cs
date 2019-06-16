using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.DataAccess.Migrations
{
    public partial class vacancy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.InsertData(
                table: "Vacancies",
                columns: new[] { "Id", "Education", "Experience", "Know", "Name", "Salary", "Task" },
                values: new object[,]
                {
                    { 1, "Высшее", null, "опыт работы и знание особенностей одного из JS-фреймворков (Knockout, Backbone, Marionette JS, AngularJS, jQuery);", "Младший программист", 25000, "работать с большими и сложными проектами" },
                    { 2, "Высшее", null, "опыт работы и знание особенностей одного из JS-фреймворков (Knockout, Backbone, Marionette JS, AngularJS, jQuery);", "Младший программист", 25000, "работать с большими и сложными проектами" },
                    { 3, "Высшее", null, "опыт работы и знание особенностей одного из JS-фреймворков (Knockout, Backbone, Marionette JS, AngularJS, jQuery);", "Младший программист", 25000, "работать с большими и сложными проектами" },
                    { 4, "Высшее", null, "опыт работы и знание особенностей одного из JS-фреймворков (Knockout, Backbone, Marionette JS, AngularJS, jQuery);", "Младший программист", 25000, "работать с большими и сложными проектами" },
                    { 5, "Высшее", null, "опыт работы и знание особенностей одного из JS-фреймворков (Knockout, Backbone, Marionette JS, AngularJS, jQuery);", "Младший программист", 25000, "работать с большими и сложными проектами" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "Family", "Mname", "Name", "Year" },
                values: new object[,]
                {
                    { 1, "Ivanov@mail.ru", "Иванов", "Иванович", "Иван", 25 },
                    { 2, "Petrov@mail.ru", "Петров", "Петрович", "Петр", 24 },
                    { 3, "Nick@mail.ru", "Николайченко", "Николаевич", "Николай", 25 },
                    { 4, "Borisov@mail.ru", "Борисов", "Борисович", "Сергей", 30 },
                    { 5, "Antonova@mail.ru", "Антонова", "Степановна", "Антонина", 27 }
                });
        }
    }
}
