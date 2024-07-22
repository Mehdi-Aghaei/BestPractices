using TDDPractices.Katas;

#region FizzBuzzer evaluator

if (ClassListGenerator.ClassNames.Names is not null)
{
	foreach (var item in ClassListGenerator.ClassNames.Names)
	{
		Console.WriteLine(item);
	}

}
var fizzBuzzer = new FizzBuzzer();

for (int i = 0; i < 100; i++)
{
    Console.WriteLine( fizzBuzzer.GetValue(i));
}
#endregion