using ApiTests.Helpers;

namespace ApiTests.Api;

/// <summary>
/// JSONPlaceholder API collection.
/// </summary>
public class JsonPlaceholderApi 
{
    public PostsApi Posts { get; }

    public JsonPlaceholderApi()
    {
        var baseUrl = ConfigHelper.ReadConfigFile("BaseUrl");
        Posts = new PostsApi(baseUrl);
    }

        
}