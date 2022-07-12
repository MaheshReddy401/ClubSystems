using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClubSystemsDemo.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserDetails",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Forename = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetails", x => x.PersonID);
                });

            migrationBuilder.CreateTable(
                name: "MembershipDetails",
                columns: table => new
                {
                    MemebershipID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AccountBalance = table.Column<decimal>(type: "money", nullable: false),
                    PersonID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipDetails", x => x.MemebershipID);
                    table.ForeignKey(
                        name: "FK_MembershipDetails_UserDetails_PersonID",
                        column: x => x.PersonID,
                        principalTable: "UserDetails",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UserDetails",
                columns: new[] { "PersonID", "EmailAddress", "Forename", "Surname" },
                values: new object[] { 1, "Carson.Alexander@gmail.com", "Carson", "Alexander" });

            migrationBuilder.InsertData(
                table: "UserDetails",
                columns: new[] { "PersonID", "EmailAddress", "Forename", "Surname" },
                values: new object[] { 2, "Carson.Alexander@hotmail.com", "Carson", "Alexander2" });

            migrationBuilder.InsertData(
                table: "UserDetails",
                columns: new[] { "PersonID", "EmailAddress", "Forename", "Surname" },
                values: new object[] { 3, "Ajay.Peddapala@hotmail.com", "Ajay", "Peddapala" });

            migrationBuilder.InsertData(
                table: "MembershipDetails",
                columns: new[] { "MemebershipID", "AccountBalance", "PersonID", "Type" },
                values: new object[,]
                {
                    { 1, 10m, 1, "Primary" },
                    { 2, 10m, 1, "Secondary" },
                    { 3, -15m, 2, "Primary" },
                    { 4, -5m, 3, "Basic" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MembershipDetails_PersonID",
                table: "MembershipDetails",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_MembershipDetails_Type_PersonID",
                table: "MembershipDetails",
                columns: new[] { "Type", "PersonID" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MembershipDetails");

            migrationBuilder.DropTable(
                name: "UserDetails");
        }
    }
}
