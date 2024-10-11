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

    public async Task<MedicoDTO> Atualizar(UpdateMedicoDTO updateMedicoDTO)
    {
        if (!await _medicoRepository.EntityExiste(updateMedicoDTO.Id))
            throw new RegistroNaoExisteException();

        var medico = await _medicoRepository.ObterPorId(updateMedicoDTO.Id);

        medico.Atualizar(medico.Nome, medico.Idade, medico.Endereco, medico.Telefone);

        medico = await _medicoRepository.Atualizar(medico);

        return medico.Adapt<MedicoDTO>();
    }

    public async Task<MedicoDTO> Create(CreateMedicoDTO createMedicoDTO)
    {
        var medico = new Medico(createMedicoDTO.CRM, createMedicoDTO.Nome, createMedicoDTO.Idade, createMedicoDTO.Endereco, createMedicoDTO.Telefone, createMedicoDTO.CPF, createMedicoDTO.Genero);

        medico = await _medicoRepository.Adicionar(medico);

        return medico.Adapt<MedicoDTO>();
    }

    public async Task Excluir(string id)
    {
        if (!await _medicoRepository.EntityExiste(id))
            throw new RegistroNaoExisteException();

        await _medicoRepository.Remover(id);
    }

    public async Task<MedicoDTO> ObterPeloId(string id)
    {
        if (!await _medicoRepository.EntityExiste(id))
            throw new RegistroNaoExisteException();

        var medico = await _medicoRepository.ObterPorId(id);

        return medico.Adapt<MedicoDTO>();
    }
}