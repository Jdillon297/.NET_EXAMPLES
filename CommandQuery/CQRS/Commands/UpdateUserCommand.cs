using CommandQuery.CQRS.Data;
using CommandQuery.CommandQuery.Commands;
namespace CommandQuery.CQRS.Commands;

public sealed class UpdateUserByIdCommand: ICommand
{
    private readonly Database database;

    public UpdateUserByIdCommand(Database database)
    {
        this.database = database;
    }

    public void Execute()
    {
        var creds = Control.Controller.MakeChoice();

        var userIdProperty = creds.GetType().GetProperty("UserId");
        var nameProperty =  creds.GetType().GetProperty("Name");
        var ageProperty = creds.GetType().GetProperty("Age");
     

        if(userIdProperty != null && nameProperty != null && ageProperty != null)
        {
            var userId = (int)userIdProperty.GetValue(creds);
            var name = (string) nameProperty.GetValue(creds);
            var age = (int) ageProperty.GetValue(creds);
            this.database.UpdateUserById(userId, name, age);
        }
        

    }
}
