namespace Patterns.Adapter;

public class CruiseBoat : IBoat
{
    public void Action()
    {
        Console.WriteLine("Cruise Ship cruising");
    }
}

public class RowBoat : IBoat
{
    public void Action()
    {
        Console.WriteLine("This is a row boat rowing dude.");
    }
}


public class SailBoat : IBoat
{
    public void Action()
    {
        Console.WriteLine("Sail Boat Sailing ");
    }
}
