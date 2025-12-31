using Microsoft.EntityFrameworkCore;
using MicroTwitter.Application.Posts.Queries.GetMyPosts;
using MicroTwitter.Domain.Entities;
using MicroTwitter.Infrastructure.Persistence;
using Xunit;

public class GetMyPostsHandlerTests
{
    [Fact]
    public async Task HandleAsync_ReturnsOnlyUserPosts_WithPagination()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        using var context = new AppDbContext(options);

        context.Posts.Add(new Post("aleksandra", "Post 1,this is testing"));
        context.Posts.Add(new Post("aleksandra", "Post 2this is testing"));
        context.Posts.Add(new Post("john", "Post 3 this is testing"));

        await context.SaveChangesAsync();

        var handler = new GetMyPostsHandler(context);

        var query = new GetMyPostsQuery(
            username: "aleksandra",
            page: 1,
            pageSize: 10
        );

        var result = await handler.HandleAsync(query);

        Assert.Equal(2, result.TotalCount);       
        Assert.Equal(2, result.Items.Count);         

        Assert.All(result.Items, post =>
        {
            Assert.Equal("aleksandra", post.Username);
        });
    }
}
