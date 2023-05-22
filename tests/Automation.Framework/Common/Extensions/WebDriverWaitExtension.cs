using Automation.Framework.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Automation.Framework.Common.Extensions;

public static class WebDriverWaitExtension
{
    public static IWebElement GetWebElement(this WebDriverWait webDriverWait,
                                                     string locator,
                                                     LocatorElement locatorElement)
    {
        return locatorElement switch
        {
            LocatorElement.Xpath => webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locator))),
            LocatorElement.ID => webDriverWait.Until(ExpectedConditions.ElementExists(By.Id(locator))),
            LocatorElement.Name => webDriverWait.Until(ExpectedConditions.ElementExists(By.Name(locator))),
            LocatorElement.CssSelector => webDriverWait.Until(ExpectedConditions.ElementExists(By.CssSelector(locator))),
            LocatorElement.ClassName => webDriverWait.Until(ExpectedConditions.ElementExists(By.ClassName(locator))),
            LocatorElement.TagName => webDriverWait.Until(ExpectedConditions.ElementExists(By.TagName(locator))),
            _ => throw new NotImplementedException()
        };
    }
}
