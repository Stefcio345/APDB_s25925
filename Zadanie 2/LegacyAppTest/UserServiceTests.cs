using LegacyApp;

namespace LegacyAppTest;

public class UserServiceTests
{
    [Fact]
    public void AddUser_Should_Return_False_When_Email_Without_At_And_Dot()
    {
        //Arrange
        string firstName = "John";
        string lastName = "Doe";
        string email = "doe";
        DateTime birthDate = new DateTime(1980, 1, 1);
        int clientId = 1;
        var service = new UserService();
        
        //Act
        bool result = service.AddUser(firstName, lastName, email, birthDate, clientId);
        
        //Assert
        Assert.False(result);
        
    }
    
    [Fact]
    public void AddUser_Should_Return_False_When_First_Name_Empty()
    {
        //Arrange
        string firstName = "";
        string lastName = "Doe";
        string email = "johndoe@gmail.com";
        DateTime birthDate = new DateTime(1980, 1, 1);
        int clientId = 1;
        var service = new UserService();
        
        //Act
        bool result = service.AddUser(firstName, lastName, email, birthDate, clientId);
        
        //Assert
        Assert.False(result);
        
    }
    
    [Fact]
    public void AddUser_Should_Return_False_When_Last_Name_Empty()
    {
        //Arrange
        string firstName = "John";
        string lastName = "";
        string email = "johndoe@gmail.com";
        DateTime birthDate = new DateTime(1980, 1, 1);
        int clientId = 1;
        var service = new UserService();
        
        //Act
        bool result = service.AddUser(firstName, lastName, email, birthDate, clientId);
        
        //Assert
        Assert.False(result);
        
    }
    
    [Fact]
    public void AddUser_Should_Return_False_When_Age_Too_Low()
    {
        //Arrange
        string firstName = "John";
        string lastName = "Doe";
        string email = "johndoe@gmail.com";
        DateTime birthDate = new DateTime(2010, 1, 1);
        int clientId = 1;
        var service = new UserService();
        
        //Act
        bool result = service.AddUser(firstName, lastName, email, birthDate, clientId);
        
        //Assert
        Assert.False(result);
        
    }
    
    
    [Fact]
    public void AddUser_Should_Return_False_When_UserCreditLimit_Too_Low()
    {
        //Arrange
        string firstName = "John";
        string lastName = "Kowalski";
        string email = "johndoe@gmail.com";
        DateTime birthDate = new DateTime(1980, 1, 1);
        int clientId = 1;
        var service = new UserService();
        
        //Act
        bool result = service.AddUser(firstName, lastName, email, birthDate, clientId);
        
        //Assert
        Assert.False(result);
    }
    
}