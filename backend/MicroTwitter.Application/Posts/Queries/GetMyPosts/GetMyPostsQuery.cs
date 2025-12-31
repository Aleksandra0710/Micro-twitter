namespace MicroTwitter.Application.Posts.Queries.GetMyPosts;

public class GetMyPostsQuery
{
    public string Username { get; }
     public int Page { get; }
    public int PageSize { get; }

    public GetMyPostsQuery(string username,int page,int pageSize)
    {
        Username = username;
        Page = page;
        PageSize = pageSize;
    }   
}