using Automation.Framework.Base;
using Automation.Framework.Enums;
using OpenQA.Selenium;

namespace Automation.Test.Pages;

public abstract class TodolyPage : BasePage
{
    protected TodolyPage(IWebDriver driver) : base(driver) { }

    public string BaseUrl = "https://todo.ly/";

    public IWebElement ButtonLogInWebElement
        => WaitTillElementDisplayed("//img[@src='/Images/design/pagelogin.png']", LocatorElement.Xpath);

    public IWebElement InputEmailWebElement
    => WaitTillElementDisplayed("ctl00_MainContent_LoginControl1_TextBoxEmail", LocatorElement.ID);

    public IWebElement InputPasswordWebElement
    => WaitTillElementDisplayed("ctl00_MainContent_LoginControl1_TextBoxPassword", LocatorElement.ID);

    public IWebElement ButtonConfirmLogInElement
    => WaitTillElementDisplayed("ctl00_MainContent_LoginControl1_ButtonLogin", LocatorElement.ID);

    public IWebElement ButtonAddNewProjectWebElement
    => WaitTillElementDisplayed("//td[text()='Add New Project']", LocatorElement.Xpath);

    public IWebElement InputProjectNameWebElement
    => WaitTillElementDisplayed("NewProjNameInput", LocatorElement.ID);

    public IWebElement ButtonSaveNewProjectWebElement
    => WaitTillElementDisplayed("NewProjNameButton", LocatorElement.ID);

    public IWebElement ItemProjectNameWebElement(string projectName)
    => WaitTillElementDisplayed($"//ul[@id='mainProjectList']/li//td[text()='{projectName}'][last()]", LocatorElement.Xpath);

    public IWebElement InputTaskNameWebElement
    => WaitTillElementDisplayed("NewItemContentInput", LocatorElement.ID);

    public IWebElement ButtonAddNewTaskWebElement
    => WaitTillElementDisplayed("NewItemAddButton", LocatorElement.ID);

    public IWebElement ButtonSubMenuActionableWebElement
    => WaitTillElementDisplayed("//div[contains(@style,'block')]/img", LocatorElement.Xpath);

    public IWebElement ButtonEditProjectWebElement
    => WaitTillElementDisplayed("//ul[contains(@style,'block')]//a[text()='Edit']", LocatorElement.Xpath);

    public IWebElement InputEditProjectWebElement
    => WaitTillElementDisplayed("//td/div/input[@id='ItemEditTextbox']", LocatorElement.Xpath);

    public IWebElement ButtonSubmitEditProjectWebElement
    => WaitTillElementDisplayed("//td/div/img[@id='ItemEditSubmit']", LocatorElement.Xpath);

    public bool IsVisibleProjectNameCreated(string projectName)
    => WaitIfElementDisplayed($"//ul[@id='mainProjectList']/li//td[text()='{projectName}'][last()]", LocatorElement.Xpath);

    public bool IsVisibleTaskNameCreated(string taskName)
    => WaitIfElementDisplayed($"//ul[@id='mainItemList']/li//div[text()='{taskName}']", LocatorElement.Xpath);

    public IWebElement ItemTaskNameWebElement(string taskName)
    => WaitTillElementDisplayed($"//ul[@id='mainItemList']/li//div[text()='{taskName}']", LocatorElement.Xpath);

    public IWebElement ButtonSetDueDateWebElement
    => WaitTillElementDisplayed("//ul[@id='mainItemList']/li//div[text()='Set Due Date']/parent::div[contains(@style,'block')]", LocatorElement.Xpath);

    public IWebElement InputSetDueDateWebElement
    => WaitTillElementDisplayed("//div[@class='EditDueDate' and contains(@style, 'block')]//input[@id='EditDueDateAdvDate']", LocatorElement.Xpath);

    public IWebElement ButtonSaveDueDateWebElement
    => WaitTillElementDisplayed("//div[@class='EditDueDate' and contains(@style, 'block')]//input[@id='LinkShowDueDateSave']", LocatorElement.Xpath);

    public bool IsVisibleSetDueDateApplied(string dueDate)
    => WaitIfElementDisplayed($"//ul[@id='mainItemList']/li//div[text()='{dueDate}']/parent::div[contains(@style,'block')]", LocatorElement.Xpath);

    public void Login(string email, string password)
    {
        ButtonLogInWebElement.Click();
        InputEmailWebElement.SendKeys(email);
        InputPasswordWebElement.SendKeys(password);
        ButtonConfirmLogInElement.Click();
    }
}
