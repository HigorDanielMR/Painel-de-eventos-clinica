using Application.DTOs;
using Application.Interface;
using Domain.Entity;
using Domain.Repository;
using Domain.Shared.Exceptions;
using Mapster;

namespace Application.Service;

public class MedicoService : IMedicoService
{
    private readonly IMedicoRepository _medicoRepository;

    public MedicoService(IMedicoRepository medicoRepository)
    {
        _medicoRepository = medicoRepository;
    }

    public async Task<Result<MedicoDTO>> Atualizar(UpdateMedicoDTO updateMedicoDTO)
    {
        if (!await _medicoRepository.EntityExiste(updateMedicoDTO.Id))
            return Result.Failure<MedicoDTO>(Error.NotFound("Medico informado não existe"));

        var medico = await _medicoRepository.ObterPorId(updateMedicoDTO.Id);

        medico.Atualizar(medico.Nome, medico.Idade, medico.Endereco, medico.Telefone);

        medico = await _medicoRepository.Atualizar(medico);

        return Result.Success(medico.Adapt<MedicoDTO>());
    }

    public async Task<Result<MedicoDTO>> Create(CreateMedicoDTO createMedicoDTO)
    {
        var medico = new Medico(createMedicoDTO.CRM, createMedicoDTO.Nome, createMedicoDTO.Idade, createMedicoDTO.Endereco, createMedicoDTO.Telefone, createMedicoDTO.CPF, createMedicoDTO.Genero);

        medico = await _medicoRepository.Adicionar(medico);

        return Result.Success(medico.Adapt<MedicoDTO>());
    }

    public async Task<Result> Excluir(string id)
    {
        if (!await _medicoRepository.EntityExiste(id))
            throw new RegistroNaoExisteException();

        await _medicoRepository.Remover(id);

        return Result.Success();
    }

    public async Task<Result<MedicoDTO>> ObterPeloId(string id)
    {
        if (!await _medicoRepository.EntityExiste(id))
            return Result.Failure<MedicoDTO>(Error.NotFound("Medico informado não existe."));

        var medico = await _medicoRepository.ObterPorId(id);

        return Result.Success(medico.Adapt<MedicoDTO>());
    }
}