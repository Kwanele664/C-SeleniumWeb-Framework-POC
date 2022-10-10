using FluentAssertions;

namespace Web.Tests.Poc.Tests;

public class LoginFixture : IClassFixture<BaseFixture>
{
    private readonly BaseFixture _fixture;

    public LoginFixture(BaseFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    //TODO Implement Await method
    public void LoginWithCorrectCredentials()
    {
        _fixture.BrowserHelpers.LaunchBrowser(TestData.LoginData.GetLaunchUrl());

        _fixture.PageLoader.LoginPage.LogIn(
            TestData.LoginData.GetCredentialsDetails().Username,
            TestData.LoginData.GetCredentialsDetails().Password);

        var product = _fixture.PageLoader.LandingPage.GetProductText();
        
        product.Should().Be("PRODUCTS");
    }

    
    [Fact]
    public void LoginWithoutCredentials()
    {
        _fixture.BrowserHelpers.LaunchBrowser(TestData.LoginData.GetLaunchUrl());

        _fixture.PageLoader.LoginPage.LogIn(TestData.LoginData.EmptyUsername,TestData.LoginData.EmptyPassword);

        var isVisible = _fixture.PageLoader.LoginPage.IsErrorMessageVisible();
        var errorMessage = _fixture.PageLoader.LoginPage.GetLoginErrorMessage();

        isVisible.Should().BeTrue();
        errorMessage.Should().Be("Epic sadface: Username is required");
    }

    [Fact]
    public void LoginWithIncorrectUsername()
    {
        _fixture.BrowserHelpers.LaunchBrowser(TestData.LoginData.GetLaunchUrl());
        
        _fixture.PageLoader.LoginPage.LogIn(TestData.LoginData.IncorrectUsername,TestData.LoginData.GetCredentialsDetails().Password);

        var errorMessage = _fixture.PageLoader.LoginPage.GetLoginErrorMessage();
        errorMessage.Should().Be("Epic sadface: Username and password do not match any user in this service");
    }

    [Fact]
    public void LoginWithIncorrectPassword()
    {
        _fixture.BrowserHelpers.LaunchBrowser(TestData.LoginData.GetLaunchUrl());
        
        _fixture.PageLoader.LoginPage.LogIn(TestData.LoginData.GetCredentialsDetails().Username,TestData.LoginData.IncorrectPassword);

        var errorMessage = _fixture.PageLoader.LoginPage.GetLoginErrorMessage();
        errorMessage.Should().Be("Epic sadface: Username and password do not match any user in this service");
    }
    
    
}