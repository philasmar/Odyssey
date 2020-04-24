using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Barlife : MonoBehaviour
{
    public GameObject[] Heart;
    private Manage Manage;
    public Text Score;
    public Text Jumpscore;
    public Text Coinscore;
    public GameObject Redbackground;
    private GameObject Cam;
    private GameObject Output;
    // Start is called before the first frame update
    void Start()
    {
        Manage = GameObject.Find("Manage").GetComponent<Manage>();
        Cam = GameObject.Find("Main Camera");
        if (!Manage.keepScore)
        {
            Manage.Life = 3;
            Manage.Score = 0;
            Manage.Jumpscore = 0;
        }
        Manage.Lose = false;
        Manage.Startgame = false;
        Manage.keepScore = false;
        Showitem();
     
        Coinscore.text = "Coin Score : " + (int)Manage.Coin;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Damageparticle()
    {
        Output= Instantiate(Redbackground, new Vector3(Cam.transform.position.x, Cam.transform.position.y, transform.position.z), Quaternion.identity)as GameObject;
        Output.transform.parent = Cam.transform;
    }
    public void Showitem()
    {
        if (Manage.Life == 0)
        {
            Heart[0].SetActive(false);
            Heart[1].SetActive(false);
            Heart[2].SetActive(false);
        }
     else   if (Manage.Life == 1)
        {
            Heart[0].SetActive(true);
            Heart[1].SetActive(false);
            Heart[2].SetActive(false);

        }
        else if (Manage.Life == 2)
        {
            Heart[0].SetActive(true);
            Heart[1].SetActive(true);
            Heart[2].SetActive(false);

        }
        else if (Manage.Life == 3)
        {
            Heart[0].SetActive(true);
            Heart[1].SetActive(true);
            Heart[2].SetActive(true);

        }

        Score.text = "Score : " + (int)Manage.Score;
       
        Jumpscore.text = "Jump Score : " + (int)Manage.Jumpscore;
    }

    public void ShowCoinscore()
    {
        Coinscore.transform.localScale = new Vector3(1.2f, 1.2f, 1);
        Coinscore.text = "Coin Score : " + (int)Manage.Coin;
        StartCoroutine(Changescale());
 
    }
    IEnumerator Changescale()
    {
        yield return new WaitForSeconds(0.1f);
        Coinscore.transform.localScale = new Vector3(1f, 1f, 1);

    }
}
