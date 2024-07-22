﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayGround.API.Data.Migrations
{
	/// <inheritdoc />
	public partial class Init : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Posters",
				columns: table => new
				{
					Id = table.Column<int>(type: "INTEGER", nullable: false)
						.Annotation("Sqlite:Autoincrement", true),
					Name = table.Column<string>(type: "TEXT", nullable: false),
					UserId = table.Column<int>(type: "INTEGER", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Posters", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "ImageInfos",
				columns: table => new
				{
					Id = table.Column<int>(type: "INTEGER", nullable: false)
						.Annotation("Sqlite:Autoincrement", true),
					SavedName = table.Column<string>(type: "TEXT", nullable: false),
					PosterId = table.Column<int>(type: "INTEGER", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_ImageInfos", x => x.Id);
					table.ForeignKey(
						name: "FK_ImageInfos_Posters_PosterId",
						column: x => x.PosterId,
						principalTable: "Posters",
						principalColumn: "Id");
				});

			migrationBuilder.CreateIndex(
				name: "IX_ImageInfos_PosterId",
				table: "ImageInfos",
				column: "PosterId");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "ImageInfos");

			migrationBuilder.DropTable(
				name: "Posters");
		}
	}
}
