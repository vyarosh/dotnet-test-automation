using NUnit.Framework;
using UiTests.Helpers;

namespace UiTests.Tests;

/// <summary>
/// Test class for Google search and Prometheus Group validation.
/// </summary>
[TestFixture]
public class GoogleSearchTests : BaseTest
{
    [Test]
    [Category("Smoke")]
    public void GoogleSearchForPrometheusGroup()
    {
        GoogleSearchPage.Open();
        GoogleSearchPage.Search("Prometheus Group");
        GoogleSearchPage.ValidateSearchResultsContains("Prometheus Group");
        GoogleSearchPage.ClickContactUsLink();

        ContactUsPage.CookiesPopup.Accept();
        ContactUsPage.WaitForElementVisible(ContactUsPage.InputFirstName).SendKeys("John");
        ContactUsPage.WaitForElementVisible(ContactUsPage.InputLastName).SendKeys("Snow");
        ContactUsPage.ClickSubmitButton();
        ContactUsPage.ValidateRequiredFieldsErrorsNumber(4);
    }
}
