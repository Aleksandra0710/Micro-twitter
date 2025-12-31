using Microsoft.EntityFrameworkCore;
using MicroTwitter.Infrastructure.Persistence;

namespace MicroTwitter.Application.Posts.Commands.DeletePost;

public class DeletePostHandler
{
    private readonly AppDbContext _dbContext;

    public DeletePostHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task HandleAsync(DeletePostCommand command)
    {
        var post = await _dbContext.Posts
            .FirstOrDefaultAsync(p => p.Id == command.PostId);

        if (post == null)
        {
            throw new InvalidOperationException("Post not found.");
        }

        if (post.Username != command.Username)
        {
            throw new InvalidOperationException("You are not allowed to delete this post.");
        }

        _dbContext.Posts.Remove(post);
        await _dbContext.SaveChangesAsync();
    }
}