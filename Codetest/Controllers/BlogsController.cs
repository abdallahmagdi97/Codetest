using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Codetest.Models;
using Codetest.Interfaces;
using Codetest.Models.Responses;

namespace Codetest.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class BlogsController : ControllerBase
{
    private readonly IBlogService _blogService;

    public BlogsController(IBlogService blogService)
    {
        _blogService = blogService;
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBlog(int id)
    {
        try
        {
            var blog = await _blogService.GetById(id);
            return Ok(blog);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
        }
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetBlogs()
    {
        try
        {
            var blogs = await _blogService.GetAll();
            return Ok(blogs);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
        }
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> AddBlog([FromForm] Blog blog)
    {
        try
        {
            await _blogService.Add(blog);
            return Ok(blog);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
        }
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBlog(int id, [FromForm] Models.Blog blog)
    {
        if (blog.Id != id)
        {
            return BadRequest();
        }

        try
        {
            await _blogService.Update(blog);
            return Ok(blog);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
        }
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBlog(int id)
    {
        try
        {
            await _blogService.Delete(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = ex.Message });
        }
    }

}

