using System.Formats.Tar;
using Microsoft.EntityFrameworkCore;
using MicroTwitter.Domain.Entities;
using MicroTwitter.Infrastructure.Persistence;
using MicroTwitter.Application.Posts.Models;
namespace MicroTwitter.Application.Posts.Queries.GetAllPosts;

public class GetAllPostsHandler
{
    private readonly AppDbContext _dbContext;

    public GetAllPostsHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<PostsPerPage<Post>> HandleAsync(GetAllPostsQuery query)
    {
        var posts= _dbContext.Posts
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