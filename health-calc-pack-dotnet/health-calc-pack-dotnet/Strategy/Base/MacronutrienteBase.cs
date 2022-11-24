using health_calc_pack_dotnet.Enums;
using health_calc_pack_dotnet.Utils;

namespace health_calc_pack_dotnet.Strategy.Base;

public abstract class MacronutrienteBase
{
    public double GENDER_MULTIPLIER;

    public MacronutrienteBase(SexoEnum sexo)
    {
        GENDER_MULTIPLIER = (sexo == SexoEnum.Feminino) ? Constants.MultiplicadorFeminino : Constants.MultiplicadorMasculino;
    }
}
