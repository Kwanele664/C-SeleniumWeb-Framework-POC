using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using WebDriverManager.DriverConfigs.Impl;

namespace Web.Tests.Poc.Browsers;

public class BrowserFactory
{
    //TODO Implement the constructor
    public BrowserFactory()
    {
    }

    public IWebDriver GetDriver()
    {
        return GetChrome();
    }

    public IWebDriver GetDriver(Browser browserName)
    {
        return browserName switch
        {
            Browser.Chrome => GetChrome(),
            Browser.Edge => GetEdge(),
            _ => throw new ArgumentOutOfRangeException(nameof(browserName), browserName, "Invalid browser passed")
        };
    }
    
    private static IWebDriver GetChrome()
    {
        new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
        
        return new ChromeDriver();
    }
    
    private static IWebDriver GetEdge()
    {
        new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
        
        return new EdgeDriver();
    }

}