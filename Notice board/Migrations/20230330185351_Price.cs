using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Notice_board.Migrations
{
    /// <inheritdoc />
    public partial class Price : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Adverts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Electronic" },
                    { 2, "Sport" },
                    { 3, "Toys & Hobbies" }
                });

            migrationBuilder.InsertData(
                table: "Adverts",
                columns: new[] { "Id", "CategoryId", "City", "ContactInformation", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Rovno", "0974585652", "Normal view", "MacBook 2019", 1500 },
                    { 2, 1, "Luchk", "0634584521", "Cool view", "Iphone 13", 850 },
                    { 3, 1, "Lviv", "0665241245", "New", "MacBook 2021", 2200 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Adverts");
        }
    }
}
