using Application.DTOs;

namespace Application.Interface;

public interface IMedicoService
{
    Task<MedicoDTO> ObterPeloId(string id);
    Task<MedicoDTO> Atualizar(UpdateMedicoDTO updateMedicoDTO);
    Task<MedicoDTO> Create(CreateMedicoDTO createMedicoDTO);
    Task Excluir(string id);
}
