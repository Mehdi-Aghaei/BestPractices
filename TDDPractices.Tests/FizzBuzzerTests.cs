using TDDPractices.Katas;

namespace TDDPractices.Tests;
public class FizzBuzzerTests
{

	[Theory]
	[InlineData(1)]
	[InlineData(2)]
	[InlineData(8)]
	public void Buzzer_NormalNumbers_ReturnsNumber(int inputNumber)
	{
		// Arrange
		var buzzer = new FizzBuzzer();
		string expectedOutPut = inputNumber.ToString();

		// Act
		string actualOutPut = buzzer.GetValue(inputNumber);

		// Assert
		Assert.Equal(expectedOutPut, actualOutPut);
	}

	[Theory]
	[InlineData(3)]
	[InlineData(6)]
	[InlineData(9)]
	[InlineData(18)]
	public void Buzzer_WhenNumberIsMultiplesOf3_ReturnsFizz(int inputNumber)
	{
		// Arrange
		var buzzer = new FizzBuzzer();
		string expectedOutPut = "Fizz";

		// Act
		var actualOutPut = buzzer.GetValue(inputNumber);

		// Assert
		Assert.Equal(expectedOutPut, actualOutPut);
	
	}
}
