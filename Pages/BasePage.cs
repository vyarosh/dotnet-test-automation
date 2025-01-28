using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UiTests.Pages;

/// <summary>
/// Common functional across pages.
/// </summary>
public abstract class BasePage
{
    protected readonly Logger Logger = LogManager.GetCurrentClassLogger();
    public IWebDriver Driver = null!;
    private readonly WebDriverWait _wait;
    private static readonly int DEFAULT_WAIT = 30;
    
    private readonly Lazy<CookiesPopup> _cookiesPopup = new (() => new CookiesPopup(Driver));
    public CookiesPopup CookiesPopup => _cookiesPopup.Value;
    
    protected BasePage(IWebDriver driver)
    {
        Driver = driver;
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(DEFAULT_WAIT));
    }

        /// <summary>
        /// Waits for an element to be visible within a default timeout.
        /// </summary>
        /// <param name="locator">The locator of the element.</param>
        public IWebElement WaitForElementVisible(By locator)
        {
            Logger.Info($"Waiting({DEFAULT_WAIT}s) for element to be visible: {locator}...");
            return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        /// <summary>
        /// Waits for an element to be visible within a specified timeout.
        /// </summary>
        /// <param name="locator">The locator of the element.</param>
        /// <param name="timeoutSeconds">The timeout in seconds.</param>
        public IWebElement WaitForElementVisible(By locator, int timeoutSeconds)
        {
            Logger.Info($"Waiting({timeoutSeconds}s) for element to be visible: {locator}...");
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutSeconds))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        /// <summary>
        /// Waits for an element to be clickable within a default timeout.
        /// </summary>
        /// <param name="locator">The locator of the element.</param>
        public IWebElement WaitForElementClickable(By locator)
        {
            Logger.Info($"Waiting({DEFAULT_WAIT}s) for element to be clickable: {locator}...");
            return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }

        /// <summary>
        /// Waits for an element to be clickable within a specified timeout.
        /// </summary>
        /// <param name="locator">The locator of the element.</param>
        /// <param name="timeoutSeconds">The timeout in seconds.</param>
        public IWebElement WaitForElementClickable(By locator, int timeoutSeconds)
        {
            Logger.Info($"Waiting({timeoutSeconds}s) for element to be clickable: {locator}...");
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutSeconds))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }
        
        public IWebElement WaitForElementClickable(IWebElement elem, int timeoutSeconds)
        {
            Logger.Info($"Waiting({timeoutSeconds}s) for element to be clickable: {elem}...");
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutSeconds))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elem));
        }
}