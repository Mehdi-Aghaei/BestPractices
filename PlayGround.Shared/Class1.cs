using System.Net;

namespace PlayGround.Shared;

public interface IClient
{
	Task<(HttpStatusCode, string)> GetAsync();
}