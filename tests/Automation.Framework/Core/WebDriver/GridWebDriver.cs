using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Automation.Framework.Core.WebDriver;

internal class GridWebDriver : ICustomWebDriver
{
    public IWebDriver Create(DriverOptions? options = null)
    {
        IWebDriver driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), options);
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        driver.Manage().Window.Maximize();
        return driver;
    }
}
