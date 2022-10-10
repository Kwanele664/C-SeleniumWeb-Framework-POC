using OpenQA.Selenium;

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

    public void QuitBrowser()
    {
        _driver.Quit();
    }
}