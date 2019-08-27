using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GifFind.API.Migrations
{
    public partial class Init_GifFind : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<Guid>(nullable: false),
                    UserID = table.Column<Guid>(nullable: false),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "SavedImages",
                columns: table => new
                {
                    SavedImageID = table.Column<Guid>(nullable: false),
                    CategoryID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedImages", x => x.SavedImageID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "SavedImages");
        }
    }
}
