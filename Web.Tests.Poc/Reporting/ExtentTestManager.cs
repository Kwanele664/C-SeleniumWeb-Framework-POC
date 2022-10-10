using AventStack.ExtentReports;
using System.Threading;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using OpenQA.Selenium;

namespace Web.Tests.Poc.Reporting;


public static class ExtentTestManager
{
    private static readonly ThreadLocal<ExtentTest> ParentTest = new ThreadLocal<ExtentTest>();

    private static readonly object Synclock = new object();

    // creates a parent test
    public static ExtentTest CreateTest(string testName, string? description = null)
    {
        lock (Synclock)
        {
            ParentTest.Value = ExtentService.Instance.CreateTest(testName, description);
            return ParentTest.Value;
        }
    }
    
    public static void PassTest()
    {
        lock (Synclock)
        {
            ParentTest.Value?.Pass("All assertions passed");
        }
    }
    
    public static void FailTest(string exceptionMessage)
    {
        lock (Synclock)
        {
            ParentTest.Value?.Fail($"Test failed: {exceptionMessage}");
        }
    }

    public static void AttachScreenShort(string base64Screenshot)
    {
        lock (Synclock)
        {
            ParentTest.Value.Log(Status.Info,
                MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64Screenshot).Build());
        }
    }
    
    
}