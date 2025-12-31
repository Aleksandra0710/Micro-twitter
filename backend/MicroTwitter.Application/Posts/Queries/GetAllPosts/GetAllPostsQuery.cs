namespace MicroTwitter.Application.Posts.Queries.GetAllPosts;

public class GetAllPostsQuery
{
    public int Page { get; }
    public int PageSize { get; }
    public GetAllPostsQuery(int page, int pageSize)
    {
        Page = page;
        PageSize = pageSize;
    }
}