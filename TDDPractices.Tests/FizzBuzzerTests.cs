using TDDPractices.Katas;

namespace TDDPractices.Tests;
public class FizzBuzzerTests
{
	private readonly FizzBuzzer _fizzBuzzer;

    public FizzBuzzerTests()
    {
		_fizzBuzzer = new FizzBuzzer();
	}

    [Theory]
	[InlineData(1)]
	[InlineData(2)]
	[InlineData(8)]
	public void Buzzer_NormalNumbers_ReturnsNumber(int inputNumber)
	{
		// Arrange
		string expectedOutPut = inputNumber.ToString();

		// Act
		string actualOutPut = _fizzBuzzer.GetValue(inputNumber);

		// Assert
		actualOutPut.Should().Be(expectedOutPut);
	}

	[Theory]
	[InlineData(3)]
	[InlineData(6)]
	[InlineData(9)]
	[InlineData(18)]
	public void Buzzer_WhenNumberIsMultiplesOf3_ReturnsFizz(int inputNumber)
	{
		// Arrange
		string expectedOutPut = "Fizz";

		// Act
		var actualOutPut = _fizzBuzzer.GetValue(inputNumber);

		// Assert
		actualOutPut.Should().Be(expectedOutPut);
	}

	[Theory]
	[InlineData(5)]
	[InlineData(10)]
	[InlineData(20)]
	[InlineData(100)]
	public void Buzzer_WhenNumberIsMultiplesOf5_ReturnsFizz(int inputNumber)
	{
		// Arrange
		string expectedOutPut = "Buzz";

		// Act
		var actualOutPut = _fizzBuzzer.GetValue(inputNumber);

		// Assert
		actualOutPut.Should().Be(expectedOutPut);
	}

	[Theory]
	[InlineData(15)]
	[InlineData(30)]
	[InlineData(45)]
	[InlineData(75)]
	public void Buzzer_WhenNumberIsDiv5AndDiv3_ReturnsFizz(int inputNumber)
	{
		// Arrange
		string expectedOutPut = "FizzBuzz";

		// Act
		var actualOutPut = _fizzBuzzer.GetValue(inputNumber);

		// Assert
		actualOutPut.Should().Be(expectedOutPut);
	}
}
