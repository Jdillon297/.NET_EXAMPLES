namespace IdentityApi.Entities;

public class CartBook
{
    public Cart? Cart { get; set; }
    public int CartId { get; set; }

    public Book? Book { get; set; }
    public int BookId { get; set; }

}
