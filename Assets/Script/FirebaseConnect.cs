using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;

public class FirebaseConnect : MonoBehaviour
{
    DatabaseReference reference;
    // Start is called before the first frame update
    void Start()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://odyssey-80079.firebaseio.com/");
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public DatabaseReference getDBReference()
    {
        return reference;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}