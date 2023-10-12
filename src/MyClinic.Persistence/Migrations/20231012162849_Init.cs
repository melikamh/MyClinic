using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyClinic.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Specialization = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NationalCode = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValidTimeDoctorId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointment_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ValidTimeDoctor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    ValidTimeId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppointmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValidTimeDoctor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ValidTimeDoctor_Appointment_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ValidTimeDoctor_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ValidTime",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    ValidTimeDoctorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValidTime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ValidTime_ValidTimeDoctor_ValidTimeDoctorId",
                        column: x => x.ValidTimeDoctorId,
                        principalTable: "ValidTimeDoctor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_PatientId",
                table: "Appointment",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_ValidTimeDoctorId",
                table: "Appointment",
                column: "ValidTimeDoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_NationalCode",
                table: "Patient",
                column: "NationalCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ValidTime_ValidTimeDoctorId",
                table: "ValidTime",
                column: "ValidTimeDoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_ValidTimeDoctor_AppointmentId",
                table: "ValidTimeDoctor",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ValidTimeDoctor_DoctorId",
                table: "ValidTimeDoctor",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_ValidTimeDoctor_ValidTimeDoctorId",
                table: "Appointment",
                column: "ValidTimeDoctorId",
                principalTable: "ValidTimeDoctor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Patient_PatientId",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_ValidTimeDoctor_ValidTimeDoctorId",
                table: "Appointment");

            migrationBuilder.DropTable(
                name: "ValidTime");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "ValidTimeDoctor");

            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "Doctor");
        }
    }
}
