using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ProgressOverview : MonoBehaviour
{
    public Text correct, incorrect;
    // Start is called before the first frame update
    void Start()
    {
        FirebaseConnect.get("/answers/" + UserProps.user, existing => {
            Debug.Log("1");
            Dictionary<string, object> entryDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(existing.ToString());
            Debug.Log("2");
            List<object> entries = entryDict.Select(x => x.Value).ToList();
            Debug.Log("3");

            List<Item> questions = new List<Item>();
            Debug.Log("4");
            foreach (object obj in entries)
            {
                Debug.Log("4.1");
                Debug.Log(obj.ToString());
                Debug.Log("4.2");
                Dictionary<string, Item> dict = null;
                try
                {
                    dict = JsonConvert.DeserializeObject<Dictionary<string, Item>>(obj.ToString());
                }catch(Exception ex)
                {
                    Debug.Log("Error: " + ex.Message + " | " + ex.StackTrace);
                }
                Debug.Log("4.3");
                Debug.Log(dict);
                Debug.Log("4.4");
                List<Item> list = dict.Select(x => x.Value).ToList();
                Debug.Log("4.5");
                Debug.Log(list);
                Debug.Log("4.6");
                questions.AddRange(list);
                Debug.Log("4.7");
            }
            Debug.Log("5");

            int correctint = 0;
            int incorrectint = 0;

            foreach(Item it in questions)
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
            Debug.Log("6");

            correct.text = correctint.ToString();
            incorrect.text = incorrectint.ToString();
            Debug.Log("7");
        });
        Debug.Log("8");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class Item
{
    public int answer { get; set; }
    public bool correct { get; set; }
}