using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startgame : MonoBehaviour
{
    private Manage Manage;
    private Barlife Barlife;
    public GameObject Again;
    public GameObject Pause;
    public GameObject Question;
    public GameObject []Player;
   
    void Start()
    {
        Barlife= GameObject.Find("Barlife").GetComponent<Barlife>();
        Manage = GameObject.Find("Manage").GetComponent<Manage>();
        Manage.Again = Again;
        Manage.Pause = Pause;
        Manage.Question = Question;
        Instantiate(Player[Manage.Playernumber], new Vector3(0, -3f, 0), Quaternion.identity);



        Manage.Targets[0]= GameObject.Find("Target-position0");
        Manage.Targets[1] = GameObject.Find("Target-position1");
        Manage.Targets[2] = GameObject.Find("Target-position2");
        Manage.Targets[3] = GameObject.Find("Target-position3");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
