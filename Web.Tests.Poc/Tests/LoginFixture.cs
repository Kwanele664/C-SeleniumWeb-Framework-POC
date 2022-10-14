using AventStack.ExtentReports;
using FluentAssertions;
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
        _test = ExtentTestManager.CreateTest("LoginWithCorrectCredentials", "This user should be logged in to our system");

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
        _test = ExtentTestManager.CreateTest("LoginWithoutCredentials", "This user has not provided credentials shouldn't be logged in to the system");

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
        _test = ExtentTestManager.CreateTest("LoginWithIncorrectUsername", "This User has supplied incorrect username to log into the system");
        
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
        _test = ExtentTestManager.CreateTest("LoginWithIncorrectPassword", "This User has supplied incorrect password to log into the system");
        
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
    
    [Fact]
    public void LoginWithLockedUsername()
    {
        _test = ExtentTestManager.CreateTest("LoginWithLockedUsername", "This user has been locked out to our system");
        
        try
        {
            _fixture.BrowserHelpers.LaunchBrowser(TestData.LoginData.GetLaunchUrl());
        
            _fixture.PageLoader.LoginPage.LogIn(TestData.LoginData.LockedUsername,TestData.LoginData.GetCredentialsDetails().Password);

            var errorMessage = _fixture.PageLoader.LoginPage.GetLoginErrorMessage();
            errorMessage.Should().Be("Epic sadface: Sorry, this user has been locked out.");
            
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
    public void LoginWithProblemUsername()
    {
        _test = ExtentTestManager.CreateTest("LoginWithProblemUsername", "This user has problem in getting into our system");
        
        try
        {
            _fixture.BrowserHelpers.LaunchBrowser(TestData.LoginData.GetLaunchUrl());
        
            _fixture.PageLoader.LoginPage.LogIn(TestData.LoginData.ProblemUsername,TestData.LoginData.GetCredentialsDetails().Password);

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
    public void LoginWithPerformanceUsername()
    {
        _test = ExtentTestManager.CreateTest("LoginWithPerformanceUsername", "This user has Performance issues it takes time to get into our system");
        
        try
        {
            _fixture.BrowserHelpers.LaunchBrowser(TestData.LoginData.GetLaunchUrl());
        
            _fixture.PageLoader.LoginPage.LogIn(TestData.LoginData.PerformanceUsername,TestData.LoginData.GetCredentialsDetails().Password);

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
}