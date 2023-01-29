namespace TDDPractices.Katas;
public class FizzBuzzer
{
    public string GetValue(int input)
    {
        string outPut = string.Empty;

		if (input % 3 is 0)
        {
            outPut += "Fizz";
        }
		if (input % 5 is 0)
        {
            outPut += "Buzz";
        }
        if(string.IsNullOrEmpty(outPut))
        {
            outPut = input.ToString();
        }

		return outPut;
    }
}