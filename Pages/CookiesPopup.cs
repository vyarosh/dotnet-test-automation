using OpenQA.Selenium;

namespace UiTests.Pages;

/// <summary>
/// Cookies Popup with Accept and Decline options.
/// </summary>
public class CookiesPopup: BasePage
{
    private readonly By _acceptButton = By.Id("hs-eu-confirmation-button");
    private readonly By _declineButton = By.Id("hs-eu-decline-button");

    public CookiesPopup(IWebDriver driver): base(driver) { }

    /// <summary>
    /// Clicks the Accept button.
    /// </summary>
    public void Accept()
    {
        WaitForElementClickable(_acceptButton).Click();
    }

    /// <summary>
    /// Clicks the Decline button.
    /// </summary>
    public void Decline()
    {
        WaitForElementClickable(_declineButton).Click();
    }
}