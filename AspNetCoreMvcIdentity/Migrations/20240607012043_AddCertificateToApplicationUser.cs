using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetCoreMvcIdentity.Migrations
{
    /// <inheritdoc />
    public partial class AddCertificateToApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Certificate",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Certificate",
                table: "AspNetUsers");
        }
    }
}
