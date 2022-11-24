using health_calc_pack_dotnet;

namespace health_calc_test_xunit;

public class IMCTest
{
    [Fact]
    public void When_RequestIMCCalcWithValidData_ThenReturnIMCIndex()
    {
        //Arrange
        var imc = new IMC();
        var height = 1.68;
        var weight = 85;
        var expected = 30.12;

        //Act
        var result = imc.Calc(height, weight);

        //Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void When_RequestIMCCalcWithValidData_ThenReturnIMCIndexWithRangeAssert()
    {
        //Arrange
        var imc = new IMC();
        var height = 1.68;
        var weight = 85;
        var expectedMin = 30.10;
        var expectedMax = 30.14;

        //Act
        var result = imc.Calc(height, weight);

        //Assert
        Assert.InRange(result, expectedMin, expectedMax);
    }

    [Fact]
    public void When_RequestIMCCalcWithInValidAllData_ThenThrowException()
    {
        //Arrange
        var imc = new IMC();
        var height = 0.0;
        var weight = 0.0;

        //Act & Assert
        Assert.Throws<Exception>(() => imc.Calc(height, weight));
    }

    [Fact]
    public void When_RequestIMCCalcWithInvalidHeigthData_ThenThrowException()
    {
        //Arrange
        var imc = new IMC();
        var height = 0.0;
        var weight = 85.0;

        //Act & Assert
        Assert.Throws<Exception>(() => imc.Calc(height, weight));
    }

    [Theory]
    [InlineData(17.5, "Abaixo do peso")]
    [InlineData(18.49, "Abaixo do peso")]
    [InlineData(18.50, "Peso Normal")]
    [InlineData(24.99, "Peso Normal")]
    [InlineData(25, "Pré-Obesidade")]
    [InlineData(29.99, "Pré-Obesidade")]
    [InlineData(30, "Obesidade Grau 1")]
    [InlineData(34.99, "Obesidade Grau 1")]
    [InlineData(35, "Obesidade Grau 2")]
    [InlineData(39.99, "Obesidade Grau 2")]
    [InlineData(40, "Obesidade Grau 3")]
    [InlineData(45, "Obesidade Grau 3")]
    public void When_RequestIMCCategory_ThenReturnCategory(double valueIMC, string expectedResult)
    {
        //Arrange
        var imc = new IMC();

        //Act
        var result = imc.GetIMCCategory(valueIMC);

        //Assert
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(0, 1.68)]
    [InlineData(85, 0)]
    [InlineData(0, 0)]
    public void When_InvalidDate_ThenReturnValidationResultFalse(double height, double weight)
    {
        //Arrange
        var imc = new IMC();
        var _height = height;
        var _weight = weight;

        //Act
        var result = imc.IsValidData(_height, _weight);

        //Assert
        Assert.False(result);
    }
}
