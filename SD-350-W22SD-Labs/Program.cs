Client newClient = new User("hellomikesantos", "michael@mitt.ca");
newClient = new Badge1("Pull Shark Badge", 50, newClient);
newClient = new Badge1("YOLO Badge", 25, newClient);
Console.WriteLine(newClient.GetDescription());
Console.WriteLine(newClient.GetReputation());

public abstract class Client
{
    protected string _userName { get; set; }
    protected string _email { get; set; }
    protected string _decription { get; set; } = "";
    protected int _reputation { get; set; }
    public virtual int GetReputation()
    {
        return _reputation;
    }
    public virtual string GetDescription()
    {
        return _decription;
    }
}

public class User : Client
{
    public User(string userName, string email)
    {
        _userName = userName;
        _email = email;
        _decription = "Base-level User";
        _reputation = 0;
    }
}

public abstract class BadgeDecorator : Client
{
    public Client _client { get; set; }
    public string _description { get; set; }
    public int _reputation { get; set; }
    public abstract override int GetReputation();
    public abstract override string GetDescription();
}

public class Badge1 : BadgeDecorator
{
    public string _description { get; set; }
    public int _reputation { get; set; }
    public Badge1(string description, int reputation, Client client)
    {
        _reputation = reputation;
        _description = description;
        _client = client;
    }
    public override string GetDescription()
    {
        return $"{_client.GetDescription()} {_description}";
    }
    public override int GetReputation()
    {
        return _client.GetReputation() + _reputation;
    }
}