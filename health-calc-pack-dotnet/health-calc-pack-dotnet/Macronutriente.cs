using health_calc_pack_dotnet.Enums;
using health_calc_pack_dotnet.Interfaces;
using health_calc_pack_dotnet.Models;
using health_calc_pack_dotnet.Strategy;

namespace health_calc_pack_dotnet;

public class Macronutriente : IMacronutriente
{
    const int MIN_WEIGHT = 35;

    public MacronutrienteModel Calc(
        SexoEnum sexo,
        double height,
        double weight,
        NivelAtividadeFisicaEnum nivelAtividadeFisica,
        ObjetivoFisicoEnum objetivoFisico)
    {
        if (!IsValidData(weight))
            throw new Exception("Parametros inválidos!");

        IMacronutrienteStrategy macronutrienteStrategy = new CuttingStrategy();

        if (objetivoFisico == ObjetivoFisicoEnum.Cutting)
            macronutrienteStrategy = new CuttingStrategy();
        else if (objetivoFisico == ObjetivoFisicoEnum.Bulking)
        {
            if (nivelAtividadeFisica == NivelAtividadeFisicaEnum.BastanteAtivo ||
                nivelAtividadeFisica == NivelAtividadeFisicaEnum.ExtremamenteAtivo)
                macronutrienteStrategy = new BulkingAtivoStrategy(sexo);
            else
                macronutrienteStrategy = new BulkingStrategy();
        }
        else if (objetivoFisico == ObjetivoFisicoEnum.Maintenance)
            macronutrienteStrategy = new MaintenanceStrategy();
        
        var context = new MacronutrienteContext(macronutrienteStrategy);

        return context.Execute(weight);
    }
    public bool IsValidData(double weight)
    {
        if (weight <= MIN_WEIGHT)
            return false;
        return true;
    }
}
