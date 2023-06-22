using Automation.Framework.Base;
using Automation.Framework.Controls;
using Automation.Test.Pages;
using Unity;

namespace Automation.Test.Tests.YopMail;

[TestClass]
public class EmailManagementTests : BaseTest
{
    private readonly YopMailPage _yopMailPage = CustomUnityContainer.GetContainer().Resolve<YopMailPage>();

    [TestMethod]
    public void VerifyMailDeliverySuccessfully()
    {
        string subject = $"subject {Guid.NewGuid()}";
        string bodyMessage = $"body {Guid.NewGuid()}";

        _yopMailPage.Helpers.BrowserComponent.Navigate(YopMailPage.BaseUrl);
        _yopMailPage.InputEmailWebElement.SendKeys(Constants.YopMailEmail);
        _yopMailPage.ButtonCheckEmailWebElement.Click();

        Assert.IsTrue(_yopMailPage.IsVisibleEmailTitleTextBox,
                      $"¡ERROR! Email: {Constants.YopMailEmail} is not valid");

        _yopMailPage.ButtonNewEmailWebElement.Click();
        BrowserComponent.SwitchToFrame(_yopMailPage.FrameNewEmailWebElement);
        _yopMailPage.InputToEmailWebElement.SendKeys(Constants.YopMailEmail);
        _yopMailPage.InputSubjectEmailWebElement.SendKeys(subject);
        _yopMailPage.InputBodyEmailWebElement.SendKeys(bodyMessage);

        Assert.IsTrue(_yopMailPage.ButtonSendEmailWebElement.Enabled,
                      $"¡ERROR! Send email button is not enable.");

        _yopMailPage.ButtonSendEmailWebElement.Click();
        BrowserComponent.SwitchToDefaultContent();
        _yopMailPage.ButtonRefreshInboxWebElement.Click();
        BrowserComponent.SwitchToFrame(_yopMailPage.FrameInboxWebElement);

        Assert.IsTrue(_yopMailPage.IsVisibleEmailInInboxTextBox(subject),
                      $"¡ERROR! Message email was not found");
    }
}
