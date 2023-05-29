using Automation.Framework.Base;
using Automation.Test.Pages;
using Unity;

namespace Automation.Test.Tests.Todoly;

[TestClass]
public class ProjectManagementTests : BaseTest
{
    private readonly TodolyPage _todolyPage = CustomUnityContainer.GetContainer().Resolve<TodolyPage>();

    [TestMethod]
    public void CreateNewProject()
    {
        string projectName = "Mojix Project Test";

        _todolyPage.Helpers.BrowserComponent.Navigate(_todolyPage.BaseUrl);
        _todolyPage.Login(Constants.PersonalEmail, Constants.PersonalPassword);
        _todolyPage.ButtonAddNewProjectWebElement.Click();
        _todolyPage.InputProjectNameWebElement.SendKeys(projectName);
        _todolyPage.ButtonSaveNewProjectWebElement.Click();

        Assert.IsTrue(_todolyPage.IsVisibleProjectNameCreated(projectName),
                      "¡ERROR! The project was not created");
    }

    [TestMethod]
    public void CreateTaskInProject()
    {
        string projectSelected = "Mojix Project Test";
        string taskName = "Mojix Task Test";
        _todolyPage.Helpers.BrowserComponent.Navigate(_todolyPage.BaseUrl);
        _todolyPage.Login(Constants.PersonalEmail, Constants.PersonalPassword);

        Assert.IsTrue(_todolyPage.IsVisibleProjectNameCreated(projectSelected),
                      "¡ERROR! The project does not exist");

        _todolyPage.ItemProjectNameWebElement(projectSelected).Click();
        _todolyPage.InputTaskNameWebElement.SendKeys(taskName);
        _todolyPage.ButtonAddNewTaskWebElement.Click();

        Assert.IsTrue(_todolyPage.IsVisibleTaskNameCreated(taskName),
                      "¡ERROR! The task was not created");
    }

    [TestMethod]
    public void ChangeProjectName()
    {
        string projectSelected = "Mojix Project Test";
        string newProjectName = "Mojix Edit";

        _todolyPage.Helpers.BrowserComponent.Navigate(_todolyPage.BaseUrl);
        _todolyPage.Login(Constants.PersonalEmail, Constants.PersonalPassword);

        Assert.IsTrue(_todolyPage.IsVisibleProjectNameCreated(projectSelected),
                      "¡ERROR! The project does not exist");

        _todolyPage.ItemProjectNameWebElement(projectSelected).Click();
        _todolyPage.ButtonSubMenuActionableWebElement.Click();
        _todolyPage.ButtonEditProjectWebElement.Click();
        _todolyPage.InputEditProjectWebElement.Clear();
        _todolyPage.InputEditProjectWebElement.SendKeys(newProjectName);
        _todolyPage.ButtonSubmitEditProjectWebElement.Click();

        Assert.IsTrue(_todolyPage.IsVisibleProjectNameCreated(newProjectName),
                      "¡ERROR! The project does not exist");
    }

    [TestMethod]
    public void ChooseDueDateToCompleteTask()
    {
        string projectSelected = "Mojix Project Test";
        string taskName = "Mojix Task Test";
        DateTime date = DateTime.Now.Date.AddDays(6);

        _todolyPage.Helpers.BrowserComponent.Navigate(_todolyPage.BaseUrl);
        _todolyPage.Login(Constants.PersonalEmail, Constants.PersonalPassword);

        Assert.IsTrue(_todolyPage.IsVisibleProjectNameCreated(projectSelected),
                      "¡ERROR! The project does not exist");

        _todolyPage.ItemProjectNameWebElement(projectSelected).Click();

        Assert.IsTrue(_todolyPage.IsVisibleTaskNameCreated(taskName),
                     "¡ERROR! The task does not exist");

        _todolyPage.Helpers.MouseActionComponent.MoveToElement(_todolyPage.ItemTaskNameWebElement(taskName));
        _todolyPage.ButtonSetDueDateWebElement.Click();
        _todolyPage.InputSetDueDateWebElement.SendKeys(date.ToShortDateString());
        _todolyPage.ButtonSaveDueDateWebElement.Click();

        Assert.IsTrue(_todolyPage.IsVisibleSetDueDateApplied(date.ToString("d MMM hh:ss tt")),
                      "¡ERROR! The due date was not applied successfully");
    }
}
