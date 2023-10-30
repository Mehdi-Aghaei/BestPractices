namespace PlayGround.Client;

public class TestClient(HttpClient httpClient)
{
	public async Task<string> GetContent()
	{
		var result = await httpClient.GetAsync("api");

		return result!.Content!.ToString();
	}
}
