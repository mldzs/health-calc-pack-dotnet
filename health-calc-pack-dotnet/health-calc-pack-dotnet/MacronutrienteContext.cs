using health_calc_pack_dotnet.Interfaces;
using health_calc_pack_dotnet.Models;

namespace health_calc_pack_dotnet;

public class MacronutrienteContext
{
    private IMacronutrienteStrategy _macronutrienteStrategy;

    public MacronutrienteContext(IMacronutrienteStrategy strategy)
    {
        _macronutrienteStrategy = strategy;
    }
    public void SetStrategy(IMacronutrienteStrategy strategy)
    {
        _macronutrienteStrategy = strategy;
    }

    public MacronutrienteModel Execute(double weight)
    {
        return _macronutrienteStrategy.Calc(weight);
    }
}
