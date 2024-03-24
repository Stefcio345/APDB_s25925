using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace LegacyAppTests;

public class UnitTest1
{
    private readonly UserService target = new UserService();
        
    [Fact]
    public void AddUser_Should_Return_False_When_Email_Without_At_And_Dot()
    {
        private String firstName = "John";
        private String lastName = "Doe";
        private string email = "doe";
        private DateTime birthdate = DateTime.Parse("1982-03-21");
        private int clientId = 1;    

        private var result = target.AddUser(firstName, lastName, EmailAddressAttribute, birthdate, clientId);
            
        Assert.Equal(false, result);
    }

}