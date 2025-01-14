using ApiTests.Helpers;
using ApiTests.Helpers.Models;
using NUnit.Framework;

namespace ApiTests.Tests;

[TestFixture]
public class JsonPlaceApiTests : BaseTest {
    [Test]
    [Category("API")]
    [Category("Smoke")]
    public void GetReturnsPostsArrayTest() {
        List<BoardPost> posts = JsonPlaceholderApi.Posts.GetAll().ValidateOk().GetBodyAs<List<BoardPost>>();
        Assert.That(posts, Has.Count.GreaterThan(1));
        Assert.That(posts[1], Is.TypeOf<BoardPost>());
    }

    [Test]
    [Category("API")]
    [Category("Smoke")]
    public void CreatePostOkTest() {
        var payload = new BoardPost
        {
            Id = 12,
            Title = "How to jump",
            Body = "no idea =)",
            UserId = 34353
        };
        JsonPlaceholderApi.Posts.CreateNew(payload).ValidateStatusCode(201);
    }
        
    [Test]
    [Category("API")]
    public void CreatePostWithMissingFieldsTest()
    {
        var incompletePostData = new { title = "Missing Body and UserId" };
        var error = JsonPlaceholderApi.Posts.CreateNew(incompletePostData)
            .ValidateStatusCode(400)
            .GetBodyAsObject();
        Assert.That(error.message, Is.Not.Null, "Expected a 'message' field in the error response.");
        Assert.That(error.message, Is.Not.Empty, "Expected an error message for missing fields.");
    }

    [Test]
    [Category("API")]
    public void UpdatePostOkTest() {
        var payload = new { title = "New title" };
        JsonPlaceholderApi.Posts.UpdateExisting(1, payload)
            .ValidateOk();
    }

    [Test]
    [Category("API")]
    public void DeletePostOkTest() {
        JsonPlaceholderApi.Posts.DeleteOne(1)
            .ValidateOk();
    }
}