using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatService.Migrations
{
    /// <inheritdoc />
    public partial class changeEnityies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "dateTime",
                table: "UserLastSeen",
                newName: "DateTime");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "UserLastSeen",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "UserLastSeen",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "chanel_id",
                table: "UserLastSeen",
                newName: "ChanelId");

            migrationBuilder.RenameColumn(
                name: "dateTime",
                table: "Message",
                newName: "DateTime");

            migrationBuilder.RenameColumn(
                name: "content",
                table: "Message",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Message",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "Message",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "chanel_id",
                table: "Message",
                newName: "ChanelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "UserLastSeen",
                newName: "dateTime");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserLastSeen",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserLastSeen",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "ChanelId",
                table: "UserLastSeen",
                newName: "chanel_id");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Message",
                newName: "dateTime");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Message",
                newName: "content");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Message",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Message",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "ChanelId",
                table: "Message",
                newName: "chanel_id");
        }
    }
}
