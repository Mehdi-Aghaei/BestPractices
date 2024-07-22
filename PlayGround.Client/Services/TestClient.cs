namespace PlayGround.Client.Services
{
	public class TestClient : ITestClient
	{
		private readonly HttpClient _httpClient;

		public TestClient(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<string> GetContent()
		{
			return await _httpClient.GetStringAsync("api");
		}
	}
}
