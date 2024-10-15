using Domain.Entity;
using Domain.Interface;
using Infrastructure.DataBase.Repositorys.Base;

namespace Infrastructure.DataBase.Repositorys;

public class RepositoryPaciente : RepositoryBase<Paciente>, IPacienteRepository
{
    public RepositoryPaciente(AppDbContext dbContext) : base(dbContext)
    {
    }
}
