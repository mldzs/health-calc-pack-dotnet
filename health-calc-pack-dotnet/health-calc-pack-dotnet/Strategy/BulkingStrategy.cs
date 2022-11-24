using health_calc_pack_dotnet.Interfaces;
using health_calc_pack_dotnet.Models;

namespace health_calc_pack_dotnet.Strategy;

public class BulkingStrategy : IMacronutrienteStrategy
{
    const double PROTEINA = 2;
    const double GORDURA = 2;
    const double CARBOIDRADO = 4;

    public MacronutrienteModel Calc(double weight)
    {
        return new MacronutrienteModel
        {
            Proteinas = PROTEINA * weight,
            Carboidratos = CARBOIDRADO * weight,
            Gorduras = GORDURA * weight,
        };
    }
}
