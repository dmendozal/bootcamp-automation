using Automation.Framework.Common.Factory;
using OpenQA.Selenium;

namespace Automation.Framework.Common.Session;

public class DriverSession
{
    /// <summary>
    /// Class instance
    /// </summary>
    private static DriverSession? _instance = null;
    private readonly IWebDriver _browser;

    /// <summary>
    /// Private constructor
    /// </summary>
    private DriverSession()
    {
        _browser = WebDriverFactory.MakeBrowser(Enums.BrowserType.Chrome).Create();
    }


    /// <summary>
    /// Static method to use in global way.
    /// </summary>
    /// <returns></returns>
    public static DriverSession Instance()
    {
        _instance ??= new DriverSession();

        return _instance;
    }

    public void CloseBrowser()
    {
        _instance = null;
        _browser.Quit();
    }


    public IWebDriver GetBrowser()
    {
        return _browser;
    }
}
