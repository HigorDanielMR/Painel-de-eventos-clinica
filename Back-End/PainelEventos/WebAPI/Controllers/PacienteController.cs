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
        var result = await pacienteService.ObterPeloId(id);
        return result.MapResult();
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarPaciente([FromBody] CreatePacienteDTO createPacienteDTO)
    {
        var result = await pacienteService.Create(createPacienteDTO);

        return result.MapCreatedResult();
    }

    [HttpPut]
    public async Task<IActionResult> AtualizarPaciente([FromBody] UpdatePacienteDTO updatePacienteDTO)
    {
        var result = await pacienteService.Atualizar(updatePacienteDTO);

        return result.MapResult();
    }

    [HttpDelete]
    public async Task<IActionResult> ExcluirClinica(string id)
    {
        var result = await pacienteService.Excluir(id);

        return result.MapResult();
    }
}