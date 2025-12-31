namespace MicroTwitter.Application.Posts.Commands.DeletePost;

public class DeletePostCommand
{
    public Guid PostId { get; }
    public string Username { get; }

    public DeletePostCommand(Guid postId, string username)
    {
        PostId = postId;
        Username = username;
    }
}