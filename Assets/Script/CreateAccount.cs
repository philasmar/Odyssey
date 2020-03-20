using System;
using Firebase.Database;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;
using System.Threading.Tasks;

public class CreateAccount : FirebaseConnect
{

    DatabaseReference reference;
    public InputField firstName, lastName, username, email, password;
    public GameObject failedPanel;
    // Start is called before the first frame update
    void Start()
    {
        //FirebaseConnect fbc = new FirebaseConnect();
        reference = this.getDBReference();
        //FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://odyssey-80079.firebaseio.com/");
        //reference = FirebaseDatabase.DefaultInstance.RootReference;
        if (reference == null)
        {
            EditorUtility.DisplayDialog("null", "ayy", "Yes", "No");
        }
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
        }
        else
        {
            failedPanel.SetActive(false);
            AccountTemplate user = new AccountTemplate(firstName.text, lastName.text, username.text, email.text, password.text);
            string json = JsonUtility.ToJson(user);

            reference.Child("users").Push().SetRawJsonValueAsync(json);
            clearUI();
        }
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
