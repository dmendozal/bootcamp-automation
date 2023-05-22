using Automation.Framework.Common.Session;
using OpenQA.Selenium;

namespace Automation.Framework.Controls;

public class BaseControl
{
    protected By _locator;
    protected IWebElement _control;

    public BaseControl(By locator) => _locator = locator;

    protected void FindControl()
    {
        _control = DriverSession.Instance().GetBrowser().FindElement(_locator);
    }

    public void Click()
    {
        FindControl();
        _control.Click();
    }

    public bool IsControlDisplayed()
    {
        try
        {
            FindControl();

            return _control.Displayed;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
