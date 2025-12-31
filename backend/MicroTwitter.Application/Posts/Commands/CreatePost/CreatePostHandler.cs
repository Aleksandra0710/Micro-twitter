using MicroTwitter.Domain.Entities;
using MicroTwitter.Infrastructure.Persistence;

namespace MicroTwitter.Application.Posts.Commands.CreatePost;

public class CreatePostHandler
{
    private readonly AppDbContext _dbContext;

    public CreatePostHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task HandleAsync(CreatePostCommand command)
    {
        var post = new Post(command.Username, command.Content);

        _dbContext.Posts.Add(post);
        await _dbContext.SaveChangesAsync();
    }
}