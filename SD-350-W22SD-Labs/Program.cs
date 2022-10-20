Client user = new User("michael", "michael@mitt.ca", 20);
user.HandleAccess(50, false);
Client manager = new Manager();
manager.HandleAccess(40, true);
manager.HandleAccess(40, false);
Client admin = new Admin();
admin.HandleAccess(50, true);

public abstract class Client
{
    public string Name { get; set; }
    public string Email { get; set; }
    public int? Age { get; set; }
    public bool AccessDisabled { get; set; }
    public IAccessHandler AccessHandler { get; set; }
    public void HandleAccess(int? reputation, bool accessDisabled)
    {
        AccessHandler.GetAccess(reputation, accessDisabled);
    }
}

public class User : Client
{
    public int Reputation { get; set; }
    public User(string name, string email, int? age)
    {
        Name = name;
        Email = email;
        Age = age;
        AccessHandler = new HasReputation();
    }
    public void HandleAccess(int? reputation, bool accessDisabled)
    {
        AccessHandler.GetAccess(reputation, accessDisabled);
    }
}

public class Manager : Client
{
    public Manager()
    {
        AccessHandler = new HasAccessAutomatic();
    }
    public void HandleAccess(bool accessDisabled)
    {
        AccessHandler.GetAccess(null, accessDisabled);
    }
}

public class Admin : Client
{
    public Admin()
    {
        AccessHandler = new HasAccessAutomatic();
    }
    public void HandleAccess(bool accessDisabled)
    {
        AccessHandler.GetAccess(null, accessDisabled);
    }
}

public interface IAccessHandler
{
    public bool GetAccess(int? reputation, bool accessDisabled);
}

public class HasReputation : IAccessHandler
{

    public bool GetAccess(int? reputation, bool accessDisabled)
    {
        if (reputation > 20)
        {
            Console.WriteLine("This Client has a reputation.");
            return true;
        }
        else
        {
            Console.WriteLine("NO REPUTATION!!!");
            return false;
        }
    }
}

public class HasAccessAutomatic : IAccessHandler
{
    public bool GetAccess(int? reputation, bool accessDisabled)
    {
        if (!accessDisabled)
        {
            Console.WriteLine("This client has automatic access.");
            return true;
        }
        else
        {
            Console.WriteLine("NO AUTOMATIC ACCESS!!!");
            return false;
        }
    }
}