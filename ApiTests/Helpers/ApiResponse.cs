using Newtonsoft.Json;
using NLog;
using NUnit.Framework;

namespace ApiTests.Helpers;

/// <summary>
/// Represents a wrapper for API responses, providing methods for validation and deserialization.
/// </summary>
public class ApiResponse
{
    private readonly HttpResponseMessage _response;
    private readonly string _responseBody;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    
    public ResponseBody Body => new ResponseBody(_responseBody);

    /// <summary>
    /// Main constructor, builds a new instance of <see cref="ApiResponse"/>.
    /// </summary>
    /// <param name="response">The HTTP response message.</param>
    public ApiResponse(HttpResponseMessage response)
    {
        _response = response;
        _responseBody = response.Content.ReadAsStringAsync().Result;
        _logger.Info($"Received response with status code: {(int)_response.StatusCode}");
    }

    /// <summary>
    /// Assert that the response has the expected status code.
    /// </summary>
    /// <param name="expectedStatusCode">The expected HTTP status code.</param>
    /// <returns>The current <see cref="ApiResponse"/> instance for method chaining.</returns>
    public ApiResponse ValidateStatusCode(int expectedStatusCode)
    {
        Assert.That((int)_response.StatusCode, Is.EqualTo(expectedStatusCode), 
            $"Expected status code {expectedStatusCode}, but got {(int)_response.StatusCode}");
        _logger.Info($"Status code {expectedStatusCode} validated successfully.");
        return this;
    }

    /// <summary>
    /// Asserts that the status code is 200 (OK).
    /// </summary>
    /// <returns>The current <see cref="ApiResponse"/> instance for method chaining.</returns>
    public ApiResponse ValidateOk()
    {
        return ValidateStatusCode(200);
    }

    

    /// <summary>
    /// Deserializes response body as a dynamic object (similar to JS object becuse it can!).
    /// </summary>
    /// <returns>The deserialized response body as a dynamic object.</returns>
    public dynamic GetBodyAsObject()
    {
        _logger.Info("Retrieving response body as a dynamic object.");
        return JsonConvert.DeserializeObject<dynamic>(_responseBody);
    }

    /// <summary>
    /// Deserializes response body as a specifified object type/model.
    /// </summary>
    /// <typeparam name="T">The type to deserialize the response body into.</typeparam>
    /// <returns>The deserialized object of type <typeparamref name="T"/>.</returns>
    public T GetBodyAs<T>()
    {
        _logger.Info("Retrieving response body as a specific object.");
        return JsonConvert.DeserializeObject<T>(_responseBody);
    }
}

/// <summary>
/// Collection of validations to have the following call chain: response.Body.Contains("Hello").
/// TODO: move to separate file when it will be more then 500 line
/// </summary>
public class ResponseBody
{
    private readonly string _bodyContent;

    /// <summary>
    /// Initializes a new instance of the <see cref="ResponseBody"/> class.
    /// </summary>
    /// <param name="bodyContent">The content of the response body.</param>
    public ResponseBody(string bodyContent)
    {
        _bodyContent = bodyContent;
    }

    /// <summary>
    /// Assert that the response body contains the specified string.
    /// </summary>
    /// <param name="expectedSubstring">The string expected to be found in the body.</param>
    public void Contains(string expectedSubstring)
    {
        Assert.That(_bodyContent, Does.Contain(expectedSubstring), 
            $"The response body does not contain the expected content: '{expectedSubstring}'.");
    }
}