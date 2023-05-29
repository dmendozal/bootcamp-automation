using Automation.Framework.Base;
using Automation.Framework.Core;
using Automation.Framework.Enums;
using Automation.Test.Pages;
using OpenQA.Selenium;
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
        CustomUnityContainer.GetContainer().RegisterType<YopMailPage>(new ContainerControlledLifetimeManager());
        CustomUnityContainer.GetContainer().RegisterType<TodolyPage>(new ContainerControlledLifetimeManager());
        CustomUnityContainer.GetContainer().RegisterInstance<IWebDriver>(Driver.Browser);
    }

    [TestInitialize]
    public void BeforeTest()
    {
    }

    [TestCleanup]
    public void AfterTest()
    {
    }

    [AssemblyCleanup]
    public static void AfterTestRun()
    {
        Driver.StopBrowser();
    }
}
