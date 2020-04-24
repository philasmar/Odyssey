using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuestionScreen : MonoBehaviour
{
    public Text questionText, option1, option2, option3, timeLeft;
    private Manage Manage;
    private AudioSource Playeraudio;
    private Barlife Items;
    public GameObject[] Player;
    private AudioSource Clickaudio;

    string questionID = "";
    Question question;
    List<double> options = new List<double>();
    bool loaded = false;
    System.Timers.Timer aTimer;
    // Start is called before the first frame update
    void Start()
    {
        Manage = GameObject.Find("Manage").GetComponent<Manage>();
        Playeraudio = GameObject.Find("Playeraudio").GetComponent<AudioSource>();
        Clickaudio = GameObject.Find("Clickaudio").GetComponent<AudioSource>();
        Items = GameObject.Find("Barlife").GetComponent<Barlife>();
    }

    public void loadQuestion()
    {
        if(!PlayerPrefs.GetString("User", "").Equals(""))
        {
            FirebaseConnect.get("/questions/" + PlayerPrefs.GetString("User", ""), existing => {
                Dictionary<string, Question> entryDict = JsonConvert.DeserializeObject<Dictionary<string, Question>>(existing.ToString());
                List<Question> entries = entryDict.Select(x => x.Value).ToList();
                int randomnum = RandomNumber(0, entryDict.Count);
                questionID = entryDict.ElementAt(randomnum).Key;
                question = entryDict.ElementAt(randomnum).Value;
                questionText.text = String.Format(
                    "You are eating {0} and you CGM reading is {1}." +
                    Environment.NewLine +
                    Environment.NewLine +
                    "How much insulin should you take?",
                             question.food, question.bloodsugar);

                options.Add(question.insulin);
                while (options.Count < 3)
                {
                    double rand = RandomDouble(1, 6);
                    if (!options.Contains(rand))
                    {
                        options.Add(rand);
                    }
                }
                options.Sort();
                if (options[0] == 1)
                {
                    option1.text = "1 Unit";
                }
                else
                {
                    option1.text = options[0] + " Units";
                }
                if (options[1] == 1)
                {
                    option2.text = "1 Unit";
                }
                else
                {
                    option2.text = options[1] + " Units";
                }
                if (options[2] == 1)
                {
                    option3.text = "1 Unit";
                }
                else
                {
                    option3.text = options[2] + " Units";
                }
                timerLeft = 16.0f;
                loaded = true;
                Manage.Questionmenu();
            }, error=> {
                Manage.Againmenu();
            });
        }
    }
    public float timerLeft = 0f;
    // Update is called once per frame
    void Update()
    {
        if (timerLeft > 0)
        {
            timerLeft -= Time.deltaTime;
            timeLeft.text = (timerLeft).ToString("0");
            if (int.Parse(timeLeft.text) == 0)
            {
                restartGame();
            }
        }
    }

    public int RandomNumber(int min, int max)
    {
        System.Random random = new System.Random();
        return random.Next(min, max);
    }

    public double RandomDouble(int min, int max)
    {
        System.Random random = new System.Random();
        return Math.Round(random.NextDouble() * (max - min) + min, 1);
    }

    public void option1Click()
    {
        if (question.insulin == options[0])
        {
            logAnswer(question.insulin, true);
            continueGame();
        }
        else
        {
            logAnswer(options[0], false);
            restartGame();
        }
    }

    public void option2Click()
    {
        if (question.insulin == options[1])
        {
            logAnswer(question.insulin, true);
            continueGame();
        }
        else
        {
            logAnswer(options[1], false);
            restartGame();
        }
    }

    public void option3Click()
    {
        if (question.insulin == options[2])
        {
            logAnswer(question.insulin, true);
            continueGame();
        }
        else
        {
            logAnswer(options[2], false);
            restartGame();
        }
    }

    public void continueGame()
    {
        Manage.HideQuestion();
        if (Manage.Sound == 0)
        {
            Clickaudio.Play();
        }
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        Manage.keepScore = true;
    }

    public void restartGame()
    {
        Manage.HideQuestion();
        if (Manage.Sound == 0)
        {
            Clickaudio.Play();
        }
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        Manage.keepScore = false;
    }

    public void logAnswer(double ans, bool correct)
    {
        AnswerTemplate answer = new AnswerTemplate(ans, correct);
        FirebaseConnect.post("/answers/" + PlayerPrefs.GetString("User", "") + "/" + questionID, answer);
    }
}

public class Question
{
    public string activity { get; set; }
    public int bloodsugar { get; set; }
    public string food { get; set; }
    public double insulin { get; set; }
}