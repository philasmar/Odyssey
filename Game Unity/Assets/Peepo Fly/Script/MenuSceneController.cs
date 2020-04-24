using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void openManageDiabetesScreen()
    {
        if (!PlayerPrefs.GetString("User", "").Equals(""))
        {
            SceneManager.LoadScene("ManageDiabetes");
        }
        else
        {
            SceneManager.LoadScene("LoginScreen");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
