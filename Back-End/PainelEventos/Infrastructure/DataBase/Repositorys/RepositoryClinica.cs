using Domain.Entity;
using Domain.Interface;
using Infrastructure.DataBase.Repositorys.Base;

namespace Infrastructure.DataBase.Repositorys;

public class RepositoryClinica : RepositoryBase<Clinica>, IClinicaRepository
{
    public RepositoryClinica(AppDbContext dbContext) : base(dbContext)
    {
    }
}
