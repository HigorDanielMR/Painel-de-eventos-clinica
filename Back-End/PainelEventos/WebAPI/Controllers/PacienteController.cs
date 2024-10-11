using Application.DTOs;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PacienteController(IPacienteService pacienteService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> ObterPeloId(string id)
    {
        return Ok(await pacienteService.ObterPeloId(id));
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarPaciente([FromBody] CreatePacienteDTO createPacienteDTO)
    {
        var result = await pacienteService.Create(createPacienteDTO);

        return StatusCode((int)HttpStatusCode.Created, result);
    }

    [HttpPut]
    public async Task<IActionResult> AtualizarPaciente([FromBody] UpdatePacienteDTO updatePacienteDTO)
    {
        var result = await pacienteService.Atualizar(updatePacienteDTO);

        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> ExcluirClinica(string id)
    {
        await pacienteService.Excluir(id);

        return Ok();
    }
}