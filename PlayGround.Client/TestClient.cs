using System.Net;
using PlayGround.Shared;

namespace PlayGround.Client;

public class TestClient : IClient
{
	private readonly HttpClient client;

	public TestClient(HttpClient client)
	{
		this.client = client;
		this.client.BaseAddress = new Uri("https://localhost:7024/");
	}

	public async Task<(HttpStatusCode, string?)> GetAsync()
	{
		// This is a hack from hell to avoid having to know if this is running server or client side
		if (client.BaseAddress is null)
		{
			return (HttpStatusCode.OK, "ggg");
		}
		int a = 1;
		var response = await client.GetAsync($"api?id={a+=1}");
		var statusCode = response.StatusCode;

		string todos = null;
		if (response.IsSuccessStatusCode)
		{
			todos = await response.Content.ReadAsStringAsync();
		}

		return (statusCode, todos);
	}
}
