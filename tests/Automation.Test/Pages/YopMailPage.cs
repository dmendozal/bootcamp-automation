using Automation.Framework.Base;
using Automation.Framework.Enums;
using OpenQA.Selenium;

namespace Automation.Test.Pages;

internal class YopMailPage : BasePage
{
    public YopMailPage(IWebDriver driver) : base(driver) { }

    public string BaseUrl = "https://yopmail.com/";

    public IWebElement InputEmailWebElement
        => WaitTillElementDisplayed("login", LocatorElement.ID);

    public IWebElement ButtonCheckEmailWebElement
        => WaitTillElementDisplayed("//div[@id='refreshbut']//button", LocatorElement.Xpath);

    public bool IsVisibleEmailTitleTextBox
        => WaitIfElementDisplayed("bname", LocatorElement.ClassName);

    public IWebElement ButtonNewEmailWebElement
        => WaitTillElementDisplayed("newmail", LocatorElement.ID);

    public IWebElement InputToEmailWebElement
        => WaitTillElementDisplayed("msgto", LocatorElement.ID);

    public IWebElement InputSubjectEmailWebElement
        => WaitTillElementDisplayed("msgsubject", LocatorElement.ID);

    public IWebElement InputBodyEmailWebElement
        => WaitTillElementDisplayed("msgbody", LocatorElement.ID);

    public IWebElement ButtonSendEmailWebElement
        => WaitTillElementDisplayed("msgsend", LocatorElement.ID);

    public IWebElement ButtonRefreshInboxWebElement
        => WaitTillElementDisplayed("refresh", LocatorElement.ID);

    public bool IsVisibleEmailInInboxTextBox(string message)
        => WaitIfElementDisplayed($"//div[@class='mctn']//div[@class='m'][1]//div[@class='lms' and text()='{message}']", LocatorElement.Xpath);

    public IWebElement FrameNewEmailWebElement
        => WaitTillElementDisplayed("ifmail", LocatorElement.ID);
    public IWebElement FrameInboxWebElement
        => WaitTillElementDisplayed("ifinbox", LocatorElement.ID);

}
