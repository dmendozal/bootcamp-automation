using Automation.Framework.Base;
using Automation.Framework.Core;
using Automation.Framework.Enums;
using Automation.Test.Pages.Todoist;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Unity;
using Unity.Lifetime;

namespace Automation.Test;

[TestClass]
public class BaseTest
{
    [AssemblyInitialize]
    public static void InitializeAssembly(TestContext context)
    {
        Driver.StartBrowser(BrowserType.Chrome, 30);
        CustomUnityContainer.GetContainer().RegisterType<TodoistPage>(new ContainerControlledLifetimeManager());
        CustomUnityContainer.GetContainer().RegisterInstance<IWebDriver>(Driver.Browser);
    }

    private static ChromeOptions GetChromeOptions()
    {
        ChromeOptions chromeOptions = new();
        chromeOptions.AddArgument("window-size=1920,1080");
        return chromeOptions;
    }

    [TestInitialize]
    public void BeforeTest()
    {
    }

    [TestCleanup]
    public void AfetrTest()
    {
    }

    [AssemblyCleanup]
    public static void AfterTestRun()
    {
        Driver.StopBrowser();
    }
}
