using Microsoft.EntityFrameworkCore;
using MicroTwitter.Application.Posts.Commands.CreatePost;
using MicroTwitter.Infrastructure.Persistence;
using Xunit;

public class CreatePostHandlerTests
{
    [Fact]
    public async Task HandleAsync_ShouldCreatePost()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "CreatePostDb")
            .Options;

        using var context = new AppDbContext(options);
        var handler = new CreatePostHandler(context);

        var command = new CreatePostCommand(
            "aleksandra",
            "Post 1 ,sample content,test content ,up to 14 "
        );

        await handler.HandleAsync(command);

        var post = await context.Posts.FirstOrDefaultAsync();
        Assert.NotNull(post);
        Assert.Equal("aleksandra", post.Username);
    }
}
