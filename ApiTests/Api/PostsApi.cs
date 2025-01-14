using ApiTests.Helpers;

namespace ApiTests.Api;

public class PostsApi : ApiHelper
{
    public PostsApi(string baseUrl) : base(baseUrl) { }

    /// <summary>
    /// List all posts from the API.
    /// Deserializable as Array of <see cref="PostsApi"/>
    /// </summary>
    /// <returns><see cref="ApiResponse"/> instance</returns>
    public ApiResponse GetAll() 
    {
        var response = Get("/posts");
        return new ApiResponse(response);
    }
    
    /// <summary>
    /// Creates a new post using the API.
    /// </summary>
    /// <param name="payload"><see cref="PostsApi"/> object for the new post</param>
    /// <returns><see cref="ApiResponse"/> instance</returns>
    public ApiResponse CreateNew(object payload) 
    {
        var response = Post("/posts", payload);
        return new ApiResponse(response);
    }

    /// <summary>
    /// Updates an existing post using the API.
    /// </summary>
    /// <param name="id">The unique identifier of the post to update.</param>
    /// <param name="payload">The data to update the post, on or more fields of <see cref="PostsApi"/>.</param>
    /// <returns><see cref="ApiResponse"/> instance</returns>
    public ApiResponse UpdateExisting(int id, object payload) 
    {
        var response = Put($"/posts/{id}", payload);
        return new ApiResponse(response);
    }

    /// <summary>
    /// Deletes a post using the API.
    /// </summary>
    /// <param name="id">The unique identifier of the post to delete.</param>
    /// <returns><see cref="ApiResponse"/> instance</returns>
    public ApiResponse DeleteOne(int id) 
    {
        return new ApiResponse(Delete($"/posts/{id}"));
    }
}