using Microsoft.EntityFrameworkCore.Migrations;

namespace Clinic.Migrations
{
    public partial class IntialAppointmentTypeandMedicalHistory1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AppointmentType_AppointmentTypeId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_AppointmentTypeId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "AppointmentTypeId",
                table: "Appointments");

            migrationBuilder.AddColumn<long>(
                name: "AppointmentId",
                table: "Appointments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_AppointmentId",
                table: "Appointments",
                column: "AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AppointmentType_AppointmentId",
                table: "Appointments",
                column: "AppointmentId",
                principalTable: "AppointmentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AppointmentType_AppointmentId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_AppointmentId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "Appointments");

            migrationBuilder.AddColumn<long>(
                name: "AppointmentTypeId",
                table: "Appointments",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_AppointmentTypeId",
                table: "Appointments",
                column: "AppointmentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AppointmentType_AppointmentTypeId",
                table: "Appointments",
                column: "AppointmentTypeId",
                principalTable: "AppointmentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
