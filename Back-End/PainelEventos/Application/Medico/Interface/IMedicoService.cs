using Application.DTOs;

namespace Application.Interface;

public interface IMedicoService
{
    Task<Result<MedicoDTO>> ObterPeloId(string id);
    Task<Result<MedicoDTO>> Atualizar(UpdateMedicoDTO updateMedicoDTO);
    Task<Result<MedicoDTO>> Create(CreateMedicoDTO createMedicoDTO);
    Task<Result> Excluir(string id);
}
