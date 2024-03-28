namespace IdentityApi.Entities;

public class Cart
{
    public int Id { get; set; }

    public decimal? Price { get; set; }

    public ICollection<CartBook?> CartBooks { get; set; } = new List<CartBook?>();  

    public User? User { get; set; }

    public int? UserId { get; set; }
}
