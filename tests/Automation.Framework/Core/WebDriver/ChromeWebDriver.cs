using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Automation.Framework.Core.WebDriver;

public class ChromeWebDriver : ICustomWebDriver
{
    public IWebDriver Create(DriverOptions? options = null)
    {
        IWebDriver driver = new ChromeDriver();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        driver.Manage().Window.Maximize();
        return driver;
    }
}
