using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginAccount : FirebaseConnect
{

    public InputField username, password;
    public GameObject failedPanel;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void login()
    {
        if (
            String.IsNullOrWhiteSpace(username.text) ||
            String.IsNullOrWhiteSpace(password.text)
           )
        {
            failedPanel.SetActive(true);
        }
        else
        {
            FirebaseConnect.get<AccountTemplate>("/users/" + username.text, existing => {
                if (existing is AccountTemplate account && account.password.Equals(password.text))
                {
                    SceneManager.LoadScene("Game");
                    //failedPanel.SetActive(false);
                    //AccountTemplate user = new AccountTemplate(firstName.text, lastName.text, username.text, email.text, password.text);
                    //FirebaseConnect.put("/users/" + username.text, user);
                    //clearUI();
                }
                else
                {
                    failedPanel.SetActive(true);
                    failedPanel.GetComponentInChildren<Text>().text = "Invalid Username or Password!";
                }
            });
        }
    }

    public void clearUI()
    {
        username.text = "";
        password.text = "";
    }
}
