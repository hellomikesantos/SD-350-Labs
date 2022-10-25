
public abstract class User
{
    public string Password { get; set; }
    public void PasswordHash()
    {

    }
}

public class AuthorizedUser : User
{
    public AuthorizedUser()
    {
        Console.WriteLine("Authorized User has been created.");
    }

}

public class Administrator : User
{
    public Administrator()
    {
        Console.WriteLine("Administrator User has been created");
    }
}

public abstract class System
{
    public User CreateUser(string JSONAttribute)
    {
        User user;
        user = GenerateUser(JSONAttribute);

        return user;
    }

    protected abstract User GenerateUser(string JSONAttribute);
}

public class TwoFactorRequired : System
{
    protected override User GenerateUser(string JSONAttribute)
    {
        User user;
        switch (JSONAttribute)
        {
            case "TwoFactorAuthentication: true":
                user = new AuthorizedUser();
                break;
            case "IsAdmin: true":
                user = new Administrator();
                break;
            default:
                throw new Exception();
        }
        return user;
    }
}

public class TwoFactorNotRequired : System
{
    protected override User GenerateUser(string JSONAttribute)
    {
        User user;
        switch (JSONAttribute)
        {
            case "TwoFactorAuthentication: true":
                user = new AuthorizedUser();
                break;
            case "IsAdmin: true":
                user = new Administrator();
                break;
            default:
                if (JSONAttribute == null)
                {
                    return null;
                }
                else
                {
                    throw new Exception();
                }
        }
        return user;
    }
}