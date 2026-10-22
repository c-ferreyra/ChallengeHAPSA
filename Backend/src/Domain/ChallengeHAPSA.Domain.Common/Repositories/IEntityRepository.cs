using ChallengeHAPSA.Domain.Common.Entities;
using System.Linq.Expressions;

namespace ChallengeHAPSA.Domain.Common.Repositories
{
    public interface IEntityRepository<T, TK>
        where T : Entity<TK>
        where TK : struct
    {
        // Obtener todos los registros
        Task<IEnumerable<T>> GetAllAsync();

        // Obtener por ID
        Task<T?> GetByIdAsync(TK id);

        // Buscar con condiciones (filtrado)
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

        // Agregar una nueva entidad
        Task AddAsync(T entity);

        // Actualizar una entidad existente
        void Update(T entity);

        // Eliminar una entidad
        void Remove(T entity);
    }
}
