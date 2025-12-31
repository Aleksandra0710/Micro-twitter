using Microsoft.EntityFrameworkCore;
using MicroTwitter.Application.Posts.Queries.GetAllPosts;
using MicroTwitter.Domain.Entities;
using MicroTwitter.Infrastructure.Persistence;
using Xunit;

public class GetAllPostsHandlerTests
{
    [Fact]
    public async Task HandleAsync_ReturnsCorrectPosts_ForSecondPage()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        using var context = new AppDbContext(options);
        for (int i = 1; i <= 25; i++)
        {
            context.Posts.Add(
                new Post("user", $"Post this is testing  {i}")
            );
        }

        await context.SaveChangesAsync();

        var handler = new GetAllPostsHandler(context);

        var query = new GetAllPostsQuery(
            page: 2,
            pageSize: 10
        );
        var result = await handler.HandleAsync(query);

        Assert.Equal(25, result.TotalCount);
        Assert.Equal(10, result.Items.Count);      

    }
}
