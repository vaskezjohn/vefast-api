using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace vefast_src.Migrations
{
    public partial class ForegnKey2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "changePassword",
                table: "Users",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "downLogic",
                table: "Users",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "refreshToken",
                table: "Users",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "token",
                table: "Users",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "tokenExpires",
                table: "Users",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserGroup_group_id",
                table: "UserGroup",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroup_user_id",
                table: "UserGroup",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroup_Groups_group_id",
                table: "UserGroup",
                column: "group_id",
                principalTable: "Groups",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroup_Users_user_id",
                table: "UserGroup",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGroup_Groups_group_id",
                table: "UserGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroup_Users_user_id",
                table: "UserGroup");

            migrationBuilder.DropIndex(
                name: "IX_UserGroup_group_id",
                table: "UserGroup");

            migrationBuilder.DropIndex(
                name: "IX_UserGroup_user_id",
                table: "UserGroup");

            migrationBuilder.DropColumn(
                name: "changePassword",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "downLogic",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "refreshToken",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "token",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "tokenExpires",
                table: "Users");
        }
    }
}
