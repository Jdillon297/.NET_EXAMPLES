using CommandQuery.CQRS.Control;
using CommandQuery.CQRS.Data;
using CommandQuery.CQRS.Queries;

namespace CQRS.CQRS.Queries;

public sealed class SelectUserByIdQuery : IQuery
{
    private readonly Database database;

    public SelectUserByIdQuery(Database database)
    {
        this.database = database;
    }


    public User Execute()
    {
        var id = Controller.GetSelectedId();
        if (id <= 0)
        {
            return null;
        }
        return database.FindUserById(id);
    }
}
