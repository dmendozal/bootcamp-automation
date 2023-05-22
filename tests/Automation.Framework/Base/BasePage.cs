using Automation.Framework.Common.Extensions;
using Automation.Framework.Controls;
using Automation.Framework.Core;
using Automation.Framework.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Automation.Framework.Base;

public class BasePage
{
    public Helpers Helpers = new();

    public BasePage(IWebDriver driver)
    {
        Driver.Browser = driver;
    }

    public static IWebElement WaitTillElementDisplayed(string locator,
                                                       LocatorElement locatorElement,
                                                       int TimeOutForFindingElement = 10,
                                                       bool isWaitWebDriver = true)
    {
        var wait = new WebDriverWait(Driver.Browser, TimeSpan.FromSeconds(TimeOutForFindingElement));

        return isWaitWebDriver ? wait.GetWaitWebElement(locator, locatorElement) : Driver.Browser.GetWebElement(locator, locatorElement);
    }

    public static bool WaitIfElementDisplayed(string locator, LocatorElement locatorElement)
    {
        try
        {
            var webElement = WaitTillElementDisplayed(locator, locatorElement, 1);

            return webElement != null;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
