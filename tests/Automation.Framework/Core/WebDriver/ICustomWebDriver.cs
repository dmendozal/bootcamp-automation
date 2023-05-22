using OpenQA.Selenium;

namespace Automation.Framework.Core.WebDriver;

public interface ICustomWebDriver
{
    IWebDriver Create(DriverOptions? options = null);
}
