using Domain.Shared.Entity;

namespace Domain.Shared.Repository
{
    public interface IRepositoryBase<T> where T : EntityBase
    {
        Task<T> ObterPorId(string id);
        Task<T> Adicionar(T entity);
        Task<T> Atualizar(T entity);
        Task Remover(string id);
        Task<bool> EntityExiste(string id);
    }
}