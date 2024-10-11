using Application.DTOs;

namespace Application.Interface;

public interface IPacienteService
{
    Task<PacienteDTO> ObterPeloId(string id);
    Task<PacienteDTO> Atualizar(UpdatePacienteDTO updatePacienteDTO);
    Task<PacienteDTO> Create(CreatePacienteDTO createPacienteDTO);
    Task Excluir(string id);
}
