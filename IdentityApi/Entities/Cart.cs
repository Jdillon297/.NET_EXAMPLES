namespace IdentityApi.Entities;

public class Cart
{
    public int Id { get; set; }

    public decimal? Price { get; set; }

    public List<Book>? Books { get; set; } = new List<Book>();

    public User? User { get; set; }

    public int? UserId { get; set; }
}
