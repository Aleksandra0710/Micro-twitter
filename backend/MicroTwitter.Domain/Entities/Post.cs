namespace MicroTwitter.Domain.Entities;
public class Post
{
    public Guid Id { get; private set; }
    public string Username { get; private set; }
    public string Content { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private Post() { } 

    public Post(string username, string content)
    {
        if (string.IsNullOrWhiteSpace(content))
            throw new ArgumentException("Content is required");

        if (content.Length < 12 || content.Length > 140)
            throw new ArgumentException("Must be between 12 and 140 characters");

        Id = Guid.NewGuid();
        Username = username;
        Content = content;
        CreatedAt = DateTime.UtcNow;
    }
}