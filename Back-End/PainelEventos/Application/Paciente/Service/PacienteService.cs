using Application.DTOs;
using Application.Interface;
using Domain.Entity;
using Domain.Interface;
using Domain.Shared.Exceptions;
using Mapster;

namespace Application.Service;

public class PacienteService : IPacienteService
{
    private readonly IPacienteRepository _pacienteRepository;

    public PacienteService(IPacienteRepository pacienteRepository)
    {
        _pacienteRepository = pacienteRepository;
    }

    public async Task<Result<PacienteDTO>> Atualizar(UpdatePacienteDTO updatePacienteDTO)
    {
        if (!await _pacienteRepository.EntityExiste(updatePacienteDTO.Id))
            return Result.Failure<PacienteDTO>(Error.NotFound("Paciente informado não existe"));

        var paciente = await _pacienteRepository.ObterPorId(updatePacienteDTO.Id);

        paciente.Atualizar(paciente.Nome, paciente.Idade, paciente.Genero);

        paciente = await _pacienteRepository.Atualizar(paciente);

        return Result.Success(paciente.Adapt<PacienteDTO>());
    }

    public async Task<Result<PacienteDTO>> Create(CreatePacienteDTO createPacienteDTO)
    {
        var paciente = new Paciente(createPacienteDTO.NumeroCartaoSUS, createPacienteDTO.Nome, createPacienteDTO.Idade, createPacienteDTO.Endereco, createPacienteDTO.Telefone, createPacienteDTO.CPF, createPacienteDTO.Genero);

        paciente = await _pacienteRepository.Adicionar(paciente);

        return Result.Success(paciente.Adapt<PacienteDTO>());
    }

    public async Task<Result> Excluir(string id)
    {
        if (!await _pacienteRepository.EntityExiste(id))
            return Result.Failure(Error.NotFound("Paciene informado não existe."));

        await _pacienteRepository.Remover(id);

        return Result.Success();
    }

    public async Task<Result<PacienteDTO>> ObterPeloId(string id)
    {
        if (!await _pacienteRepository.EntityExiste(id))
            return Result.Failure<PacienteDTO>(Error.NotFound("Paciente informado não existe."));

        var paciente = await _pacienteRepository.ObterPorId(id);

        return Result.Success(paciente.Adapt<PacienteDTO>());
    }
}