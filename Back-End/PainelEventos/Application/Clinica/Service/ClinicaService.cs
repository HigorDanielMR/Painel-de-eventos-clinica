using Domain.Interface;
using Domain.Entity;
using Application.DTOs;
using Application.Interface;
using Mapster;
using Domain.Shared.Exceptions;

namespace Application.Service;

public class ClinicaService : IClinicaService
{
    private readonly IClinicaRepository _clinicaRepository;

    public ClinicaService(IClinicaRepository clinicaRepository)
    {
        _clinicaRepository = clinicaRepository;
    }

    public async Task<ClinicaDTO> Atualizar(UpdateClinicaDTO updateClinicaDTO)
    {
        if (!await _clinicaRepository.EntityExiste(updateClinicaDTO.Id))
            throw new RegistroNaoExisteException();
        
        var clinica = await _clinicaRepository.ObterPorId(updateClinicaDTO.Id);

        clinica.Atualizar(clinica.Nome);

        clinica = await _clinicaRepository.Atualizar(clinica);

        return clinica.Adapt<ClinicaDTO>();
    }

    public async Task<ClinicaDTO> Create(CreateClinicaDTO createDTO)
    {
        var clinica = new Clinica(createDTO.Nome, createDTO.CNPJ);

        clinica = await _clinicaRepository.Adicionar(clinica);

        return clinica.Adapt<ClinicaDTO>();
    }

    public async Task Excluir(string id)
    {
        if (!await _clinicaRepository.EntityExiste(id))
            throw new RegistroNaoExisteException();

       await _clinicaRepository.Remover(id);
    }

    public async Task<ClinicaDTO> ObterPeloId(string id)
    {
        if (!await _clinicaRepository.EntityExiste(id))
            throw new RegistroNaoExisteException();

        var clinica = await _clinicaRepository.ObterPorId(id);

        return clinica.Adapt<ClinicaDTO>();
    }
}
