using Domain.Entity;
using Domain.Repository;
using Infrastructure.DataBase.Repositorys.Base;

namespace Infrastructure.DataBase.Repositorys;

public class RepositoryMedico : RepositoryBase<Medico>, IMedicoRepository
{
    public RepositoryMedico(AppDbContext dbContext) : base(dbContext)
    {
    }
}
