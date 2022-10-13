using AventStack.ExtentReports;

namespace Web.Tests.Poc.Reporting;
public static class ExtentTestManager
{
    private static readonly ThreadLocal<ExtentTest> ParentTest = new ThreadLocal<ExtentTest>();

    private static readonly object Synclock = new object();
    
    public static ExtentTest CreateTest(string testName, string? description = null)
    {
        lock (Synclock) // with synclock we prevent the thread to enter the block until no other thread is executing
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