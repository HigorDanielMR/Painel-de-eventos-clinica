using Application.DTOs;

namespace Application.Interface;

public interface IPacienteService
{
    Task<Result<PacienteDTO>> ObterPeloId(string id);
    Task<Result<PacienteDTO>> Atualizar(UpdatePacienteDTO updatePacienteDTO);
    Task<Result<PacienteDTO>> Create(CreatePacienteDTO createPacienteDTO);
    Task<Result> Excluir(string id);
}
