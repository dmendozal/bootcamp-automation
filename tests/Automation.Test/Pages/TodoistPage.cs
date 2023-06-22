using Automation.Framework.Base;
using Automation.Framework.Enums;
using OpenQA.Selenium;

namespace Automation.Test.Pages;

internal abstract class TodoistPage : BasePage
{
    protected TodoistPage(IWebDriver driver) : base(driver) { }

    public const string BaseUrl = "https://todoist.com/";

    public IWebElement ButtonEnterLogInWebElement
        => WaitTillElementDisplayed("//a[@href='/auth/login']/parent::li", LocatorElement.Xpath);

    public IWebElement InputEmailWebElement
        => WaitTillElementDisplayed("element-0", LocatorElement.ID);

    public IWebElement InputPasswordWebElement
        => WaitTillElementDisplayed("element-3", LocatorElement.ID);

    public IWebElement ButtonLogInWebElement
        => WaitTillElementDisplayed("//button[@data-gtm-id='start-email-login']", LocatorElement.Xpath);

    public bool IsVisibleUserSessionButton
        => WaitIfElementDisplayed(":r2:", LocatorElement.ID);

    public IWebElement ButtonAddProjectWebElement
        => WaitTillElementDisplayed("//button[@aria-label='Add project']", LocatorElement.Xpath, isWaitWebDriver: false);

    public IWebElement InputProjectNameWebElement
        => WaitTillElementDisplayed("edit_project_modal_field_name", LocatorElement.ID);

    public IWebElement ButtonExpandColorsWebElement
        => WaitTillElementDisplayed("//div[@class='form_field']/button", LocatorElement.Xpath);

    public IWebElement ButtonSelectColorWebElement(string color)
        => WaitTillElementDisplayed($"//li[@data-value='{color}']", LocatorElement.Xpath);

    public IWebElement ButtonConfirmChangesWebElement
        => WaitTillElementDisplayed("//footer//div//button[2]", LocatorElement.Xpath);

    public bool IsVisibleProjectCreatedTextBox(string projectName)
        => WaitIfElementDisplayed($"//ul[@id='projects_list']//li[last()]//span[text()='{projectName}']", LocatorElement.Xpath);

    public IWebElement ButtonShowOptionsWebElement
        => WaitTillElementDisplayed("//ul[@id='projects_list']//li[last()]//button", LocatorElement.Xpath, isWaitWebDriver: false);

    public IWebElement ButtonEditProjectWebElement
        => WaitTillElementDisplayed("//ul[@role='menu']//li[4]", LocatorElement.Xpath);

    public IWebElement ButtonDeleteProjectWebElement
        => WaitTillElementDisplayed("//ul[@role='menu']//li[13]", LocatorElement.Xpath);

}
