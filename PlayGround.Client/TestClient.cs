namespace PlayGround.Client;

public sealed class TestClient
{
	private readonly HttpClient httpClient;

	public TestClient(HttpClient httpClient)
	{
		this.httpClient = httpClient;
	}

	public async Task<string> GetContent()
	{
		var result = await this.httpClient.GetStringAsync("/api");

		return result;
	}
}
