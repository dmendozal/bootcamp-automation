using Automation.Framework.Controls.Interfaces;
using Automation.Framework.Core;
using OpenQA.Selenium;

namespace Automation.Framework.Controls;

public class BrowserComponent : IBrowserComponent
{
    /// <summary>
    /// Navigate to specified URL
    /// </summary>
    /// <param name="url">Web URL</param>
    public void Navigate(string url)
    {
        Driver.Browser.Navigate().GoToUrl(url);
    }

    /// <summary>
    /// Switches webdriver to specified iframe component
    /// </summary>
    /// <param name="frameElement">IFrame WebElement</param>
    public static void SwitchToFrame(IWebElement frameElement)
    {
        Driver.Browser.SwitchTo().Frame(frameElement);
    }

    /// <summary>
    /// Switches webdriver to default content
    /// </summary>
    public static void SwitchToDefaultContent()
    {
        Driver.Browser.SwitchTo().DefaultContent();
    }
}
