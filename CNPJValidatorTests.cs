using CNPJ;
using Xunit;

public class CNPJValidatorTests
{
    private readonly CNPJValidator _validator;

    public CNPJValidatorTests()
    {
        _validator = new CNPJValidator();
    }

    [Theory]
    [InlineData("11222333000181")] // CNPJ válido com somente dígitos 
    [InlineData("A1B2C3D4E5F600")] // CNPJ válido com letras 
    public void ValidarCNPJ_ValidCNPJs_ReturnsTrue(string cnpj)
    {
        bool result = _validator.ValidarCNPJ(cnpj);
        Assert.True(result);
    }

    [Theory]
    [InlineData("11222333000182")] // CNPJ inválido com somente dígitos 
    [InlineData("A1B2C3D4E5F6G7H8I1K")] // CNPJ inválido com letras 
    [InlineData("1122233300018")] // CNPJ com comprimento inválido 
    [InlineData("A1B2C3D4E5F6G7H8")] // CNPJ com comprimento inválido e letras 
    public void ValidarCNPJ_InvalidCNPJs_ReturnsFalse(string cnpj)
    {
        bool result = _validator.ValidarCNPJ(cnpj);
        Assert.False(result);
    }
}