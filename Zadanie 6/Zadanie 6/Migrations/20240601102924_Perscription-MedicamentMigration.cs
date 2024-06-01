using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zadanie_6.Migrations
{
    /// <inheritdoc />
    public partial class PerscriptionMedicamentMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Doctors_DoctorIdDoctor",
                table: "Prescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Patients_PatientIdPatient",
                table: "Prescriptions");

            migrationBuilder.RenameColumn(
                name: "PatientIdPatient",
                table: "Prescriptions",
                newName: "IdPatient");

            migrationBuilder.RenameColumn(
                name: "DoctorIdDoctor",
                table: "Prescriptions",
                newName: "IdDoctor");

            migrationBuilder.RenameIndex(
                name: "IX_Prescriptions_PatientIdPatient",
                table: "Prescriptions",
                newName: "IX_Prescriptions_IdPatient");

            migrationBuilder.RenameIndex(
                name: "IX_Prescriptions_DoctorIdDoctor",
                table: "Prescriptions",
                newName: "IX_Prescriptions_IdDoctor");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Doctors_IdDoctor",
                table: "Prescriptions",
                column: "IdDoctor",
                principalTable: "Doctors",
                principalColumn: "IdDoctor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Patients_IdPatient",
                table: "Prescriptions",
                column: "IdPatient",
                principalTable: "Patients",
                principalColumn: "IdPatient",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Doctors_IdDoctor",
                table: "Prescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Patients_IdPatient",
                table: "Prescriptions");

            migrationBuilder.RenameColumn(
                name: "IdPatient",
                table: "Prescriptions",
                newName: "PatientIdPatient");

            migrationBuilder.RenameColumn(
                name: "IdDoctor",
                table: "Prescriptions",
                newName: "DoctorIdDoctor");

            migrationBuilder.RenameIndex(
                name: "IX_Prescriptions_IdPatient",
                table: "Prescriptions",
                newName: "IX_Prescriptions_PatientIdPatient");

            migrationBuilder.RenameIndex(
                name: "IX_Prescriptions_IdDoctor",
                table: "Prescriptions",
                newName: "IX_Prescriptions_DoctorIdDoctor");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Doctors_DoctorIdDoctor",
                table: "Prescriptions",
                column: "DoctorIdDoctor",
                principalTable: "Doctors",
                principalColumn: "IdDoctor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Patients_PatientIdPatient",
                table: "Prescriptions",
                column: "PatientIdPatient",
                principalTable: "Patients",
                principalColumn: "IdPatient",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
