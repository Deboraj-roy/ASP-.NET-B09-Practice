using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstDemo.Web.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAspNetUserRolesPrimaryKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
            name: "PK_AspNetUserRoles",
            table: "AspNetUserRoles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
           name: "PK_AspNetUserRoles",
           table: "AspNetUserRoles",
           columns: new[] { "UserId", "RoleId" });
        }
    }
}
