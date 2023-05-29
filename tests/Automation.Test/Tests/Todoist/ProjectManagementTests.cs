using Automation.Framework.Base;
using Automation.Test.Pages;
using Unity;

namespace Automation.Test.Tests.Todoist;

[TestClass]
public class ProjectManagementTests : BaseTest
{
    private readonly TodoistPage _todoistPage = CustomUnityContainer.GetContainer().Resolve<TodoistPage>();

    [TestMethod]
    public void VerifyCRUDProject()
    {
        string projectName = $"Mojix {Guid.NewGuid()}";
        string projectNameUpdated = $"Mojix Updated {Guid.NewGuid()}";

        _todoistPage.Helpers.BrowserComponent.Navigate(_todoistPage.BaseUrl);
        _todoistPage.ButtonEnterLogInWebElement.Click();
        _todoistPage.InputEmailWebElement.SendKeys(Constants.PersonalEmail);
        _todoistPage.InputPasswordWebElement.SendKeys(Constants.PersonalPassword);
        _todoistPage.ButtonLogInWebElement.Click();

        Assert.IsTrue(_todoistPage.IsVisibleUserSessionButton,
                      $"¡ERROR! The user is not valid to logIn");

        _todoistPage.ButtonAddProjectWebElement.Click();
        _todoistPage.InputProjectNameWebElement.SendKeys(projectName);
        _todoistPage.ButtonExpandColorsWebElement.Click();
        _todoistPage.ButtonSelectColorWebElement("grape").Click();
        _todoistPage.ButtonConfirmChangesWebElement.Click();

        Assert.IsTrue(_todoistPage.IsVisibleProjectCreatedTextBox(projectName),
                      $"¡ERROR! The project name wasn't created succesfully");

        _todoistPage.ButtonShowOptionsWebElement.Click();
        _todoistPage.ButtonEditProjectWebElement.Click();
        _todoistPage.InputProjectNameWebElement.Clear();
        _todoistPage.InputProjectNameWebElement.SendKeys(projectNameUpdated);
        _todoistPage.ButtonExpandColorsWebElement.Click();
        _todoistPage.ButtonSelectColorWebElement("green").Click();
        _todoistPage.ButtonConfirmChangesWebElement.Click();

        Assert.IsTrue(_todoistPage.IsVisibleProjectCreatedTextBox(projectNameUpdated),
                      $"¡ERROR! The project name wasn't updated succesfully");

        _todoistPage.ButtonShowOptionsWebElement.Click();
        _todoistPage.ButtonDeleteProjectWebElement.Click();
        _todoistPage.ButtonConfirmChangesWebElement.Click();

        Assert.IsFalse(_todoistPage.IsVisibleProjectCreatedTextBox(projectNameUpdated),
                      $"¡ERROR! The project name wasn't updated succesfully");
    }
}
