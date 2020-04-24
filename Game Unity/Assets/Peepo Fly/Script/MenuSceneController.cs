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

    public void openLoginScreen()
    {
        SceneManager.LoadScene("ProgressOverview");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
