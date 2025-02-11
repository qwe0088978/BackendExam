using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyOfficeAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MyOffice_ACPD",
                columns: table => new
                {
                    ACPD_SID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ACPD_Cname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ACPD_Ename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ACPD_Sname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ACPD_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ACPD_Status = table.Column<byte>(type: "tinyint", nullable: false),
                    ACPD_Stop = table.Column<bool>(type: "bit", nullable: false),
                    ACPD_StopMemo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ACPD_LoginID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ACPD_LoginPWD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ACPD_Memo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ACPD_NowDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ACPD_NowID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ACPD_UPDDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ACPD_UPDID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyOffice_ACPD", x => x.ACPD_SID);
                });

            migrationBuilder.CreateTable(
                name: "MyOffice_ExcuteionLog",
                columns: table => new
                {
                    DeLog_AutoID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeLog_StoredPrograms = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeLog_GroupID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeLog_isCustomDebug = table.Column<bool>(type: "bit", nullable: false),
                    DeLog_ExecutionProgram = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeLog_ExecutionInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeLog_verifyNeeded = table.Column<bool>(type: "bit", nullable: false),
                    DeLog_ExDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyOffice_ExcuteionLog", x => x.DeLog_AutoID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyOffice_ACPD");

            migrationBuilder.DropTable(
                name: "MyOffice_ExcuteionLog");
        }
    }
}
