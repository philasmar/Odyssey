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
            Dictionary<string, object> entryDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(existing.ToString());
            List<object> entries = entryDict.Select(x => x.Value).ToList();

            List<Item> questions = new List<Item>();
            foreach(object obj in entries)
            {
                questions.AddRange(JsonConvert.DeserializeObject<Dictionary<string, Item>>(obj.ToString()).Select(x => x.Value).ToList());
            }

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

            correct.text = correctint.ToString();
            incorrect.text = incorrectint.ToString();
        });
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