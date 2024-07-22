using TDDPractices.Katas;

#region FizzBuzzer evaluator

var fizzBuzzer = new FizzBuzzer();

for (int i = 0; i < 100; i++)
{
	Console.WriteLine(fizzBuzzer.GetValue(i));
}
#endregion