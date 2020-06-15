using Microsoft.EntityFrameworkCore.Migrations;

namespace LeaveManageAPP.Data.Migrations
{
    public partial class AddedisActivefiledinLeaveType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "LeaveTypes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                table: "LeaveTypes");
        }
    }
}
