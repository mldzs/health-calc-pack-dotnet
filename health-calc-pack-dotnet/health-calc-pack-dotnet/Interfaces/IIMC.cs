namespace health_calc_pack_dotnet.Interfaces;

public interface IIMC
{
    double Calc(double height, double weight);

    string GetIMCCategory(double imc);

    bool IsValidData(double height, double weight);
}
