using health_calc_pack_dotnet;

Console.Write("Altura: ");
var height = Console.ReadLine();

Console.Write("Peso: ");
var weight = Console.ReadLine();

Console.Write("Sexo: ");
var sexo = Console.ReadLine();

IMC imc = new IMC();
double result = imc.Calc(double.Parse(height), double.Parse(weight));
string category = imc.GetIMCCategory(result);

Console.WriteLine("IMC: " + category);

var SexoEnum = (sexo == "F") ? health_calc_pack_dotnet.Enums.SexoEnum.Feminino : health_calc_pack_dotnet.Enums.SexoEnum.Masculino;

Macronutriente macro = new Macronutriente();
var ResultMacronutrientes = macro.Calc(SexoEnum,
    double.Parse(height),
    double.Parse(weight),
    health_calc_pack_dotnet.Enums.NivelAtividadeFisicaEnum.BastanteAtivo,
    health_calc_pack_dotnet.Enums.ObjetivoFisicoEnum.Bulking);

Console.WriteLine($"O seu consumo de macronutrientes deve ser => " +
                  $"Carboidratos: {ResultMacronutrientes.Carboidratos} gramas, " +
                  $"Proteinas: {ResultMacronutrientes.Proteinas} gramas, " +
                  $"Gorduras: {ResultMacronutrientes.Gorduras} gramas");

Console.ReadKey();
