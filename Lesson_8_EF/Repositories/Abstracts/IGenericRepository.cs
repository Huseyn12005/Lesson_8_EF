using Lesson_8_EF.Models.Entities.Abstracts;

namespace Lesson_8_EF.Repositories.Abstracts;

public interface IGenericRepository<T> where T : BaseEntity, new()
{
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<T> GetByIdAsync(int id);
    Task<IQueryable<T>> GetAllAsync();
    Task SaveChangeAsync();
}
