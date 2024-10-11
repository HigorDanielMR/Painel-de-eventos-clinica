using System.Net;
using Application.DTOs;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;


[Route("api/[controller]")]
[ApiController]
public class ClinicaController(IClinicaService clinicaService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> ObterPeloId(string id)
    {
        return Ok(await clinicaService.ObterPeloId(id));
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarClinica([FromBody] CreateClinicaDTO createClinicaDTO)
    {
        var result = await clinicaService.Create(createClinicaDTO);

        return StatusCode((int)HttpStatusCode.Created, result);
    }

    [HttpPut]
    public async Task<IActionResult> AtualizarClinica([FromBody] UpdateClinicaDTO updateClinicaDTO)
    {
        var result = await clinicaService.Atualizar(updateClinicaDTO);

        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> ExcluirClinica(string id)
    {
        await clinicaService.Excluir(id);

        return Ok();
    }
}