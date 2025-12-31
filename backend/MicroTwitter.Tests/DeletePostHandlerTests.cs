using Microsoft.EntityFrameworkCore;
using MicroTwitter.Application.Posts.Commands.CreatePost;
using MicroTwitter.Infrastructure.Persistence;
using Xunit;
using MicroTwitter.Domain.Entities;
using MicroTwitter.Application.Posts.Commands.DeletePost;
using MicroTwitter.Infrastructure.Persistence;

public class DeletepostHandlerTests
{
    [Fact]
public async Task HandleAsync_ShouldDeletePost()
{
    var options = new DbContextOptionsBuilder<AppDbContext>()
        .UseInMemoryDatabase("DeletePostDb")
        .Options;

    using var context = new AppDbContext(options);

    var post = new Post("aleksandra", "Post 1 ,sample content,test content ,up to 14 ");
    context.Posts.Add(post);
    await context.SaveChangesAsync();

    var handler = new DeletePostHandler(context);
    var command = new DeletePostCommand(post.Id, "aleksandra");


    await handler.HandleAsync(command);

    Assert.Empty(context.Posts);
}

}