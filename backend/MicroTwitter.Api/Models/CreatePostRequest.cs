using System.ComponentModel.DataAnnotations;

namespace MicroTwitter.Api.Models;

public class CreatePostRequest
{
    public string Content { get; set; } = string.Empty;
}