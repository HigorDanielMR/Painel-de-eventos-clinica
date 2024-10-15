using Application.DTOs;

namespace Application.Interface;

public interface IClinicaService
{
    Task<Result<ClinicaDTO>> ObterPeloId(string id);
    Task<Result<ClinicaDTO>> Atualizar(UpdateClinicaDTO updateClinicaDTO);
    Task<Result<ClinicaDTO>> Create(CreateClinicaDTO createDTO);
    Task<Result> Excluir(string id);
}
