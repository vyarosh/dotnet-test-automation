using NUnit.Framework;
using OpenQA.Selenium;

namespace UiTests.Pages;

/// <summary>
/// Prometheus Contact Us page: Objects and interaction collection
/// </summary>
public class ContactUsPage : BasePage
{
    public readonly By InputFirstName = By.XPath("//input[@name='firstname']");
    public readonly By InputLastName = By.XPath("//input[@name='lastname']");
    public readonly By InputEmailAddress = By.XPath("//input[@name='email']");
    public readonly By InputCompanyName = By.XPath("//input[@name='company']");
    public readonly By ButtonSubmit = By.XPath("//input[@value='Submit']");
    public readonly By LabelFieldError = By.XPath("//label[@class='hs-error-msg hs-main-font-element']");
    public readonly By LabelRequiredFieldError = By.XPath("//label[text()='Please complete this required field.']");


    public ContactUsPage(IWebDriver driver) : base(driver) { }

    /// <summary>
    /// Clicks the Submit button on the Contact Us form.
    /// </summary>
    public void ClickSubmitButton()
    {
        Logger.Info("Clicking the Submit button...");
        WaitForElementClickable(ButtonSubmit).Click();
    }
 
    /// <summary>
    /// Validates that specified number of required fields errors are present on the page.
    /// </summary>
    /// <param name="expectedErrorCount">The number of Errors to validate</param>
    public void ValidateRequiredFieldsErrorsNumber(int expectedErrorCount)
    {
        Logger.Info($"Validating that {expectedErrorCount} required field error(s) are displayed...");
        WaitForElementVisible(LabelFieldError, 2);
        var errors = Driver.FindElements(LabelRequiredFieldError);
        Assert.That(errors.Count, Is.EqualTo(expectedErrorCount), 
            $"Expected {expectedErrorCount} error(s) but found {errors.Count}.");
    }
}