namespace PlayGround.API.Models;

public class Poster
{
	public int Id { get; set; }
	public string Name { get; set; } = default!;
	public ICollection<ImageInfo>? Photos { get; set; }
	public int UserId{ get; set; }
};
