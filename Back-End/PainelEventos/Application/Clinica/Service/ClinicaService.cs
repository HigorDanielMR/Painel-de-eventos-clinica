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

    public async Task<Result<ClinicaDTO>> Atualizar(UpdateClinicaDTO updateClinicaDTO)
    {
        if (!await _clinicaRepository.EntityExiste(updateClinicaDTO.Id))
            return Result.Failure<ClinicaDTO>(Error.NotFound("Clinica informada não existe"));

        var clinica = await _clinicaRepository.ObterPorId(updateClinicaDTO.Id);

        clinica.Atualizar(updateClinicaDTO.Nome);

        clinica = await _clinicaRepository.Atualizar(clinica);

        return Result.Success(clinica.Adapt<ClinicaDTO>());
    }

    public async Task<Result<ClinicaDTO>> Create(CreateClinicaDTO createDTO)
    {
        var clinica = new Clinica(createDTO.Nome, createDTO.CNPJ);

        clinica = await _clinicaRepository.Adicionar(clinica);

        return Result.Success(clinica.Adapt<ClinicaDTO>());
    }

    public async Task<Result> Excluir(string id)
    {
        if (!await _clinicaRepository.EntityExiste(id))
            return Result.Failure(Error.NotFound("Clinica informada não existe"));

        await _clinicaRepository.Remover(id);

        return Result.Success();
    }

    public async Task<Result<ClinicaDTO>> ObterPeloId(string id)
    {
        if (!await _clinicaRepository.EntityExiste(id))
            return Result.Failure<ClinicaDTO>(Error.NotFound("Clinica informada não existe"));

        Clinica? clinica = await _clinicaRepository.ObterPorId(id);

        return Result.Success(clinica.Adapt<ClinicaDTO>());
    }
}
