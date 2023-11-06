namespace PlayGround.Client;

public class TestClient(HttpClient httpClient)
{
	public async Task<string> GetContent()
	{
		return await httpClient.GetStringAsync("api");
	}
}