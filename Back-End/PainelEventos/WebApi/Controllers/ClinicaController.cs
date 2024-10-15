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
        var result = await clinicaService.ObterPeloId(id);

        return result.MapResult();
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarClinica([FromBody] CreateClinicaDTO createClinicaDTO)
    {
        var result = await clinicaService.Create(createClinicaDTO);

        return result.MapCreatedResult();
    }

    [HttpPut]
    public async Task<IActionResult> AtualizarClinica([FromBody] UpdateClinicaDTO updateClinicaDTO)
    {
        var result = await clinicaService.Atualizar(updateClinicaDTO);

        return result.MapResult();
    }

    [HttpDelete]
    public async Task<IActionResult> ExcluirClinica(string id)
    {
        var result = await clinicaService.Excluir(id);

        return result.MapResult();
    }
}