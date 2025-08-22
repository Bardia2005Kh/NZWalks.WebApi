using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWallks.API.Migrations
{
    /// <inheritdoc />
    public partial class seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_walks_difficulties_DifficultyId",
                table: "walks");

            migrationBuilder.DropForeignKey(
                name: "FK_walks_regions_RegionId",
                table: "walks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_walks",
                table: "walks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_regions",
                table: "regions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_difficulties",
                table: "difficulties");

            migrationBuilder.RenameTable(
                name: "walks",
                newName: "Walks");

            migrationBuilder.RenameTable(
                name: "regions",
                newName: "Regions");

            migrationBuilder.RenameTable(
                name: "difficulties",
                newName: "Difficulties");

            migrationBuilder.RenameIndex(
                name: "IX_walks_RegionId",
                table: "Walks",
                newName: "IX_Walks_RegionId");

            migrationBuilder.RenameIndex(
                name: "IX_walks_DifficultyId",
                table: "Walks",
                newName: "IX_Walks_DifficultyId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Walks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Walks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Regions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Regions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Difficulties",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Walks",
                table: "Walks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Regions",
                table: "Regions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Difficulties",
                table: "Difficulties",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("4ac5cbcb-c5d0-4dd5-b7e5-476cddab9746"), "Medium" },
                    { new Guid("96c9f1fd-4241-4b67-af7c-890c90795eed"), "Hard" },
                    { new Guid("f660183c-2740-43e7-bc14-d181581a9cc2"), "Easy" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("1c3d4e5f-6a7b-8c9d-0e1f-2a3b4c5d6e7f"), "MHD", "Mashhad", "some-mashhad-image-url.jpg" },
                    { new Guid("2d4e5f6a-7b8c-9d0e-1f2a-3b4c5d6e7f8a"), "TBZ", "Tabriz", "some-tabriz-image-url.jpg" },
                    { new Guid("3b146646-6a25-42de-961c-3095257625f1"), "KRJ", "Karaj", "Some-Images-URL.jpg" },
                    { new Guid("65c77947-4986-416c-8c4d-d77ffac47922"), "TEH", "Tehran", "Some-Images-URL.jpg" },
                    { new Guid("7a1b2c3d-4e5f-6a7b-8c9d-0e1f2a3b4c5d"), "SHZ", "Shiraz", "some-shiraz-image-url.jpg" },
                    { new Guid("9b2c3d4e-5f6a-7b8c-9d0e-1f2a3b4c5d6e"), "ISF", "Isfahan", "some-isfahan-image-url.jpg" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Walks_Difficulties_DifficultyId",
                table: "Walks",
                column: "DifficultyId",
                principalTable: "Difficulties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Walks_Regions_RegionId",
                table: "Walks",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Walks_Difficulties_DifficultyId",
                table: "Walks");

            migrationBuilder.DropForeignKey(
                name: "FK_Walks_Regions_RegionId",
                table: "Walks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Walks",
                table: "Walks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Regions",
                table: "Regions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Difficulties",
                table: "Difficulties");

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("4ac5cbcb-c5d0-4dd5-b7e5-476cddab9746"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("96c9f1fd-4241-4b67-af7c-890c90795eed"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("f660183c-2740-43e7-bc14-d181581a9cc2"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("1c3d4e5f-6a7b-8c9d-0e1f-2a3b4c5d6e7f"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("2d4e5f6a-7b8c-9d0e-1f2a-3b4c5d6e7f8a"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("3b146646-6a25-42de-961c-3095257625f1"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("65c77947-4986-416c-8c4d-d77ffac47922"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("7a1b2c3d-4e5f-6a7b-8c9d-0e1f2a3b4c5d"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("9b2c3d4e-5f6a-7b8c-9d0e-1f2a3b4c5d6e"));

            migrationBuilder.RenameTable(
                name: "Walks",
                newName: "walks");

            migrationBuilder.RenameTable(
                name: "Regions",
                newName: "regions");

            migrationBuilder.RenameTable(
                name: "Difficulties",
                newName: "difficulties");

            migrationBuilder.RenameIndex(
                name: "IX_Walks_RegionId",
                table: "walks",
                newName: "IX_walks_RegionId");

            migrationBuilder.RenameIndex(
                name: "IX_Walks_DifficultyId",
                table: "walks",
                newName: "IX_walks_DifficultyId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "walks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "walks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "regions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "regions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "difficulties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_walks",
                table: "walks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_regions",
                table: "regions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_difficulties",
                table: "difficulties",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_walks_difficulties_DifficultyId",
                table: "walks",
                column: "DifficultyId",
                principalTable: "difficulties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_walks_regions_RegionId",
                table: "walks",
                column: "RegionId",
                principalTable: "regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
