using AventStack.ExtentReports;
using FluentAssertions;
using Web.Tests.Poc.Browsers;
using Web.Tests.Poc.Reporting;

namespace Web.Tests.Poc.Tests;

public class LoginFixture : IClassFixture<BaseFixture>
{
    private readonly BaseFixture _fixture;

    private ExtentTest _test;
 

    public LoginFixture(BaseFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void LoginWithCorrectCredentials()
    {
        _test = ExtentTestManager.CreateTest("LoginWithCorrectCredentials", "");

        try
        {
            _fixture.BrowserHelpers.LaunchBrowser(TestData.LoginData.GetLaunchUrl());

            _fixture.PageLoader.LoginPage.LogIn(
                TestData.LoginData.GetCredentialsDetails().Username,
                TestData.LoginData.GetCredentialsDetails().Password);

            var product = _fixture.PageLoader.LandingPage.GetProductText();
        
            product.Should().Be("PRODUCTS");
            
            ExtentTestManager.PassTest();
            
        }
        catch (Exception exception)
        {
            
            ExtentTestManager.FailTest(exception.Message);
            ExtentTestManager.AttachScreenShort(_fixture.BrowserHelpers.TakeScreenshotAsBase64());
            throw;
            
        }
    }

    
    [Fact]
    public void LoginWithoutCredentials()
    {
        _test = ExtentTestManager.CreateTest("LoginWithoutCredentials", "");

        try
        {
            _fixture.BrowserHelpers.LaunchBrowser(TestData.LoginData.GetLaunchUrl());

            _fixture.PageLoader.LoginPage.LogIn(TestData.LoginData.EmptyUsername,TestData.LoginData.EmptyPassword);

            var isVisible = _fixture.PageLoader.LoginPage.IsErrorMessageVisible();
            var errorMessage = _fixture.PageLoader.LoginPage.GetLoginErrorMessage();

            isVisible.Should().BeTrue();
            errorMessage.Should().Be("Epic sadface: Username is required");
            
            ExtentTestManager.PassTest();
        }
        catch (Exception exception)
        {
            ExtentTestManager.FailTest(exception.Message);
            ExtentTestManager.AttachScreenShort(_fixture.BrowserHelpers.TakeScreenshotAsBase64());
            throw;
        }
        
    }

    [Fact]
    public void LoginWithIncorrectUsername()
    {
        _test = ExtentTestManager.CreateTest("LoginWithIncorrectUsername", "");
        
        try
        {
            _fixture.BrowserHelpers.LaunchBrowser(TestData.LoginData.GetLaunchUrl());
        
            _fixture.PageLoader.LoginPage.LogIn(TestData.LoginData.IncorrectUsername,TestData.LoginData.GetCredentialsDetails().Password);

            var errorMessage = _fixture.PageLoader.LoginPage.GetLoginErrorMessage();
            errorMessage.Should().Be("Epic sadface: Username and password do not match any user in this service");
            
            ExtentTestManager.PassTest();
        }
        catch (Exception exception)
        {
            ExtentTestManager.FailTest(exception.Message);
            ExtentTestManager.AttachScreenShort(_fixture.BrowserHelpers.TakeScreenshotAsBase64());
            throw;
        }
        
    }

    [Fact]
    public void LoginWithIncorrectPassword()
    {
        _test = ExtentTestManager.CreateTest("LoginWithIncorrectPassword", "");
        
        try
        {
            _fixture.BrowserHelpers.LaunchBrowser(TestData.LoginData.GetLaunchUrl());
        
            _fixture.PageLoader.LoginPage.LogIn(TestData.LoginData.GetCredentialsDetails().Username,TestData.LoginData.IncorrectPassword);

            var errorMessage = _fixture.PageLoader.LoginPage.GetLoginErrorMessage();
            errorMessage.Should().Be("Epic sadface: Username and password do not match any user in this service");
            
            ExtentTestManager.PassTest();
        }
        catch (Exception exception)
        {
            ExtentTestManager.FailTest(exception.Message);
            ExtentTestManager.AttachScreenShort(_fixture.BrowserHelpers.TakeScreenshotAsBase64());
            throw;
        }
        
    }
}