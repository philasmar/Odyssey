using System;
using Firebase.Database;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CreateAccount : FirebaseConnect
{
    DatabaseReference reference;
    public InputField firstName, lastName, email, password;

    public CreateAccount()
    {
        FirebaseConnect fbc = new FirebaseConnect();
        reference = fbc.getDBReference();
    }

    public void createAccount()
    {
        if (String.IsNullOrWhiteSpace(firstName.text))
        {
            EditorUtility.DisplayDialog("mlot", "ayy", "Yes", "No");
        }
        else
        {
            AccountTemplate user = new AccountTemplate("phil", "email");
            string json = JsonUtility.ToJson(user);

            reference.Child("users").Child("phil").SetRawJsonValueAsync(json);
        }
    }
}
