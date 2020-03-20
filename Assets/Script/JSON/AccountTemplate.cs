using System;
public class AccountTemplate
{
    public string firstname;
    public string lastname;
    public string username;
    public string email;
    public string password;

    public AccountTemplate(string firstname, string lastname, string username, string email, string password)
    {
        this.firstname = firstname;
        this.lastname = lastname;
        this.username = username;
        this.email = email;
        this.password = password;
    }
}
