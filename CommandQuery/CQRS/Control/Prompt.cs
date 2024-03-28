namespace CQRS.CQRS.Control;

public static class Prompt
{

    public static void ShowWelcomePrompt()
    {
        Console.WriteLine("Welcome to the program this is an example of the CQRS pattern using a console app");
        Console.WriteLine("1: Select * from Users");
        Console.WriteLine("2: Insert A User into Database Command");
        Console.WriteLine("3: Delete A User from Database Command");
        Console.WriteLine("4: Update A User Based on Id");
        Console.WriteLine("5: Select User By Id");
        Console.WriteLine("6: Exit Progam ");
        Console.Write("Enter a choice for your path: ");
    }
    public static void ShowPrompt()
    {
        Console.WriteLine("1: Select * from Users");
        Console.WriteLine("2: Insert A User into Database Command");
        Console.WriteLine("3: Delete A User from Database Command");
        Console.WriteLine("4: Update A User Based on Id");
        Console.WriteLine("5: Select User By Id");
        Console.WriteLine("6: Exit Progam ");
        Console.Write("Enter a choice for your path: ");
    }
}
