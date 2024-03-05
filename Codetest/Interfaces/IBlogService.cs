using Codetest.Models;

namespace Codetest.Interfaces;

public interface IBlogService
{
    Task<Blog> Add(Blog blog);
    Task<IEnumerable<Blog>> GetAll();
    Task<Blog> GetById(int id);
    Task<Blog> Update(Blog blog);
    Task Delete(int id);
}