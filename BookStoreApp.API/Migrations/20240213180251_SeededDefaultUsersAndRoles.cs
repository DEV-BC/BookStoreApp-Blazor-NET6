using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreApp.API.Migrations
{
    public partial class SeededDefaultUsersAndRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1ee2dac6-cd92-47df-926b-434bbbb6c224", "72974497-6bc4-4372-a349-5e905bdb587f", "Administrator", "ADMINISTRATOR" },
                    { "8acb30bc-cf06-47cf-a56a-ef717a689615", "932fa3e0-b8ed-4d9a-82c6-463893c7fe3f", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "bd11bb2f-f7c7-493c-8ccd-fca9db465d16", 0, "4b8eecb0-a7f2-4377-98bb-d549ad49f698", "user@bookstore.com", false, "System", "User", false, null, "USER@BOOKSTORE.COM", "USER@BOOKSTORE.COM", "AQAAAAEAACcQAAAAEG2iF2VrEVjz1wsBV4vrof9iN4LAuABTKbSP+wRlJ6xlcIbfyX6uk+eeTQrlHCLWcg==", null, false, "2a300dfc-6bc1-45c0-87f0-1d2f0a72f840", false, "user@bookstore.com" },
                    { "e5119dd6-28c1-4f43-9dd6-f49f03f0fd69", 0, "1f362676-4cda-4d18-8c97-07d6d1e64c75", "admin@bookstore.com", false, "System", "Admin", false, null, "ADMIN@BOOKSTORE.COM", "ADMIN@BOOKSTORE.COM", "AQAAAAEAACcQAAAAEHTpflV0amke1/SA8Nwbnv+a8eyUPHMxXo3e09CFWgwgR9QRxrJlvpgp57QnB78ToQ==", null, false, "d08d3fca-f0aa-44d1-a9bd-a966d2a5254d", false, "admin@bookstore.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8acb30bc-cf06-47cf-a56a-ef717a689615", "bd11bb2f-f7c7-493c-8ccd-fca9db465d16" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1ee2dac6-cd92-47df-926b-434bbbb6c224", "e5119dd6-28c1-4f43-9dd6-f49f03f0fd69" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8acb30bc-cf06-47cf-a56a-ef717a689615", "bd11bb2f-f7c7-493c-8ccd-fca9db465d16" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1ee2dac6-cd92-47df-926b-434bbbb6c224", "e5119dd6-28c1-4f43-9dd6-f49f03f0fd69" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ee2dac6-cd92-47df-926b-434bbbb6c224");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8acb30bc-cf06-47cf-a56a-ef717a689615");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bd11bb2f-f7c7-493c-8ccd-fca9db465d16");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e5119dd6-28c1-4f43-9dd6-f49f03f0fd69");
        }
    }
}
