using CommandQuery.CQRS.Data;

namespace CommandQuery.CommandQuery.Commands;

public sealed class DeleteUserByIdCommand :ICommand
{
    private readonly Database database;
    public DeleteUserByIdCommand(Database database)
    {
        this.database = database;
    }


    public void Execute()
    {
        Console.WriteLine("Enter Id of a user you wish to delete: ");
        var id = int.Parse(Console.ReadLine());

        var userToDelete = this.database.FindUserById(id);
        this.database.DeleteUser(userToDelete); 
    }
}
