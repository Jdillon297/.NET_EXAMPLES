using CommandQuery.CQRS.Data;

namespace CommandQuery.CQRS.Queries;

public sealed class SelectAllUsersQuery: IQuery<User>
{
    private readonly Database database;

    public SelectAllUsersQuery(Database database)
    {
        this.database = database;
    }

    public List<User> Execute()
    {
          return this.database.users.ToList();
    }
}
