using Microsoft.AspNetCore.Mvc;
namespace MicroTwitter.Api.Controllers;
using MicroTwitter.Application.Posts.Commands.CreatePost;
using MicroTwitter.Application.Posts.Commands.DeletePost;
using MicroTwitter.Application.Posts.Queries.GetAllPosts;
using MicroTwitter.Application.Posts.Queries.GetMyPosts;
using MicroTwitter.Api.Models;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.VisualBasic;

[ApiController]
[Route("api/posts")]
public class PostsController : ControllerBase
{
    private const string CurrentUser = "aleksandra";

    private readonly GetAllPostsHandler _getAllPostsHandler;
    private readonly GetMyPostsHandler _getMyPostsHandler;
    private readonly CreatePostHandler _createPostHandler;
    private readonly DeletePostHandler _deletePostHandler;
    public PostsController(
        GetAllPostsHandler getAllPostsHandler,
        GetMyPostsHandler getMyPostsHandler,
        CreatePostHandler createPostHandler,
        DeletePostHandler deletePostHandler)
    {
        _getAllPostsHandler = getAllPostsHandler;
        _getMyPostsHandler = getMyPostsHandler;
        _createPostHandler = createPostHandler;
        _deletePostHandler = deletePostHandler;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(int page=1,int pageSize=10)
    {
        var result=await _getAllPostsHandler.
        HandleAsync(new GetAllPostsQuery(page,pageSize));
        return Ok(result);
    }

    [HttpGet("mine")]
    public async Task<IActionResult> GetMine(int page=1,int pageSize=10)
    {
        var result = await _getMyPostsHandler.HandleAsync(
            new GetMyPostsQuery(CurrentUser, page, pageSize));

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePostRequest request)
    {
        var command = new CreatePostCommand(CurrentUser, request.Content);

        await _createPostHandler.HandleAsync(command);

        return Ok();
    }
    [HttpDelete("{id:guid}")]
   public async Task<IActionResult> Delete(Guid id)
{
    try
    {
        var command = new DeletePostCommand(id, CurrentUser);
        await _deletePostHandler.HandleAsync(command);
        return NoContent();
    }
    catch (InvalidOperationException ex)
    {
        return BadRequest(new { message = ex.Message });
    }
}
}