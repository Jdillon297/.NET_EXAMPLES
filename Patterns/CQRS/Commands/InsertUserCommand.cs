using CommandQuery.CQRS.Data;

namespace CommandQuery.CommandQuery.Commands;

public sealed class InsertUserCommand : ICommand
{
    private readonly Database database;
    public InsertUserCommand(Database database)
    {
        this.database = database;
    }

    public void Execute()
    {
        Console.WriteLine("\nEnter in the stuff for a new user: ");

        var userId = database.GetLastUsersId();

        Console.Write("Enter name:  ");
        var name = Console.ReadLine();
        Console.Write("Enter age:  ");
        var age = int.Parse(Console.ReadLine());



        var userToAdd = new User() { Id = ++userId, Age = age, Name = name };

        database.InsertUser(userToAdd);
    }
}
