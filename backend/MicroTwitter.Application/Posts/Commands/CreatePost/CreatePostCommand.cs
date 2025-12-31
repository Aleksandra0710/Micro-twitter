namespace MicroTwitter.Application.Posts.Commands.CreatePost;

public class CreatePostCommand
{
    public string Username { get; }
    public string Content { get; }

    public CreatePostCommand(string username, string content)
    {
        Username = username;
        Content = content;
    }
}