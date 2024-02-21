namespace IdentityApi.Entities;

public class Book
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }
    public string Author { get; set; }

    public decimal Price { get; set; }

    public Cart? Cart { get; set; }

    public int? CartId { get; set; }
}
