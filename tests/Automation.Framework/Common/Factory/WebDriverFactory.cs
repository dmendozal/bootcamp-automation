using Automation.Framework.Core.WebDriver;
using Automation.Framework.Enums;

namespace Automation.Framework.Common.Factory;

public static class WebDriverFactory
{
    public static ICustomWebDriver MakeBrowser(BrowserType browserType)
    {
        return browserType switch
        {
            BrowserType.Chrome => new ChromeWebDriver(),
            _ => throw new NotImplementedException()
        };
    }
}
