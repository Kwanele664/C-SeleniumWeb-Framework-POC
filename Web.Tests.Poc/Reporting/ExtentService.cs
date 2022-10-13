using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using Web.Tests.Poc.Utilities;

namespace Web.Tests.Poc.Reporting;
public static class ExtentService
{
    private static readonly Lazy<AventStack.ExtentReports.ExtentReports> Lazy = new(() => new AventStack.ExtentReports.ExtentReports());
    public static AventStack.ExtentReports.ExtentReports Instance => Lazy.Value;

    static ExtentService()
    {
        var reporter = new ExtentHtmlReporter(ReportPath.GetReportFilePath())
        {
            Config =
            {
                Theme = Theme.Standard
            }
        };
        Instance.AttachReporter(reporter);
    }
}