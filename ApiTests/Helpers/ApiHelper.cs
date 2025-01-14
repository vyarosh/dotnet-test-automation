using System.Text;
using Newtonsoft.Json;
using NLog;

namespace ApiTests.Helpers;

/// <summary>
/// API Engine wrapper. Provides prepared HTTP API requests and handles client setup.
/// </summary>
public class ApiHelper {
    private readonly HttpClient _client;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

    /// <summary>
    /// Initializes a new instance of the <see cref="ApiHelper"/> class.
    /// </summary>
    /// <param name="baseUrl">The base URL for the API.</param>
    protected ApiHelper(string baseUrl) {
        _client = new HttpClient { BaseAddress = new Uri(baseUrl) };
        _logger.Info($"Initialized API client with base URL: {baseUrl}");
    }

    /// <summary>
    /// Sends a GET request to the specified endpoint.
    /// </summary>
    /// <param name="endpoint">The API endpoint.</param>
    /// <returns>The HTTP response message.</returns>
    protected HttpResponseMessage Get(string endpoint) {
        _logger.Info($"GET {endpoint}");
        return _client.GetAsync(endpoint).GetAwaiter().GetResult();
    }

    /// <summary>
    /// Sends a POST request to the specified endpoint with the provided data.
    /// </summary>
    /// <param name="endpoint">The API endpoint.</param>
    /// <param name="data">The data to include in the request body.</param>
    /// <returns>The HTTP response message.</returns>
    protected HttpResponseMessage Post(string endpoint, object data) {
        _logger.Info($"POST {endpoint} with data: {JsonConvert.SerializeObject(data)}");
        var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
        return _client.PostAsync(endpoint, content).GetAwaiter().GetResult();
    }

    /// <summary>
    /// Sends a PUT request to the specified endpoint with the provided data.
    /// </summary>
    /// <param name="endpoint">The API endpoint.</param>
    /// <param name="data">The data to include in the request body.</param>
    /// <returns>The HTTP response message.</returns>
    protected HttpResponseMessage Put(string endpoint, object data) {
        _logger.Info($"PUT {endpoint} with data: {JsonConvert.SerializeObject(data)}");
        var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
        return _client.PutAsync(endpoint, content).GetAwaiter().GetResult();
    }

    /// <summary>
    /// Sends a DELETE request to the specified endpoint.
    /// </summary>
    /// <param name="endpoint">The API endpoint.</param>
    /// <returns>The HTTP response message.</returns>
    protected HttpResponseMessage Delete(string endpoint) {
        _logger.Info($"DELETE {endpoint}");
        return _client.DeleteAsync(endpoint).GetAwaiter().GetResult();
    }
}