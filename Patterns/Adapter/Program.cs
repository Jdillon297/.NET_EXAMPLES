using Patterns.Adapter;

public class Program
{
    public static void Main(string[] args)
    {

        var cruiseBoat = new CruiseBoat();
        var rowBoat = new RowBoat();
        var sailBoat = new SailBoat();

        new Adapter(cruiseBoat).Action();
        new Adapter(rowBoat).Action();
        new Adapter(sailBoat).Action();
        
        Console.WriteLine("\nhello world this is an example of the adapter pattern");
    }
}
