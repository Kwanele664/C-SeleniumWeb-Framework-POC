using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using ExtentReports = AventStack.ExtentReports.ExtentReports;

namespace Web.Tests.Poc.Reporting;

public static class ExtentService
{
    private static readonly Lazy<ExtentReports> Lazy =
        new Lazy<ExtentReports>(() => new ExtentReports());
    public static ExtentReports Instance => Lazy.Value;

    static ExtentService()
    {
        var reporter = new ExtentHtmlReporter("get current directory" + "/Reports/")
        {
            Config =
            {
                Theme = Theme.Standard
            }
        };
        Instance.AttachReporter(reporter);
    }
}