using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Logic.Migrations
{
    /// <inheritdoc />
    public partial class EditAdminAccountAndAddDoctorRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'6ade61a6-919b-4b2b-bb0d-385df0af719a', N'Doctor', N'DOCTOR', NULL)
GO
UPDATE [dbo].[AspNetUsers] set ProfilePhoto = 'default.png' where id = '52594980-4d11-4924-8672-1a307728e2e3'
GO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
