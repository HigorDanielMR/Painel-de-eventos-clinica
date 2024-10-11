using Application.DTOs;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MedicoController(IMedicoService medicoService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> ObterPorId(string Id)
    {
        return Ok(await medicoService.ObterPeloId(Id));
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarMedico([FromBody] CreateMedicoDTO createMedicoDTO)
    {
        var result = await medicoService.Create(createMedicoDTO);

        return StatusCode((int)HttpStatusCode.Created, result);
    }

    [HttpPut]
    public async Task<IActionResult> AtualizarMedico([FromBody] UpdateMedicoDTO updateMedicoDTO)
    {
        var result = await medicoService.Atualizar(updateMedicoDTO);

        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> ExcluirMedico(string id)
    {
        await medicoService.Excluir(id);

        return Ok();
    }
}