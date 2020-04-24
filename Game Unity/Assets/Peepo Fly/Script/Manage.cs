using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Manage : MonoBehaviour
{
    public int Sound;
    public GameObject Player;
    public bool Moveright;
    public bool Moveleft;
    public GameObject Cam;
    public GameObject[] Jump;
    public bool Lose;
    public bool Startgame;
    public GameObject []Birdsandenemies;
    public int Life;
    public GameObject[] Targets;
    private float Chance;
    private float Timer;
    private GameObject Output;
    private float Balloonchance;
    private float Jumpchance;
    public int Score;
    public int Jumpscore;
    public int Coin;
    public bool keepScore = false;
    public GameObject []Coins;
    public GameObject []Balloon;
    public GameObject Cloud;


    public int Bestscore;
    public int Bestjumpscore;

    public GameObject Again;
    public GameObject Pause;
    public GameObject Question;


    public int Sunglass;
    public int Cap;
    public int Playernumber;
    // Start is called before the first frame update
    IEnumerator Logo()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        StartCoroutine(Logo());

      


        Bestscore = PlayerPrefs.GetInt("Bestscore", Bestscore);
        Bestjumpscore = PlayerPrefs.GetInt("Bestjumpscore", Bestjumpscore);

        Coin = PlayerPrefs.GetInt("Coin", Coin);
        Sunglass = PlayerPrefs.GetInt("Sunglass", Sunglass);
        Cap = PlayerPrefs.GetInt("Cap", Cap);
        Playernumber = PlayerPrefs.GetInt("Playernumber", Playernumber);

        if (Playernumber == 0) { Playernumber=1; }
    }
    
    public void Againmenu()
    {
        StartCoroutine(activeagainmenu());
        GameObject.Find("Buttons-arrow").SetActive(false);
        if (Bestscore < Score)
        {
            Bestscore = Score;
        }
        if (Bestjumpscore < Jumpscore)
        {
            Bestjumpscore = Jumpscore;
        }
         PlayerPrefs.SetInt("Bestscore", Bestscore);
       PlayerPrefs.SetInt("Bestjumpscore", Bestjumpscore);
    }

    public void Questionmenu()
    {
        StartCoroutine(activequestionmenu());
        GameObject.Find("Buttons-arrow").SetActive(false);
        if (Bestscore < Score)
        {
            Bestscore = Score;
        }
        if (Bestjumpscore < Jumpscore)
        {
            Bestjumpscore = Jumpscore;
        }
        PlayerPrefs.SetInt("Bestscore", Bestscore);
        PlayerPrefs.SetInt("Bestjumpscore", Bestjumpscore);
    }

    public void Saveplayer()
    {
        PlayerPrefs.SetInt("Sunglass", Sunglass);
        PlayerPrefs.SetInt("Cap", Cap);
        PlayerPrefs.SetInt("Playernumber", Playernumber);
    }
    public void Savecion()
    {
       PlayerPrefs.SetInt("Coin", Coin);
    }

    IEnumerator activeagainmenu()
    {
        yield return new WaitForSeconds(2.5f);
        Savecion();
        Again.SetActive(true);
    }

    IEnumerator activequestionmenu()
    {
        yield return new WaitForSeconds(1f);
        Savecion();
        Question.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if (Startgame == true && Lose == false)
        {
            Timer += 1 * Time.deltaTime;
            if (Timer >= 5f)
            {
                InstantiateBirdsandscore();
                Timer = 0;
            }
        }


    // PlayerPrefs.DeleteAll();



    }
    public void Pausegame()
    {
        Pause.SetActive(true);
        Time.timeScale = 0;
    }
    public void Resmuegame()
    {
        Pause.SetActive(false);
        Time.timeScale = 1;
    }
    public void HideQuestion()
    {
        Question.SetActive(false);
    }
    public void InstantiateJump()
    {
        Instantiate(Jump[Random.Range(0, 17)], new Vector3(0, Cam.transform.position.y+12f, 0), Quaternion.identity);
    }

    public void InstantiateBirdsandscore()
    {
        if (Score >= 0 && Score <= 150)
        {
            Balloonchance = 10;
            Jumpchance = 50;
        }
      else  if (Score >= 151 && Score <= 300)
        {
            Balloonchance = 25;
            Jumpchance = 35;
        }
      else  if (Score >= 301)
        {
            Balloonchance = 35;
            Jumpchance = 30;
        }
     Instantiate(Coins[Random.Range(0, 4)],
                new Vector3(Random.Range(-4.2f,4.2f), Cam.transform.position.y+15, 0), Quaternion.identity);
        Instantiate(Cloud,
               new Vector3(Random.Range(-4.2f, 4.2f), Cam.transform.position.y + 15, 0), Quaternion.identity);

        Chance = Random.Range(0, 101);
        if (Chance <= Jumpchance)
        {
           
            Output=Instantiate(Birdsandenemies[Random.Range(0, 5)],
                new Vector3(Targets[0].transform.position.x, Targets[0].transform.position.y , 0), Quaternion.identity)as GameObject;
            Output.GetComponent<Bird>().MoveRight = -5;
            
         
        }
        Chance = Random.Range(0, 101);
        if (Chance <= Jumpchance)
        {
            Output = Instantiate(Birdsandenemies[Random.Range(0, 5)],
                new Vector3(Targets[1].transform.position.x, Targets[1].transform.position.y, 0), Quaternion.identity) as GameObject;
            Output.GetComponent<Bird>().MoveRight = Random.Range(-1.5f, -2.5f);
         
        }
        Chance = Random.Range(0, 101);
        if (Chance <= Jumpchance)
        {
            Output = Instantiate(Birdsandenemies[Random.Range(0, 5)],
                new Vector3(Targets[2].transform.position.x, Targets[2].transform.position.y, 0), Quaternion.identity) as GameObject;
            Output.GetComponent<Bird>().MoveRight = Random.Range(1.5f,2.5f);
            
        }
        Chance = Random.Range(0, 101);
        if (Chance <= Jumpchance)
        {
            Output = Instantiate(Birdsandenemies[Random.Range(0, 5)],
                new Vector3(Targets[3].transform.position.x, Targets[3].transform.position.y, 0), Quaternion.identity) as GameObject;
            Output.GetComponent<Bird>().MoveRight = 5f;
           
        }

        Chance = Random.Range(0, 101);
        if (Chance <= Balloonchance)
        {
            Output = Instantiate(Balloon[Random.Range(0, 3)],
                new Vector3(Random.Range(-4.2f,4.2f), Cam.transform.position.y+12f, 0), Quaternion.identity) as GameObject;
         

        }
        Chance = Random.Range(0, 101);
        if (Chance <= 10)
        {
            Output = Instantiate(Balloon[3],
                new Vector3(Random.Range(-4.2f, 4.2f), Cam.transform.position.y + 12f, 0), Quaternion.identity) as GameObject;


        }
    }

    }
