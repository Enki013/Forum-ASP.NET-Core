using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetCoreMvcIdentity.Migrations
{
    /// <inheritdoc />
    public partial class quatecomment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QuotedReplyContent",
                table: "PostReplays",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuotedReplyId",
                table: "PostReplays",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuotedReplyContent",
                table: "PostReplays");

            migrationBuilder.DropColumn(
                name: "QuotedReplyId",
                table: "PostReplays");
        }
    }
}
