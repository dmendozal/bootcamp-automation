using Automation.Framework.Common.Extensions;
using Automation.Framework.Controls;
using Automation.Framework.Core;
using Automation.Framework.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Automation.Framework.Base;

public class BasePage
{
    public readonly Helpers Helpers = new();

    protected BasePage(IWebDriver driver)
    {
        Driver.Browser = driver;
    }

    protected static IWebElement WaitTillElementDisplayed(string locator,
                                                       LocatorElement locatorElement,
                                                       int timeOutForFindingElement = 10,
                                                       bool isWaitWebDriver = true)
    {
        var wait = new WebDriverWait(Driver.Browser, TimeSpan.FromSeconds(timeOutForFindingElement));

        return isWaitWebDriver ? wait.GetWaitWebElement(locator, locatorElement) : Driver.Browser.GetWebElement(locator, locatorElement);
    }

    protected static bool WaitIfElementDisplayed(string locator, LocatorElement locatorElement)
    {
        try
        {
            WaitTillElementDisplayed(locator, locatorElement, 1);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
