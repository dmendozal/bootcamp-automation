﻿using Automation.Framework.Base;
using Automation.Framework.Core;
using Automation.Framework.Enums;
using Automation.Test.Pages.Todoist;
using Automation.Test.Pages.YopMail;
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
        CustomUnityContainer.GetContainer().RegisterType<YopMailPage>(new ContainerControlledLifetimeManager());
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
