namespace Web.Tests.Poc.PageObjects;
public class LoginPage : BasePage
{
    private readonly IWebDriver _driver;
    public LoginPage(IWebDriver driver) : base(driver)
    {
        _driver = driver;
    }
    private static By UsernameInput => By.Id("user-name");
    private static By PasswordInput => By.Id("password");
    private static By LoginButton => By.Id("login-button");
    private static By ErrorMessage => By.XPath("//div[contains(@class, 'error-message-container')]");
    
    public void LogIn(string? usernameText, string? passwordText)
    {
        InputText(UsernameInput,usernameText);
        InputText(PasswordInput,passwordText);
        ClickElement(LoginButton);
    }

    public bool IsErrorMessageVisible()
    {
        return WaitForElementVisible(ErrorMessage);
    }

    public string GetLoginErrorMessage()
    {
        return GetText(ErrorMessage);
    }

}