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

    public async Task<PacienteDTO> Atualizar(UpdatePacienteDTO updatePacienteDTO)
    {
        if (!await _pacienteRepository.EntityExiste(updatePacienteDTO.Id))
            throw new RegistroNaoExisteException();

        var paciente = await _pacienteRepository.ObterPorId(updatePacienteDTO.Id);

        paciente.Atualizar(paciente.Nome, paciente.Idade, paciente.Genero);

        paciente = await _pacienteRepository.Atualizar(paciente);

        return paciente.Adapt<PacienteDTO>();
    }

    public async Task<PacienteDTO> Create(CreatePacienteDTO createPacienteDTO)
    {
        var paciente = new Paciente(createPacienteDTO.NumeroCartaoSUS, createPacienteDTO.Nome, createPacienteDTO.Idade, createPacienteDTO.Endereco, createPacienteDTO.Telefone, createPacienteDTO.CPF, createPacienteDTO.Genero);

        paciente = await _pacienteRepository.Adicionar(paciente);

        return paciente.Adapt<PacienteDTO>();
    }

    public async Task Excluir(string id)
    {
        if(!await _pacienteRepository.EntityExiste(id))
            throw new RegistroNaoExisteException();

        await _pacienteRepository.Remover(id);
    }

    public async Task<PacienteDTO> ObterPeloId(string id)
    {
        if (!await _pacienteRepository.EntityExiste(id))
            throw new RegistroNaoExisteException();

        var paciente = await _pacienteRepository.ObterPorId(id);

        return paciente.Adapt<PacienteDTO>();
    }
}