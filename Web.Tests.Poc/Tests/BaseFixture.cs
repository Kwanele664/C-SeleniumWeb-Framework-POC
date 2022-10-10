using Web.Tests.Poc.Assembly;
using Web.Tests.Poc.Browsers;

namespace Web.Tests.Poc.Tests;

public class BaseFixture : IDisposable
{
    public readonly BrowserHelpers BrowserHelpers;
    public readonly PageLoader PageLoader;

    public BaseFixture()
    {
        var factory = new BrowserFactory();
        var driver = factory.GetDriver(Browser.Edge);
        
        BrowserHelpers = new BrowserHelpers(driver);
        PageLoader = new PageLoader(driver);
    }

    public void Dispose()
    {
        BrowserHelpers.QuitBrowser();
    }
}