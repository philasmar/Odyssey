using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D Rgb2d;
    private Manage Manage;
    public float Speed;
    public float Highspeed;
    private bool Oncejump;
    private float Myspeed;
    private GameObject Cam;
    private bool Damage;
    private Barlife Items;
    public GameObject Hearthparticle;
    public GameObject []feather;
    private Animator Anim;
    public GameObject []Eye;

    public GameObject []Sunglass;
    public GameObject[] Cap;

    private AudioSource Playeraudio;
    private AudioSource Hearthaudio;
    private AudioSource Stoneaudio;
    private QuestionScreen QuestionScreen;
    // Start is called before the first frame update
    void Start()
    {
        Manage = GameObject.Find("Manage").GetComponent<Manage>();
        Playeraudio= GameObject.Find("Playeraudio").GetComponent<AudioSource>();
        Hearthaudio = GameObject.Find("Hearthaudio").GetComponent<AudioSource>();
        Stoneaudio = GameObject.Find("Stoneaudio").GetComponent<AudioSource>();
        QuestionScreen = GameObject.Find("SceneController").GetComponent<QuestionScreen>();
        Manage.Player = gameObject;
        Rgb2d = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
          Cam = GameObject.Find("Main Camera");
        Manage.Cam = Cam;
        Items= GameObject.Find("Barlife").GetComponent<Barlife>();

        if (Manage.Sunglass > 0)
        {
            Sunglass[Manage.Sunglass-1].SetActive(true);

        }
         if (Manage.Cap > 0)
        {
            Cap[Manage.Cap-1].SetActive(true);
        }
        Myspeed = 0;
        Manage.Moveleft = false;
        Manage.Moveright = false;
    }
    public void Firstjump()
    {
        if (Manage.Sound == 0)
        {
            Playeraudio.Play();
        }
        Rgb2d.velocity = new Vector3(0, 15);
        Anim.SetInteger("Player", 1);
        Eye[0].SetActive(false);
        Eye[1].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= 4.9f)
        {
            transform.position = new Vector3(-4.8f, transform.position.y, transform.position.z);
        }
       else if (transform.position.x <= -4.9f)
        {
            transform.position = new Vector3(4.8f, transform.position.y, transform.position.z);
        }
        if (Manage.Moveleft == true)
        {
            if (Myspeed > 0)
            {
                Myspeed -= (Speed + 3f) * Time.deltaTime;
            }
          else  if (Myspeed <= 0)
            {
                Myspeed -= Speed * Time.deltaTime;
                if (Myspeed <= -Highspeed)
                {
                    Myspeed = -Highspeed;
                }
            }
          
            transform.position += new Vector3(Myspeed * Time.deltaTime, 0, 0);

        }
       else if (Manage.Moveright == true)
        {
            if (Myspeed < 0)
            {
                Myspeed += (Speed+3f) * Time.deltaTime;
            }
            else if (Myspeed >= 0)
            {
                Myspeed += Speed * Time.deltaTime;
                if (Myspeed >= Highspeed)
                {
                    Myspeed = Highspeed;
                }
            }

            transform.position += new Vector3(Myspeed * Time.deltaTime, 0, 0);
        }
        else if (Manage.Moveleft == false && Manage.Moveright == false)
        {
            if (Myspeed < 0)
            {
                Myspeed += (Speed + 3f) * Time.deltaTime;
                if (Myspeed >= 0)
                {
                    Myspeed = 0;
                }
            }
            else if (Myspeed > 0)
            {
                Myspeed -= (Speed + 3f) * Time.deltaTime;
                if (Myspeed <= 0)
                {
                    Myspeed = 0;
                }
            }
            transform.position += new Vector3(Myspeed * Time.deltaTime, 0, 0);
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {


        if (coll.gameObject.tag == "Stone")
        {
            if (Manage.Sound == 0) { Stoneaudio.Play(0); }
        }
    }
            void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Hearth")
        {
            if (Manage.Sound == 0)
            {
                Hearthaudio.Play();
            }
            Manage.Life += 1;
            if (Manage.Life >= 3)
            {
                Manage.Life = 3;
            }
            Items.Showitem();
            Instantiate(Hearthparticle, new Vector3(coll.transform.position.x, coll.transform.position.y, transform.position.z), Quaternion.identity);
            Destroy(coll.gameObject);

        }
        if (coll.gameObject.tag == "End") {
            if (Manage.Sound == 0)
            {
                Playeraudio.Play();
            }
            Manage.Life = 0;
            Manage.Lose = true;
            if (PlayerPrefs.GetString("User", "").Equals(""))
            {
                Manage.Againmenu();
            }
            else
            {
                QuestionScreen.loadQuestion();
                //Manage.Questionmenu();
            }
            Items.Showitem();
            Instantiate(feather[2], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            Destroy(gameObject);
            //Manage.Questionmenu();

        }
            if (coll.gameObject.tag == "Bird") {
           
            if (Oncejump == false)
            {
                Manage.InstantiateJump();
                StartCoroutine(Newjump());

                Manage.Jumpscore += 1;
               
                Oncejump = true;
            }
            if (transform.position.y < Cam.transform.position.y-2 ) { 
            Rgb2d.velocity = new Vector3(0, 20);
            }
         else   if (transform.position.y >= Cam.transform.position.y-2)
            {
                Rgb2d.velocity = new Vector3(0, 17);
            }
            Manage.Score += 10;
            Items.Showitem();

        }
        if (coll.gameObject.tag == "Enemy")
        {
          

            if (Oncejump == false)
            {
                Manage.InstantiateJump();
                StartCoroutine(Newjump());

                Manage.Jumpscore += 1;
                Oncejump = true;
            }
            if (transform.position.y < Cam.transform.position.y - 2)
            {
                Rgb2d.velocity = new Vector3(0, 20);
            }
            else if (transform.position.y >= Cam.transform.position.y - 2)
            {
                Rgb2d.velocity = new Vector3(0, 17);
            }
            if (Damage == false)
            {
                Manage.Life -= 1;
                if (Manage.Sound == 0)
                {
                    Playeraudio.Play();
                }
                Instantiate(feather[0], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) ;
                Items.Damageparticle();
                if (Manage.Life <= 0)
                {
                   
                    Instantiate(feather[1], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                    Manage.Life = 0;
                    Items.Showitem();
                    Manage.Lose = true;
                    Manage.Againmenu();
                    Destroy(gameObject);
                }
                StartCoroutine(Newdamage());
                Damage = true;
            }
            Items.Showitem();
        }
    }
    IEnumerator Newjump()
    {
        yield return new WaitForSeconds(0.35f);
        Oncejump = false;
    }
    IEnumerator Newdamage()
    {
        yield return new WaitForSeconds(1f);
        Damage = false;
    }
}
