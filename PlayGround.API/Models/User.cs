using System.Text.Json.Serialization;


namespace PlayGround.API.Models;
public class AppUser
{
	public int Id { get; set; }
	public string Name { get; set; } = default!;
	public int Age { get; set; }
	[JsonIgnore]
	public ICollection<Poster> Posters { get; set; } = default!;
}
