using NUnit.Framework;
using OpenQA.Selenium;
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
        GoogleSearchPage.Search("Yahoo");
        GoogleSearchPage.ValidateSearchResultsContains("Yahoo");
        GoogleSearchPage.ClickContactUsLink();
    }
    
    [Test]
    [Category("Smoke")]
    public void GoogleSearchForLinks()
    {
		// search for Trump and return collection of link that contain the word. Then click on 3rd link        
		GoogleSearchPage.Open();
        GoogleSearchPage.Search("Trump");
        var links = GoogleSearchPage.ScrapeLinksWithText("Trump");
        GoogleSearchPage.WaitForElementClickable(links[2], 2).Click();
        GoogleSearchPage.Driver.FindElement(By.Id("ololo")).Click();
    }
   
}
