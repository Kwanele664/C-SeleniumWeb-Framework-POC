using Web.Tests.Poc.Utilities;

namespace Web.Tests.Poc.TestData;
public static class LoginData
{
    private const string WebsiteUrl = "https://www.saucedemo.com/";
    private static string StandardUsername = TestParameter.Username;
    private static string Password = TestParameter.Password;

    public static string IncorrectUsername => TestParameter.IncorrectUsername;
    public static string IncorrectPassword => TestParameter.IncorrectPassword;
    public static string? EmptyUsername => "";
    public static string? EmptyPassword => "";
    public static string LockedUsername = TestParameter.LockedUsername;
    
    public static string ProblemUsername = TestParameter.ProblemUsername;
    
    public static string PerformanceUsername = TestParameter.PerformanceUsername;
    

    public static string GetLaunchUrl()
    {
        return WebsiteUrl;
    }
    
    public static LoginModel GetCredentialsDetails()
    {
        return new LoginModel(StandardUsername, Password);;
    }
}