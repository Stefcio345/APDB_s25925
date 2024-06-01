using Zadanie_5.Context;

namespace Zadanie_6.Services;

public class MedicamentService: IMedicamentService
{
    private readonly S25925Context _dbContext;
    
    public MedicamentService(S25925Context dbContext)
    {
        _dbContext = dbContext;
    }
    public bool MedicamentExist(int medicamentId)
    {
        return _dbContext.Medicaments.Any(m => m.IdMedicament == medicamentId);
    }
}