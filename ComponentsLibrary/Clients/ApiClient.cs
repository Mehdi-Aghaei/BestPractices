namespace ComponentsLibrary.Clients;

public class ApiClient(IHttpClientFactory clientFactory)
{
	public async Task<string> GetContent()
	{
		using var client = clientFactory.CreateClient("Test");

		return await client.GetStringAsync("api");
	}
}
