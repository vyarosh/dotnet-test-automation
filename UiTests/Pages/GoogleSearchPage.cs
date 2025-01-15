using NUnit.Framework;
using OpenQA.Selenium;

namespace UiTests.Pages;

/// <summary>
/// Google Search Page: Objects and interaction collection
/// </summary>
public class GoogleSearchPage : BasePage
{
    private const string PAGE_URL = "http://www.google.com";
    public readonly By SearchBox = By.Name("q");
    public readonly By ButtonGoogleSearch = By.XPath("//input[@value=\"Google Search\"]");
    public readonly By ContainerSearchResults = By.Id("rso");
    public readonly By LinkContactUs = By.XPath("//a[text()='Contact Us' and contains(@href, 'prometheusgroup.com')]");
        
    public GoogleSearchPage(IWebDriver driver) : base(driver) { }

    /// <summary>
    /// Opens page by navigating to URL
    /// </summary>
    public void Open()
    {
        Logger.Info($"Open {PAGE_URL}...");
        Driver.Navigate().GoToUrl(PAGE_URL);
    }
    
    /// <summary>
    /// Enters a search query and submits it.
    /// </summary>
    /// <param name="query">The search query</param>
    public void Search(string query)
    {
        Logger.Info($"Entering search query: {query}...");
        WaitForElementClickable(SearchBox).SendKeys(query);
        WaitForElementClickable(ButtonGoogleSearch).Click();
        WaitForElementVisible(ContainerSearchResults);
    }

    /// <summary>
    /// Clicks on the Prometheus "Contact Us" link in the search results.
    /// </summary>
    public void ClickContactUsLink()
    {
        Logger.Info("Clicking on 'Contact Us' link...");
        WaitForElementClickable(LinkContactUs).Click();
    }

    /// <summary>
    /// Verifies that the search results contain the specified text.
    /// </summary>
    /// <param name="text">The text to validate.</param>
    public void ValidateSearchResultsContains(string text)
    {
        Logger.Info($"Validating search results for text: {text}...");
        Assert.That(
            WaitForElementVisible(ContainerSearchResults).Text, 
            Does.Contain(text), 
            $"Search results do not contain '{text}'."
        );
    }
}