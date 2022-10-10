using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using ExtentReports = AventStack.ExtentReports.ExtentReports;

namespace Web.Tests.Poc.TestData;

public class ReportPath
{
    public static string  GetReportFilePath()
    {
        var path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
        var actualPath = path?[..path.LastIndexOf("bin")];
        var projectPath = new Uri(actualPath).LocalPath;
        var reportPath = projectPath + "\\Test_Execution_Reports" + "\\Automation_Report_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");

        return reportPath;
    }
    
}