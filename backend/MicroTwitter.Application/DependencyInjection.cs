using Microsoft.Extensions.DependencyInjection;
using MicroTwitter.Application.Posts.Commands.CreatePost;
using MicroTwitter.Application.Posts.Commands.DeletePost;
using MicroTwitter.Application.Posts.Queries.GetAllPosts;
using MicroTwitter.Application.Posts.Queries.GetMyPosts;

namespace MicroTwitter.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<GetAllPostsHandler>();
        services.AddScoped<GetMyPostsHandler>();
        services.AddScoped<CreatePostHandler>();
        services.AddScoped<DeletePostHandler>();

        return services;
    }
}