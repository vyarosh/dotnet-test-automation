using ApiTests.Api;
using NLog;
using NUnit.Framework;

namespace ApiTests.Helpers;

/// <summary>
/// Base class for all tests, contains setup and teardown and common methods.
/// </summary>
public class BaseTest {
    protected JsonPlaceholderApi JsonPlaceholderApi;
        
    protected static readonly Logger _logger = LogManager.GetCurrentClassLogger();

    [OneTimeSetUp]
    public void BeforeAllTests()
    {
        _logger.Info("Setup test run...");
        JsonPlaceholderApi = new JsonPlaceholderApi();
    }
        
    [SetUp]
    public void BaseSetup() {
        _logger.Info("Before test...");
    }

    [TearDown]
    public void BaseTeardown() {
        _logger.Info("After test...");
    }
}