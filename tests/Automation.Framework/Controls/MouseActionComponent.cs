using Automation.Framework.Controls.Interfaces;
using Automation.Framework.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Automation.Framework.Controls;

public class MouseActionComponent : IMouseActionComponent
{
    public void MoveToElement(IWebElement element)
    {
        Actions actions = new Actions(Driver.Browser);
        actions.MoveToElement(element).Perform();
    }
}
