using Domain.Shared.Entity;
using Domain.Shared.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataBase.Repositorys.Base
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
    {
        protected readonly DbContext _context;

        public RepositoryBase(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<T> Adicionar(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Atualizar(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public Task<bool> EntityExiste(string id)
        {
            return Task.FromResult(_context.Set<T>().Any(x => x.Id == id));
        }

        public async Task<T> ObterPorId(string id)
        {
            return await _context.Set<T>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Remover(string id)
        {
            var entity = await ObterPorId(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
