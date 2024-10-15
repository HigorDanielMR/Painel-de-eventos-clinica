using Application.DTOs;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MedicoController(IMedicoService medicoService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> ObterPorId(string Id)
    {
        var result = await medicoService.ObterPeloId(Id);

        return result.MapResult();
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarMedico([FromBody] CreateMedicoDTO createMedicoDTO)
    {
        var result = await medicoService.Create(createMedicoDTO);

        return result.MapCreatedResult();
    }

    [HttpPut]
    public async Task<IActionResult> AtualizarMedico([FromBody] UpdateMedicoDTO updateMedicoDTO)
    {
        var result = await medicoService.Atualizar(updateMedicoDTO);

        return result.MapResult();
    }

    [HttpDelete]
    public async Task<IActionResult> ExcluirMedico(string id)
    {
        var result = await medicoService.Excluir(id);

        return result.MapResult();
    }
}