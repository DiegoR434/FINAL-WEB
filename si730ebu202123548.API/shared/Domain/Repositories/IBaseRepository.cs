﻿namespace si730ebu202123548.API.shared.Domain.Repositories;

public interface IBaseRepository<TEntity>
{
    Task AddAsync(TEntity entity);

    Task<TEntity?> FindByIdAsync(int id);
    
    void Update(TEntity entity);
    
    void Remove(TEntity entity);
    
    Task<IEnumerable<TEntity>> ListAsync();
}