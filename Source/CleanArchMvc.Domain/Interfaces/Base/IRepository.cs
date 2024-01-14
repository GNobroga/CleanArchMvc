using CleanArchMvc.Domain.Entities.Base;

namespace CleanArchMvc.Domain.Interfaces.Base;

public interface IRepository<TEntity, TKey> where TEntity: BaseEntity<TKey>
{ 
    Task<IEnumerable<TEntity>> FindAllAsync();

    Task<TEntity> FindByIdAsync(int? id);

    Task<TEntity> SaveAsync(TEntity entity);

    Task<TEntity> UpdateAsync(TEntity entity);
    Task<TEntity> DeleteAsync(TEntity entity);
} 