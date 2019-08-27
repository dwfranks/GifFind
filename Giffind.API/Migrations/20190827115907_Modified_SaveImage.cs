using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GifFind.API.Migrations
{
    public partial class Modified_SaveImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SavedImages_Categories_CategoryID",
                table: "SavedImages");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "SavedImages",
                newName: "categoryid");

            migrationBuilder.RenameColumn(
                name: "SourceID",
                table: "SavedImages",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "SavedImageID",
                table: "SavedImages",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_SavedImages_CategoryID",
                table: "SavedImages",
                newName: "IX_SavedImages_categoryid");

            migrationBuilder.AddColumn<string>(
                name: "imageid",
                table: "SavedImages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "orgin_url",
                table: "SavedImages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "source_url",
                table: "SavedImages",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SavedOriginals",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    saved_imageid = table.Column<Guid>(nullable: false),
                    url = table.Column<string>(nullable: true),
                    width = table.Column<string>(nullable: true),
                    height = table.Column<string>(nullable: true),
                    size = table.Column<string>(nullable: true),
                    frames = table.Column<string>(nullable: true),
                    mp4 = table.Column<string>(nullable: true),
                    mp4_size = table.Column<string>(nullable: true),
                    webp = table.Column<string>(nullable: true),
                    webp_size = table.Column<string>(nullable: true),
                    hash = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedOriginals", x => x.id);
                    table.ForeignKey(
                        name: "FK_SavedOriginals_SavedImages_saved_imageid",
                        column: x => x.saved_imageid,
                        principalTable: "SavedImages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SavedOriginalStills",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    saved_imageid = table.Column<Guid>(nullable: false),
                    url = table.Column<string>(nullable: true),
                    width = table.Column<string>(nullable: true),
                    height = table.Column<string>(nullable: true),
                    size = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedOriginalStills", x => x.id);
                    table.ForeignKey(
                        name: "FK_SavedOriginalStills_SavedImages_saved_imageid",
                        column: x => x.saved_imageid,
                        principalTable: "SavedImages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SavedPreviewGifs",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    saved_imageid = table.Column<Guid>(nullable: false),
                    url = table.Column<string>(nullable: true),
                    width = table.Column<string>(nullable: true),
                    height = table.Column<string>(nullable: true),
                    size = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedPreviewGifs", x => x.id);
                    table.ForeignKey(
                        name: "FK_SavedPreviewGifs_SavedImages_saved_imageid",
                        column: x => x.saved_imageid,
                        principalTable: "SavedImages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SavedOriginals_saved_imageid",
                table: "SavedOriginals",
                column: "saved_imageid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SavedOriginalStills_saved_imageid",
                table: "SavedOriginalStills",
                column: "saved_imageid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SavedPreviewGifs_saved_imageid",
                table: "SavedPreviewGifs",
                column: "saved_imageid",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SavedImages_Categories_categoryid",
                table: "SavedImages",
                column: "categoryid",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SavedImages_Categories_categoryid",
                table: "SavedImages");

            migrationBuilder.DropTable(
                name: "SavedOriginals");

            migrationBuilder.DropTable(
                name: "SavedOriginalStills");

            migrationBuilder.DropTable(
                name: "SavedPreviewGifs");

            migrationBuilder.DropColumn(
                name: "imageid",
                table: "SavedImages");

            migrationBuilder.DropColumn(
                name: "orgin_url",
                table: "SavedImages");

            migrationBuilder.DropColumn(
                name: "source_url",
                table: "SavedImages");

            migrationBuilder.RenameColumn(
                name: "categoryid",
                table: "SavedImages",
                newName: "CategoryID");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "SavedImages",
                newName: "SourceID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "SavedImages",
                newName: "SavedImageID");

            migrationBuilder.RenameIndex(
                name: "IX_SavedImages_categoryid",
                table: "SavedImages",
                newName: "IX_SavedImages_CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_SavedImages_Categories_CategoryID",
                table: "SavedImages",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
