using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIService.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "APIDefinitions",
                columns: table => new
                {
                    Ksuid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APIDefinitions", x => x.Ksuid);
                });

            migrationBuilder.CreateTable(
                name: "APIFields",
                columns: table => new
                {
                    Ksuid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    APIDefinitionKsuid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APIFields", x => x.Ksuid);
                    table.ForeignKey(
                        name: "FK_APIFields_APIDefinitions_APIDefinitionKsuid",
                        column: x => x.APIDefinitionKsuid,
                        principalTable: "APIDefinitions",
                        principalColumn: "Ksuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_APIFields_APIDefinitionKsuid",
                table: "APIFields",
                column: "APIDefinitionKsuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "APIFields");

            migrationBuilder.DropTable(
                name: "APIDefinitions");
        }
    }
}
