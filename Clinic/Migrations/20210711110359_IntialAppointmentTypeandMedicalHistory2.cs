using Microsoft.EntityFrameworkCore.Migrations;

namespace Clinic.Migrations
{
    public partial class IntialAppointmentTypeandMedicalHistory2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AppointmentType_AppointmentId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistory_Patients_PatientId",
                table: "MedicalHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalHistory",
                table: "MedicalHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppointmentType",
                table: "AppointmentType");

            migrationBuilder.RenameTable(
                name: "MedicalHistory",
                newName: "MedicalHistories");

            migrationBuilder.RenameTable(
                name: "AppointmentType",
                newName: "AppointmentTypes");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalHistory_PatientId",
                table: "MedicalHistories",
                newName: "IX_MedicalHistories_PatientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalHistories",
                table: "MedicalHistories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppointmentTypes",
                table: "AppointmentTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AppointmentTypes_AppointmentId",
                table: "Appointments",
                column: "AppointmentId",
                principalTable: "AppointmentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistories_Patients_PatientId",
                table: "MedicalHistories",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AppointmentTypes_AppointmentId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistories_Patients_PatientId",
                table: "MedicalHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalHistories",
                table: "MedicalHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppointmentTypes",
                table: "AppointmentTypes");

            migrationBuilder.RenameTable(
                name: "MedicalHistories",
                newName: "MedicalHistory");

            migrationBuilder.RenameTable(
                name: "AppointmentTypes",
                newName: "AppointmentType");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalHistories_PatientId",
                table: "MedicalHistory",
                newName: "IX_MedicalHistory_PatientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalHistory",
                table: "MedicalHistory",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppointmentType",
                table: "AppointmentType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AppointmentType_AppointmentId",
                table: "Appointments",
                column: "AppointmentId",
                principalTable: "AppointmentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistory_Patients_PatientId",
                table: "MedicalHistory",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
