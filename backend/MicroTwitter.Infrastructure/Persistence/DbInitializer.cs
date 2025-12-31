using MicroTwitter.Domain.Entities;

namespace MicroTwitter.Infrastructure.Persistence;

public static class DbInitializer
{
    public static void Seed(AppDbContext context)
    {
        if (context.Posts.Any())
            return;

        context.Posts.AddRange(
            new Post("john", "Hello from John, this is a dummy post!"),
            new Post("aleksandra", "My first post!"),
            new Post("emma", "This is Emas post"),
            new Post("john", "Hello from John, this is a dummy post!"),
            new Post("aleksandra", "My first post!"),
            new Post("emma", "This is Emas post"),
            new Post("john", "Hello from John, this is a dummy post!"),
            new Post("aleksandra", "My first post!"),
            new Post("emma", "This is Emas post")
        );

        context.SaveChanges();
    }
}
