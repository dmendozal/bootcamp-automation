using Automation.Framework.Common.Factory;
using Automation.Framework.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Automation.Framework.Core;

public static class Driver
{
    private static WebDriverWait? _browserWait;
    private static IWebDriver? _browser;

    public static IWebDriver Browser
    {
        get
        {
            if (_browser == null)
                throw new NullReferenceException("WebDriver Browser is not initialized.");

            return _browser;
        }
        set
        {
            _browser = value;
        }
    }

    public static WebDriverWait BrowserWait
    {
        get
        {
            if (_browserWait == null || _browser == null)
                throw new NullReferenceException("WebDriverWait Browser is not initialized");

            return _browserWait;
        }
        private set
        {
            _browserWait = value;
        }
    }

    public static void StartBrowser(BrowserType browserType, int defaultTimeOut = 30, DriverOptions driverOptions = null)
    {
        Browser = WebDriverFactory.MakeBrowser(browserType).Create(driverOptions);
        BrowserWait = new WebDriverWait(Browser, TimeSpan.FromSeconds(defaultTimeOut)); 
    }

    public static void StopBrowser()
    {
        Browser.Quit();
        _browser = null;
        _browserWait = null;
    }
}
