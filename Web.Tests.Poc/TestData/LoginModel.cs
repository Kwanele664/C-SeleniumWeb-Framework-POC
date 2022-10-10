namespace Web.Tests.Poc.TestData;

public class LoginModel
{
    public readonly string? Username;
    public readonly string? Password;

    public LoginModel(string? username, string? password)
    {
        Username = username;
        Password = password;
    }  
}