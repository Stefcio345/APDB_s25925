using Microsoft.EntityFrameworkCore;
using Zadanie_6.Models;

namespace Zadanie_5.Context;

public partial class S25925Context : DbContext
{
    public S25925Context()
    {
    }

    public S25925Context(DbContextOptions<S25925Context> options)
        : base(options)
    {
    }

    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<Prescription_Medicament> PrescriptionMedicaments { get; set; }
}