using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using WebDriverManager.DriverConfigs.Impl;

namespace Web.Tests.Poc.Browsers;
public class BrowserFactory
{
    private readonly string _remoteUrl;
    
    public BrowserFactory(string remoteUrl)
    {
        _remoteUrl = remoteUrl;
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
            Browser.FireFox => GetFireFox(),
            _ => throw new ArgumentOutOfRangeException(nameof(browserName), browserName, "Invalid browser passed")
        };
    }
    
    private IWebDriver GetChrome()
    {
        var chromeOptions = new ChromeOptions();
        chromeOptions.AddArguments("--no-sandbox", "--disable-popup-blocking","--headless","--disable-dev-shm-usage");

        var driver = new RemoteWebDriver(new Uri(_remoteUrl), chromeOptions);
        
        return driver;
    }
    
    private IWebDriver GetEdge()
    {
        new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
        
        return new EdgeDriver();
    }
    
    private IWebDriver GetFireFox()
    {
        var fireFoxOptions = new FirefoxOptions();

        var driver = new RemoteWebDriver(new Uri(_remoteUrl), fireFoxOptions);

        return driver;
    }
}