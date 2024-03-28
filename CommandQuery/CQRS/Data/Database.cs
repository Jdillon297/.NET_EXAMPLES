namespace CommandQuery.CQRS.Data;

public sealed class Database
{
    private static Database _instance;
    public List<User> users;


    private Database(List<User> users)
    {
        this.users = users;   
    }

    public static Database GetInstance()
    {
        if (_instance == null)
        {
            var users = SeedDatabase.Seed();
            var instance = new Database(users);
            return instance;
        }
        return _instance;
    }

    public void InsertUser(User user)
    {
        users.Add(user);
    }


    public void DeleteUser(User user)
    {
        users.Remove(user);
    }

    public User? FindUserById(int id)
    {
        var user = this.users.Where(x => x.Id == id).FirstOrDefault();
        return user;
    }

    public void UpdateUserById(int id, string name, int age)
    {
      var user = this.users.Where(x => x.Id == id).FirstOrDefault();
        user.Name = name;
        user.Age = age;
                  
    }


    public int GetLastUsersId()
    {
        return users.Select(x => x.Id).Max();
    }
}
