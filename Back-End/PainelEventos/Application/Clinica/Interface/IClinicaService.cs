using Application.DTOs;

namespace Application.Interface;

public interface IClinicaService
{
    Task<ClinicaDTO> ObterPeloId(string id);
    Task<ClinicaDTO> Atualizar(UpdateClinicaDTO updateClinicaDTO);
    Task<ClinicaDTO> Create(CreateClinicaDTO createDTO);
    Task Excluir(string id);
}
