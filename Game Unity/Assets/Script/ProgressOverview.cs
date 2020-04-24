using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ProgressOverview : MonoBehaviour
{
    public Text correct, incorrect;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.GetString("User", "").Equals(""))
        {
            FirebaseConnect.get("/answers/" + PlayerPrefs.GetString("User", ""), existing =>
            {
                Dictionary<string, object> entryDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(existing.ToString());
                List<object> entries = entryDict.Select(x => x.Value).ToList();

                List<Item> questions = new List<Item>();
                foreach (object obj in entries)
                {
                    Dictionary<string, Item> dict = null;
                    try
                    {
                        dict = JsonConvert.DeserializeObject<Dictionary<string, Item>>(obj.ToString());
                    }
                    catch (Exception ex)
                    {
                        Debug.Log("Error: " + ex.Message + " | " + ex.StackTrace);
                    }
                    Debug.Log(dict);
                    List<Item> list = dict.Select(x => x.Value).ToList();
                    Debug.Log(list);
                    questions.AddRange(list);
                }

                int correctint = 0;
                int incorrectint = 0;

                foreach (Item it in questions)
                {
                    if (it.correct)
                    {
                        correctint += 1;
                    }
                    else
                    {
                        incorrectint += 1;
                    }
                }

                correct.text = correctint.ToString();
                incorrect.text = incorrectint.ToString();
            });
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void openManageDiabetesScreen()
    {
        SceneManager.LoadScene("ManageDiabetes");
    }
}

public class Item
{
    public double answer { get; set; }
    public bool correct { get; set; }
}