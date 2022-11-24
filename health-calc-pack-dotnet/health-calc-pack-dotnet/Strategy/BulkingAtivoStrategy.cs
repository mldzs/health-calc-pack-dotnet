using health_calc_pack_dotnet.Enums;
using health_calc_pack_dotnet.Interfaces;
using health_calc_pack_dotnet.Models;
using health_calc_pack_dotnet.Strategy.Base;

namespace health_calc_pack_dotnet.Strategy;

public class BulkingAtivoStrategy : MacronutrienteBase, IMacronutrienteStrategy
{
    const double PROTEINA = 2;
    const double GORDURA = 2;
    const double CARBOIDRADO = 7;

    public BulkingAtivoStrategy(SexoEnum sexo) : base(sexo)
    {
    }

    public MacronutrienteModel Calc(double weight)
    {
        return new MacronutrienteModel
        {
            Proteinas = PROTEINA * weight * GENDER_MULTIPLIER,
            Carboidratos = CARBOIDRADO * weight * GENDER_MULTIPLIER,
            Gorduras = GORDURA * weight * GENDER_MULTIPLIER,
        };
    }
}
