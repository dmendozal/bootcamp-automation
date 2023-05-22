using Automation.Framework.Base;
using Automation.Test.Pages.YopMail;
using Unity;

namespace Automation.Test.Tests.YopMail;

[TestClass]
public class EmailManagementTests : BaseTest
{
    private readonly YopMailPage _yopMailPage = CustomUnityContainer.GetContainer().Resolve<YopMailPage>();

    [TestMethod]
    public void VerifyMailDeliverySuccessfully()
    {
        string email = "dmendozal@yopmail.com";
        string subject = "Este es el subject de una prueba automatizada";
        string bodyMessage = "Este es el body de una prueba automatizada";

        _yopMailPage.Helpers.BrowserComponent.Navigate(_yopMailPage.BaseUrl);
        _yopMailPage.InputEmailWebElement.SendKeys(email);
        _yopMailPage.ButtonCheckEmailWebElement.Click();

        Assert.IsTrue(_yopMailPage.IsVisibleEmailTitleTextBox,
                      $"¡ERROR! Email: {email} is not valid");

        _yopMailPage.ButtonNewEmailWebElement.Click();
        _yopMailPage.Helpers.BrowserComponent.SwitchToFrame(_yopMailPage.FrameNewEmailWebElement);
        _yopMailPage.InputToEmailWebElement.SendKeys(email);
        _yopMailPage.InputSubjectEmailWebElement.SendKeys(subject);

        _yopMailPage.InputBodyEmailWebElement.SendKeys(bodyMessage);

        Assert.IsTrue(_yopMailPage.ButtonSendEmailWebElement.Enabled,
                      $"¡ERROR! Send email button is not enable.");

        _yopMailPage.ButtonSendEmailWebElement.Click();
        _yopMailPage.Helpers.BrowserComponent.SwitchToDefaultContent();
        _yopMailPage.ButtonRefreshInboxWebElement.Click();
        _yopMailPage.Helpers.BrowserComponent.SwitchToFrame(_yopMailPage.FrameInboxWebElement);

        Assert.IsTrue(_yopMailPage.IsVisibleEmailInInboxTextBox(subject),
                      $"¡ERROR! Message email was not found");
    }
}
