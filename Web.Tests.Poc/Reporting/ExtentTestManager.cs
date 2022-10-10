using AventStack.ExtentReports;
using System.Threading;

namespace Web.Tests.Poc.Reporting;


public class ExtentTestManager
{
    private static readonly ThreadLocal<ExtentTest> ParentTest = new ThreadLocal<ExtentTest>();

    private static readonly object Synclock = new object();

    // creates a parent test
    public static ExtentTest CreateTest(string testName, string description = null)
    {
        lock (Synclock)
        {
            ParentTest.Value = ExtentService.Instance.CreateTest(testName, description);
            return ParentTest.Value;
        }
    }
}