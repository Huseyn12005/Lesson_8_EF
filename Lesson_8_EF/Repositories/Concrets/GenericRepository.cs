using Lesson_8_EF.Datas;
using Lesson_8_EF.Models.Entities.Abstracts;
using Lesson_8_EF.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Lesson_8_EF.Repositories.Concrets;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
{
    protected readonly AppDbContext? _context;
    protected readonly DbSet<T>? _entity;

    public GenericRepository(AppDbContext? context)
    {
        _context = context;
        _entity = _context?.Set<T>();
    }


    public async Task AddAsync(T entity)
    {
        _entity?.Add(entity);
    }

    public async Task DeleteAsync(T entity)
    {
        _entity?.Remove(entity);
    }

    public async Task<IQueryable<T>> GetAllAsync()
    {
        return _entity!;
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _entity.FindAsync(id);
    }

    public async Task SaveChangeAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _entity?.Update(entity);
    }
}
