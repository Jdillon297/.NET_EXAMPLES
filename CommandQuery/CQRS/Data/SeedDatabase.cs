namespace CommandQuery.CQRS.Data;

public static class SeedDatabase
{
    public static List<User> Seed()
    {
        var seedUsers = new List<User>();

        var i = 1;

        seedUsers.Add(new User() { Id = i, Name = "John Hancock", Age = 29 });
        seedUsers.Add(new User() { Id = ++i, Name = "James Hancock", Age = 39 });
        seedUsers.Add(new User() { Id = ++i, Name = "Paul Mason", Age = 49 });
        seedUsers.Add(new User() { Id = ++i, Name = "Lucas Tator", Age = 20 });
        seedUsers.Add(new User() { Id = ++i, Name = "Logan Manser", Age = 19 });
        seedUsers.Add(new User() { Id = ++i, Name = "Hanzel Racher", Age = 10 });

        return seedUsers;
    }
}
