using CommandQuery.CommandQuery.Commands;
using CommandQuery.CQRS.Commands;
using CommandQuery.CQRS.Data;
using CommandQuery.CQRS.Queries;
using CQRS.CQRS.Control;
using CQRS.CQRS.Queries;

namespace CommandQuery.CQRS.Control;

public static class Controller
{
    public static void Begin()
    {
        var database = Database.GetInstance();
        
        Prompt.ShowWelcomePrompt();

        while (true)
        {
            var input = int.Parse(Console.ReadLine());
            if (input == 1)
            {
                IQuery<User> query = new SelectAllUsersQuery(database);
                var users = query.Execute();
                ListUsersInDatabase(users);
            }
            else if (input == 2)
            {
                ICommand command = new InsertUserCommand(database);
                command.Execute();
            }
            else if (input == 3)
            {
                ICommand command = new DeleteUserByIdCommand(database);
                command.Execute();
            }
            else if (input == 4)
            {
                ICommand command  = new UpdateUserByIdCommand(database);
                command.Execute();
            }
            else if(input == 5)
            {
                IQuery query = new SelectUserByIdQuery(database);
                var user = query.Execute();
                ShowSelectedUser(user);
            }
            else if (input == 6)
            {
                break;
            }
            else
            {

            }
           Prompt.ShowPrompt();
        }
    }

    public static object MakeChoice()
    {

        Console.Write("Enter the Id of the User you wish to update: ");
        var userId = int.Parse(Console.ReadLine());

        Console.Write("Enter the new Name: ");
        var name = Console.ReadLine();
        Console.WriteLine();
        Console.Write("Enter the new Age: ");
        var age = int.Parse(Console.ReadLine()); 
        

        return new { UserId = userId, Name = name, Age = age};  
    }

    public static int GetSelectedId()
    {
        Console.Write("Enter the Id of the User you wish to Select: ");
        var userId = int.Parse(Console.ReadLine());
        return userId;
    }

    private static void ListUsersInDatabase(List<User> users)
    {
        foreach (var user in users)
        {
            Console.WriteLine($"{user.Id}, {user.Name}, {user.Age}");
        }
        Console.WriteLine("\n");
    }

    private static void ShowSelectedUser(User user)
    {
        Console.WriteLine("Selected User");
        Console.WriteLine("==============================================================");
        Console.WriteLine($"\n{user.Id}, {user.Name}, {user.Age}\n");
        Console.WriteLine("==============================================================");
    }


}
