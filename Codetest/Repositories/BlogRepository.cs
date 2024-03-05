using Codetest.Data;
using Codetest.Interfaces;
using Codetest.Models;
using Microsoft.EntityFrameworkCore;

namespace TAKHATY.Repositories;
public class BlogRepository : IBlogRepository
{
    private readonly ApplicationDbContext _context;
    public BlogRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Blog> Add(Blog blog)
    {
        await _context.Blogs.AddAsync(blog);
        _context.SaveChanges();
        return blog;
    }

    public async Task Delete(int id)
    {
        _context.Blogs.Remove(await GetById(id));
        _context.SaveChanges();
    }

    public async Task<IEnumerable<Blog>> GetAll()
    {
        return await _context.Blogs.ToListAsync();
    }

    public async Task<Blog> GetById(int id)
    {
        var blog = await _context.Blogs.FindAsync(id);
        if (blog == null)
        {
            throw new InvalidOperationException($"Blog with ID {id} not found.");
        }
        return blog;

    }
    public async Task<Blog> Update(Blog blog)
    {
        _context.Entry(blog).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return blog;
    }
    public bool Exists(int id)
    {
        return _context.Blogs.Any(e => e.Id == id);
    }
}

