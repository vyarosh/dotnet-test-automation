namespace ApiTests.Helpers.Models;

/// <summary>
/// Represents a post resource from the JSONPlaceholder API.
/// </summary>
public class BoardPost
{
    public required int Id { get; set; }
    public required string Title { get; set; }
    public required string Body { get; set; }
    public required int UserId { get; set; }
}