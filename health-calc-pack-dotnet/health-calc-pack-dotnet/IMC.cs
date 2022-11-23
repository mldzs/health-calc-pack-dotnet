using health_calc_pack_dotnet.Interfaces;

namespace health_calc_pack_dotnet;

public class IMC : IIMC
{
    public double Calc(double height, double weight)
    {
        {
            if (!IsValidData(height, weight))
                throw new Exception("Parametros inválidos!");

            return Math.Round(weight / Math.Pow(height, 2), 2);
        }
    }

    public string GetIMCCategory(double imc)
    {
        var result = string.Empty;

        if (imc < 18.5)
            result = "Abaixo do peso";
        else if (imc >= 18.5 && imc < 25)
            result = "Peso Normal";
        else if (imc >= 25 && imc < 30)
            result = "Pré-Obesidade";
        else if (imc >= 30 && imc < 35)
            result = "Obesidade Grau 1";
        else if (imc >= 35 && imc < 40)
            result = "Obesidade Grau 2";
        else if (imc >= 40)
            result = "Obesidade Grau 3";

        return result;
    }

    public bool IsValidData(double height, double weight)
    {
        if (height <= 0 || weight <= 0)
            return false;
        return true;
    }
}
