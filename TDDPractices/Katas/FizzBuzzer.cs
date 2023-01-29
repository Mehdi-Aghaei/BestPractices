namespace TDDPractices.Katas;
public class FizzBuzzer
{
    public string GetValue(int input)
    {
        if(input % 3 is 0)
        {
            return "Fizz";
        }
		if (input % 5 is 0)
        {
            return "Buzz";
        }

			return input.ToString();
    }
}
