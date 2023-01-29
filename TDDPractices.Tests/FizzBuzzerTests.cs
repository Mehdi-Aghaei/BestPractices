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

		// Act
		string expectedNumber = buzzer.GetValue(inputNumber);

		// Assert
		Assert.Equal(expectedNumber, inputNumber.ToString());
	}
}
