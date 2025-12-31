namespace MicroTwitter.Application.Posts.Models;
public class PostsPerPage<T>
{
    public List<T> Items { get; set; } = [];
    public int TotalCount { get; set; }
}