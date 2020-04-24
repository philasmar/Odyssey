using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class CreateAccount : FirebaseConnect
{
    public InputField firstName, lastName, username, email, password;
    public GameObject failedPanel;
    // Start is called before the first frame update

    void Start()
    {
    }

    public void createAccount()
    {
        if (
            String.IsNullOrWhiteSpace(firstName.text) ||
            String.IsNullOrWhiteSpace(lastName.text) ||
            String.IsNullOrWhiteSpace(username.text) ||
            String.IsNullOrWhiteSpace(email.text) ||
            String.IsNullOrWhiteSpace(password.text)
           )
        {
            failedPanel.SetActive(true);
            failedPanel.GetComponentInChildren<Text>().text = "Please complete all fields!";
        }
        else
        {
            failedPanel.SetActive(false);

            FirebaseConnect.get<AccountTemplate>("/users/" + username.text, existing => {
                if (!(existing is AccountTemplate account))
                {
                    failedPanel.SetActive(false);
                    AccountTemplate user = new AccountTemplate(firstName.text, lastName.text, username.text, email.text, password.text);
                    FirebaseConnect.put("/users/" + username.text, user);
                    clearUI();
                    SceneManager.LoadScene("LoginScreen");
                }
                else
                {
                    failedPanel.SetActive(true);
                    failedPanel.GetComponentInChildren<Text>().text = "The username already exists!";
                }
            });
        }
    }

    public void openLoginScreen()
    {
        SceneManager.LoadScene("LoginScreen");
    }


    public void clearUI()
    {
        firstName.text = "";
        lastName.text = "";
        username.text = "";
        email.text = "";
        password.text = "";
    }
}
