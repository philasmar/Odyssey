using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManageDiabetesController : MonoBehaviour
{
    public GameObject signedInPanel, signedOutPanel;
    public Text userText;
    string user = "";
    // Start is called before the first frame update
    void Start()
    {
        user = PlayerPrefs.GetString("User", "");
        userText.text = PlayerPrefs.GetString("UserFirstName", "") + " " + PlayerPrefs.GetString("UserLastName", "");
        if (user.Equals(""))
        {
            signedInPanel.SetActive(false);
            signedOutPanel.SetActive(true);
        }
        else
        {
            signedOutPanel.SetActive(false);
            signedInPanel.SetActive(true);
        }
        Debug.Log("User: " + user);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openLoginScreen()
    {
        SceneManager.LoadScene("LoginScreen");
    }

    public void openProgressOverviewScreen()
    {
        SceneManager.LoadScene("ProgressOverview");
    }

    public void openCreateAccountScreen()
    {
        SceneManager.LoadScene("CreateAccount");
    }

    public void openQuestionInputScreen()
    {
        SceneManager.LoadScene("QuestionInput");
    }

    public void signOut()
    {
        PlayerPrefs.SetString("User", "");
        PlayerPrefs.SetString("UserFirstName", "");
        PlayerPrefs.SetString("UserLastName", "");
        SceneManager.LoadScene("Menu");
    }
}
