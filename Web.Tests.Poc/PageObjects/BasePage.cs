
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Web.Tests.Poc.PageObjects;
public class BasePage
{
    private readonly IWebDriver _driver;

    protected BasePage(IWebDriver driver)
    {
        _driver = driver;
    }
    
    private const int WaitInSeconds = 10;

    protected bool WaitForElementVisible(By by)
    {
        try
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(WaitInSeconds))
                .Until(ExpectedConditions.ElementIsVisible(by));
            return true;
        }
        catch (Exception)
        {
            throw new Exception($"The element was not found after waiting for {WaitInSeconds} seconds");
        }
    }

    private bool WaitForElementClickable(By by)
    {
        try
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(WaitInSeconds))
                .Until(ExpectedConditions.ElementToBeClickable(by));
            return true;
        }
        catch (Exception)
        {
            throw new Exception($"The element was not found after waiting for {WaitInSeconds} seconds");
        }
    }

    protected void ClickElement(By by) 
    {
        WaitForElementClickable(by);
        _driver.FindElement(by).Click();
    }

    protected void InputText(By by, string? inputTex) 
    {
        WaitForElementVisible(by);
        _driver.FindElement(by).Clear();
        _driver.FindElement(by).SendKeys(inputTex);
    }

    protected string  GetText(By by)
    {
        WaitForElementVisible(by);
        return _driver.FindElement(by).Text;
    }
}