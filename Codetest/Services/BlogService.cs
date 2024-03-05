using Codetest.Interfaces;
using Codetest.Models;

namespace Codetest.Services;

public class BlogService : IBlogService
{
    private readonly IBlogRepository _blogRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public BlogService(IBlogRepository blogRepository, IHttpContextAccessor httpContextAccessor)
    {
        _blogRepository = blogRepository;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<Blog> Add(Blog blog)
    {
        return await _blogRepository.Add(blog);
    }

    public async Task Delete(int id)
    {
        if (!_blogRepository.Exists(id))
        {
            throw new Exception("Not Found");
        }
        await _blogRepository.Delete(id);
    }

    public async Task<IEnumerable<Blog>> GetAll()
    {
        var blogList = await _blogRepository.GetAll();
        return blogList;
    }

    public async Task<Blog> GetById(int id)
    {
        if (!_blogRepository.Exists(id))
        {
            throw new Exception("Not Found");
        }
        var blog = await _blogRepository.GetById(id);
        return blog;
    }

    public async Task<Blog> Update(Blog blog)
    {
        if (!_blogRepository.Exists(blog.Id))
        {
            throw new Exception("Not Found");
        }
        return await _blogRepository.Update(blog);
    }
}

