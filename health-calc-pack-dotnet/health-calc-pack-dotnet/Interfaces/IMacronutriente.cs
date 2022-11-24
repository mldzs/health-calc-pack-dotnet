using health_calc_pack_dotnet.Enums;
using health_calc_pack_dotnet.Models;

namespace health_calc_pack_dotnet.Interfaces;

public interface IMacronutriente
{
    MacronutrienteModel Calc(
        SexoEnum sexo,
        double height,
        double weight,
        NivelAtividadeFisicaEnum nivelAtividadeFisica,
        ObjetivoFisicoEnum objetivoFisico);

    bool IsValidData(double weight);
}
