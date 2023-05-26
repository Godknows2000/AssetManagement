using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class assetfields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "AssetRequest");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Supplier",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DepartmentId",
                table: "AssetRequest",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "AssetId",
                table: "AssetRequest",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AssetLocation",
                table: "AssetRequest",
                type: "character varying",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AttachmentsJson",
                table: "AssetRequest",
                type: "character varying",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "AssetRequest",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                table: "AssetRequest",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "AssetRequest",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "NotesJson",
                table: "AssetRequest",
                type: "character varying",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "AssetRequest",
                type: "character varying",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequestComments",
                table: "AssetRequest",
                type: "character varying",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "AssetRequest",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "AssetRequest",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Asset",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssetRequest_AssetId",
                table: "AssetRequest",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetRequest_CreatorId",
                table: "AssetRequest",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetRequest_EmployeeId",
                table: "AssetRequest",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "Asset",
                table: "AssetRequest",
                column: "AssetId",
                principalTable: "Asset",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "Creator",
                table: "AssetRequest",
                column: "CreatorId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "Employee",
                table: "AssetRequest",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Asset",
                table: "AssetRequest");

            migrationBuilder.DropForeignKey(
                name: "Creator",
                table: "AssetRequest");

            migrationBuilder.DropForeignKey(
                name: "Employee",
                table: "AssetRequest");

            migrationBuilder.DropIndex(
                name: "IX_AssetRequest_AssetId",
                table: "AssetRequest");

            migrationBuilder.DropIndex(
                name: "IX_AssetRequest_CreatorId",
                table: "AssetRequest");

            migrationBuilder.DropIndex(
                name: "IX_AssetRequest_EmployeeId",
                table: "AssetRequest");

            migrationBuilder.DropColumn(
                name: "AssetId",
                table: "AssetRequest");

            migrationBuilder.DropColumn(
                name: "AssetLocation",
                table: "AssetRequest");

            migrationBuilder.DropColumn(
                name: "AttachmentsJson",
                table: "AssetRequest");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "AssetRequest");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "AssetRequest");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "AssetRequest");

            migrationBuilder.DropColumn(
                name: "NotesJson",
                table: "AssetRequest");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "AssetRequest");

            migrationBuilder.DropColumn(
                name: "RequestComments",
                table: "AssetRequest");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "AssetRequest");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "AssetRequest");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Supplier",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<Guid>(
                name: "DepartmentId",
                table: "AssetRequest",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AssetRequest",
                type: "character varying",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Asset",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");
        }
    }
}
