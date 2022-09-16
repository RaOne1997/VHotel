using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MakeMuTrip.Migrations
{
    public partial class AccountAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountRefID",
                table: "customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Account",
                schema: "Master",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<long>(type: "nvarchar(10)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_customers_AccountRefID",
                table: "customers",
                column: "AccountRefID");

            migrationBuilder.AddForeignKey(
                name: "FK_customers_Account_AccountRefID",
                table: "customers",
                column: "AccountRefID",
                principalSchema: "Master",
                principalTable: "Account",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_customers_Account_AccountRefID",
                table: "customers");

            migrationBuilder.DropTable(
                name: "Account",
                schema: "Master");

            migrationBuilder.DropIndex(
                name: "IX_customers_AccountRefID",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "AccountRefID",
                table: "customers");
        }
    }
}
