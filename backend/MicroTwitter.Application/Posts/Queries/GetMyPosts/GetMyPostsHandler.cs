using Microsoft.EntityFrameworkCore;
using MicroTwitter.Domain.Entities;
using MicroTwitter.Infrastructure.Persistence;
using MicroTwitter.Application.Posts.Models;
namespace MicroTwitter.Application.Posts.Queries.GetMyPosts;

public class GetMyPostsHandler
{
    private readonly AppDbContext _dbContext;

    public GetMyPostsHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

     public async Task<PostsPerPage<Post>> HandleAsync(GetMyPostsQuery query)
    {
        var posts= _dbContext.Posts
            .Where(p => p.Username == query.Username)
            .OrderByDescending(p => p.CreatedAt);

        var totalCount=await posts.CountAsync();

        var postsPerPage=await posts
            .Skip((query.Page-1)*query.PageSize)
            .Take(query.PageSize)
            .ToListAsync();

        return new PostsPerPage<Post>
        {
            Items = postsPerPage,
            TotalCount = totalCount
        };
        
    }
}