namespace Patterns.Adapter;

public class Adapter:  IBoat
{
    private readonly IBoat adaptee;

    public Adapter(IBoat adaptee)
    {
        this.adaptee = adaptee;
    }

    public void Action()
    {
        this.adaptee.Action();
    }
}
