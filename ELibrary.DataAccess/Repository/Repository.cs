
using System.Linq.Expressions;
using ELibrary.DataAccess.Data;
using ELibrary.DataAccess.Repository.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace ELibrary.DataAccess.Repository;

public class Repository<T>(DataContext dataContext) : IRepository<T> where T : class
{
    protected readonly DataContext _dataContext = dataContext;

    public async Task AddAsync(T entity)
    {
        await _dataContext.Set<T>().AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<T> entity)
    {
        await _dataContext.Set<T>().AddRangeAsync(entity);
    }


    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dataContext.Set<T>().ToListAsync();
    }

    public async Task<T?> GetAsync(Expression<Func<T, bool>> filter)
    {
        return await _dataContext.Set<T>().Where(filter).FirstOrDefaultAsync();
    }


    public void Remove(T entity)
    {
        _dataContext.Set<T>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        _dataContext.Set<T>().RemoveRange(entities);
    }
}