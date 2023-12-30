namespace PlayGround.Client;

public class TestService : ITestService
{
    private readonly HttpClient _httpClient;

    public TestService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetContent()
	{
		return await _httpClient.GetStringAsync("api");
	}
}

public interface ITestService
{
    Task<string> GetContent();
}