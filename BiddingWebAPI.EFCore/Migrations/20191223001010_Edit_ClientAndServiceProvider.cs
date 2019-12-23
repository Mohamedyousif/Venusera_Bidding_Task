using Microsoft.EntityFrameworkCore.Migrations;

namespace BiddingWebAPI.EFCore.Migrations
{
    public partial class Edit_ClientAndServiceProvider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Clients_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ServiceProviders",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    UserID = table.Column<int>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "RequestComments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestID = table.Column<int>(nullable: false),
                    ServiceProviderID = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestComments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RequestComments_Requests_RequestID",
                        column: x => x.RequestID,
                        principalTable: "Requests",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestComments_ServiceProviders_ServiceProviderID",
                        column: x => x.ServiceProviderID,
                        principalTable: "ServiceProviders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_UserID",
                table: "Clients",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_RequestComments_RequestID",
                table: "RequestComments",
                column: "RequestID");

            migrationBuilder.CreateIndex(
                name: "IX_RequestComments_ServiceProviderID",
                table: "RequestComments",
                column: "ServiceProviderID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviders_UserID",
                table: "ServiceProviders",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Clients_ClientID",
                table: "Requests",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Clients_ClientID",
                table: "Requests");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "RequestComments");

            migrationBuilder.DropTable(
                name: "ServiceProviders");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Users_ClientID",
                table: "Requests",
                column: "ClientID",
                principalTable: "Users",
                principalColumn: "ID"
                );
        }
    }
}
