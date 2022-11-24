using System.ComponentModel.DataAnnotations;
using health_calc_api_dotnet.Responses;
using Microsoft.AspNetCore.Mvc;
using health_calc_pack_dotnet;
using health_calc_pack_dotnet.Enums;

namespace health_calc_api_dotnet.Controllers;

[ApiController]
[Route("[controller]")]
public class HealthCalcController : ControllerBase
{
    private readonly ILogger<HealthCalcController> _logger;

    public HealthCalcController(ILogger<HealthCalcController> logger)
    {
        _logger = logger;
    }

    [HttpGet("IMCCategory")]
    public string GetIMCCategory([FromQuery][Required] double altura, [FromQuery][Required] double peso)
    { 
        IMC imc = new IMC();
        double result = imc.Calc(altura, peso);
        return imc.GetIMCCategory(result);
    }

    [HttpGet("Macros")]
    public MacronutrienteResponse GetMacros([FromQuery][Required] double altura, [FromQuery][Required] double peso, [FromQuery][Required] string sexo)
    {
        var macro = new Macronutriente();
        var sexoEnm = (sexo == "F") ? SexoEnum.Feminino : SexoEnum.Masculino;

        var result = macro.Calc(sexoEnm,
            altura,
            peso,
            NivelAtividadeFisicaEnum.BastanteAtivo,
            ObjetivoFisicoEnum.Bulking);

        return new MacronutrienteResponse
        {
            Carboidratos=result.Carboidratos,
            Proteinas=result.Proteinas,
            Gorduras=result.Gorduras
        };
    }
}