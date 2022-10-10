using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using ExtentReports = AventStack.ExtentReports.ExtentReports;

namespace Web.Tests.Poc.Reporting;

public static class ExtentService
{
    private static readonly Lazy<AventStack.ExtentReports.ExtentReports> Lazy =
        new Lazy<AventStack.ExtentReports.ExtentReports>(() => new AventStack.ExtentReports.ExtentReports());
    public static AventStack.ExtentReports.ExtentReports Instance => Lazy.Value;

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