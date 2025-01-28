using NLog;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UiTests.Pages;

namespace UiTests.Helpers;

/// <summary>
/// Base class for all tests, contains setup and teardown and common methods.
/// </summary>
public class BaseTest
{
    private static IWebDriver _driver = null!;
    protected readonly Logger Logger = LogManager.GetCurrentClassLogger();

    /// Pages declaration with lazy init
    private readonly Lazy<GoogleSearchPage> _googleSearchPage = new (() => new GoogleSearchPage(_driver));
    private readonly Lazy<ContactUsPage> _contactUsPage = new (() => new ContactUsPage(_driver));

    protected GoogleSearchPage GoogleSearchPage => _googleSearchPage.Value;
    protected ContactUsPage ContactUsPage => _contactUsPage.Value;
    
    [SetUp]
    public void Setup()
    {
        Logger.Info("Launching Browser...");
        _driver = new ChromeDriver();
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        _driver.Manage().Window.Maximize();
    }

    [TearDown]
    public void Teardown()
    {
        Logger.Info("Closing Browser...");
        _driver.Quit();
    }
}