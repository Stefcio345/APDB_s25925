using Microsoft.EntityFrameworkCore;
using Zadanie_5.Context;
using Zadanie_6.Models;
using Zadanie_6.Services;

namespace Zadanie_6_Tests;

public class ServicesTests
{
    string connectionstring = "Data Source=db-mssql;Initial Catalog=2019SBD;Integrated Security=True;TrustServerCertificate=True";
    DbContextOptionsBuilder<S25925Context> optionsBuilder = new ();
    private readonly IMedicamentService medicamentService = new MedicamentService(new S25925Context());
    private readonly IPatientService patientService = new PatientService(new S25925Context());
    private readonly IPrescriptionService prescription = new PrescriptionService();
    private S25925Context _dbContext;
    
    public ServicesTests()
    {
        var dbContextOptionsBuilder = optionsBuilder.UseSqlServer(connectionstring);
        _dbContext = new S25925Context(optionsBuilder.Options);
    }

    [Fact]
    public void MedicamentService_Exists_Should_Return_False_When_Medicament_Does_Not_Exist()
    {
        var medicament = new Medicament()
        {
            IdMedicament = -30,
            Name = "XXXXXXXXXXXXXXXX",
            Description = "XXXXXXXXXXXXXX",
            Type = "XXXXXXXXXXX"
        };
        
        var service = new MedicamentService(_dbContext);

        var result = service.MedicamentExist(medicament.IdMedicament);
        
        Assert.False(result);
    }
    
    [Fact]
    public void MedicamentService_Exists_Should_Return_True_When_Medicament_Does_Exist()
    {
        var medicament = new Medicament()
        {
            IdMedicament = 1,
            Name = "XXXXXXXXXXXXXXXX",
            Description = "XXXXXXXXXXXXXX",
            Type = "XXXXXXXXXXX"
        };
        
        var service = new MedicamentService(_dbContext);

        var result = service.MedicamentExist(medicament.IdMedicament);
        
        Assert.True(result);
    }
    
    [Fact]
    public void PatientService_Exists_Should_Return_True_When_Patient_Does_Exist()
    {
        var patient = new Patient()
        {
            IdPatient = 1,
            FirstName = "Test",
            LastName = "Test",
            BirthDate = DateTime.Parse("01-12-2023")
        };
        
        var service = new PatientService(_dbContext);

        var result = service.PatientExists(patient.IdPatient);
        
        Assert.True(result);
    }
    
    [Fact]
    public void PatientService_Exists_Should_Return_False_When_Patient_Does_Not_Exist()
    {
        var patient = new Patient()
        {
            IdPatient = -3,
            FirstName = "Test",
            LastName = "Test",
            BirthDate = DateTime.Parse("01-12-2023")
        };
        
        var service = new PatientService(_dbContext);

        var result = service.PatientExists(patient.IdPatient);
        
        Assert.False(result);
    }
    
    [Fact]
    public void PrescriptionService_Should_Return_False_When_Prescription_Date_Bigger_Than_DueDate()
    {
        var prescription = new Prescription()
        {
            IdPatient = 1,
            Date = DateTime.Parse("01-12-2024"),
            DueDate = DateTime.Parse("01-12-2023"),
            Patient = null,
            Doctor = null
        };
        
        var service = new PrescriptionService();

        var result = service.PrescriptionIsValid(prescription);
        
        Assert.False(result);
    }
    
    [Fact]
    public void PrescriptionService_Should_Return_True_When_Prescription_Date_smaller_Than_DueDate()
    {
        var prescription = new Prescription()
        {
            Date = DateTime.Parse("01-12-2022"),
            DueDate = DateTime.Parse("01-12-2023"),
            Patient = null,
            Doctor = null
        };
        
        var service = new PrescriptionService();

        var result = service.PrescriptionIsValid(prescription);
        
        Assert.True(result);
    }
    
    [Fact]
    public void PrescriptionService_Should_Return_False_When_Prescription_Has_More_Than_10_Medicaments()
    {
        var prescription = new List<IMedicamentPrescritpion>()
        {
            null, null, null, null, null, null, null, null, null, null, null, null
        };
        
        var service = new PrescriptionService();

        var result = service.CorrectNumberOfMedicaments(prescription);
        
        Assert.False(result);
    }
    
    [Fact]
    public void PrescriptionService_Should_Return_True_When_Prescription_Has_Less_Than_10_Medicaments()
    {
        var prescription = new List<IMedicamentPrescritpion>()
        {
            null, null, null
        };
        
        var service = new PrescriptionService();

        var result = service.CorrectNumberOfMedicaments(prescription);
        
        Assert.True(result);
    }
}