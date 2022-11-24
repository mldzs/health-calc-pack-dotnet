using health_calc_pack_dotnet;
using health_calc_pack_dotnet.Enums;
using health_calc_pack_dotnet.Models;

namespace health_calc_test_xunit;

public class MacronutrienteTest
{
    [Fact]
    public void When_RequestMacronutrientsCalcWithValidDataForCutting_ThenReturnResult()
    {
        //Arrange
        var macronutrienteObj = new Macronutriente();
        var sexo = SexoEnum.Masculino;
        var height = 1.68;
        var weight = 85;
        var nivelAtividadeFisica = NivelAtividadeFisicaEnum.Sedentario;
        var objetivoFisico = ObjetivoFisicoEnum.Cutting;
        var expected = new MacronutrienteModel
        {
            Carboidratos = 170,
            Proteinas = 170,
            Gorduras = 85
        };

        //Act
        var result = macronutrienteObj.Calc(
            sexo,
            height,
            weight,
            nivelAtividadeFisica,
            objetivoFisico);

        //Assert
        Assert.Equal(expected.Carboidratos, result.Carboidratos);
        Assert.Equal(expected.Proteinas, result.Proteinas);
        Assert.Equal(expected.Gorduras, result.Gorduras);
    }


    [Theory]
    [InlineData(NivelAtividadeFisicaEnum.Sedentario, 340, 170, 170, SexoEnum.Masculino)]
    [InlineData(NivelAtividadeFisicaEnum.ModeradamenteAtivo, 340, 170, 170, SexoEnum.Masculino)]
    [InlineData(NivelAtividadeFisicaEnum.BastanteAtivo, 595, 170, 170, SexoEnum.Masculino)]
    [InlineData(NivelAtividadeFisicaEnum.ExtremamenteAtivo, 595, 170, 170, SexoEnum.Masculino)]
    [InlineData(NivelAtividadeFisicaEnum.BastanteAtivo, 476, 136, 136, SexoEnum.Feminino)]
    [InlineData(NivelAtividadeFisicaEnum.ExtremamenteAtivo, 476, 136, 136, SexoEnum.Feminino)]
    public void When_RequestMacronutrientsCalcWithValidDataForBuking_ThenReturnResult(
        NivelAtividadeFisicaEnum nivelAtividadeFisica,
        double carboidratos,
        double proteinas,
        double gorduras,
        SexoEnum sexo)
    {
        //Arrange
        var macronutrienteObj = new Macronutriente();
        var height = 1.68;
        var weight = 85;
        var objetivoFisico = ObjetivoFisicoEnum.Bulking;
        var expected = new MacronutrienteModel()
        {
            Carboidratos = carboidratos,
            Proteinas = proteinas,
            Gorduras = gorduras
        };

        //Act
        var result = macronutrienteObj.Calc(
            sexo,
            height,
            weight,
            nivelAtividadeFisica,
            objetivoFisico);

        //Assert
        Assert.Equal(expected.Carboidratos, result.Carboidratos);
        Assert.Equal(expected.Proteinas, result.Proteinas);
        Assert.Equal(expected.Gorduras, result.Gorduras);
    }

    [Fact]
    public void When_RequestMacronutrientsCalcWithValidDataForMaintenance_ThenReturnResult()
    {
        //Arrange
        var macronutrienteObj = new Macronutriente();
        var sexo = SexoEnum.Masculino;
        var height = 1.68;
        var weight = 85;
        var nivelAtividadeFisica = NivelAtividadeFisicaEnum.Sedentario;
        var objetivoFisico = ObjetivoFisicoEnum.Maintenance;
        var expected = new MacronutrienteModel
        {
            Carboidratos = 425,
            Proteinas = 170,
            Gorduras = 85
        };

        //Act
        var result = macronutrienteObj.Calc(
            sexo,
            height,
            weight,
            nivelAtividadeFisica,
            objetivoFisico);

        //Assert
        Assert.Equal(expected.Carboidratos, result.Carboidratos);
        Assert.Equal(expected.Proteinas, result.Proteinas);
        Assert.Equal(expected.Gorduras, result.Gorduras);
    }


    [Fact]
    public void When_RequestMacronutrientsCalcWithInValidData_ThenThrowException()
    {
        //Arrange
        var macronutrienteObj = new Macronutriente();
        var sexo = SexoEnum.Masculino;
        var height = 1.68;
        var weight = 34;
        var nivelAtividadeFisica = NivelAtividadeFisicaEnum.Sedentario;
        var objetivoFisico = ObjetivoFisicoEnum.Maintenance;

        //Act & Assert
        Assert.Throws<Exception>(() =>
        macronutrienteObj.Calc(
            sexo,
            height,
            weight,
            nivelAtividadeFisica,
            objetivoFisico));
    }
}
