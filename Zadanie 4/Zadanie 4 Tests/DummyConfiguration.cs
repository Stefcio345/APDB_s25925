using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace Zadanie_4_Tests;

public class DummyConfiguration: IConfiguration
{
    public IEnumerable<IConfigurationSection> GetChildren()
    {
        return null;
    }

    public IChangeToken GetReloadToken()
    {
        return null;
    }

    public IConfigurationSection GetSection(string key)
    {
        return null;
    }

    public string? this[string key]
    {
        get => "Data Source=db-mssql;Initial Catalog=2019SBD;Integrated Security=True";
        set => throw new NotImplementedException();
    }
}