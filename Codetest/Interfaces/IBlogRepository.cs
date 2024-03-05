using Codetest.Models;

namespace Codetest.Interfaces;

public interface IBlogRepository
{
    Task<Blog> Add(Blog blog);
    Task<IEnumerable<Blog>> GetAll();
    Task<Blog> GetById(int id);
    Task<Blog> Update(Blog blog);
    Task Delete(int id);
    bool Exists(int id);
}