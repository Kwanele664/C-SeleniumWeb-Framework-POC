namespace Web.Tests.Poc.Browsers;
public class BrowserHelpers
{
    private readonly IWebDriver _driver;

    public BrowserHelpers(IWebDriver driver)
    {
        _driver = driver;
    }

    public void LaunchBrowser(string url)
    {
        _driver.Navigate().GoToUrl(url);
    }
    
    public string TakeScreenshotAsBase64()
    {
        var screenShot = ((ITakesScreenshot)_driver).GetScreenshot();

        return screenShot.AsBase64EncodedString;
    }

   

    public void QuitBrowser()
    {
        _driver.Quit();
    }
}

