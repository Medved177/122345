using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.DataAccess.Migrations
{
    public partial class start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
