using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetCoreMvcIdentity.Migrations
{
    /// <inheritdoc />
    public partial class AddParentReplyIdToPosts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentReplyId",
                table: "PostReplays",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostReplays_ParentReplyId",
                table: "PostReplays",
                column: "ParentReplyId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostReplays_PostReplays_ParentReplyId",
                table: "PostReplays",
                column: "ParentReplyId",
                principalTable: "PostReplays",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostReplays_PostReplays_ParentReplyId",
                table: "PostReplays");

            migrationBuilder.DropIndex(
                name: "IX_PostReplays_ParentReplyId",
                table: "PostReplays");

            migrationBuilder.DropColumn(
                name: "ParentReplyId",
                table: "PostReplays");
        }
    }
}
