using Microsoft.EntityFrameworkCore.Migrations;

namespace BiddingWebAPI.EFCore.Migrations
{
    public partial class Remove_Client_ServiceProvider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestComments_ServiceProviders_ServiceProviderID",
                table: "RequestComments");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Clients_ClientID",
                table: "Requests");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "ServiceProviders");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestComments_Users_ServiceProviderID",
                table: "RequestComments",
                column: "ServiceProviderID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Users_ClientID",
                table: "Requests",
                column: "ClientID",
                principalTable: "Users",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestComments_Users_ServiceProviderID",
                table: "RequestComments");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Users_ClientID",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Clients_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceProviders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProviders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ServiceProviders_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_UserID",
                table: "Clients",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviders_UserID",
                table: "ServiceProviders",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestComments_ServiceProviders_ServiceProviderID",
                table: "RequestComments",
                column: "ServiceProviderID",
                principalTable: "ServiceProviders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Clients_ClientID",
                table: "Requests",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
