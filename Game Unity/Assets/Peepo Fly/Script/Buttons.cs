using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Buttons : MonoBehaviour
{
    public GameObject Particle;
    private Manage Manage;
    public GameObject Arrow;
    public int Buttonnumber;
    public GameObject PlayerLock;
    public GameObject SunglassLock;
    public GameObject CapLock;
    private Image Myimage;
    public Sprite [] Buttonsprite;
    public int Coin;

    public GameObject Mymenu;
    private Menu Menu;


    public int Unlockplayer;
    public int UnlockSunglass;
    public int UnlockCap;


    public bool Checksoundsprite;
    private AudioSource Menuaudio;
    private AudioSource Clickaudio;
    private AudioSource Buyaudio;
    // Start is called before the first frame update
    void Start()
    {
        

        Manage = GameObject.Find("Manage").GetComponent<Manage>();
        Clickaudio = GameObject.Find("Clickaudio").GetComponent<AudioSource>();
        if (Particle != null)
        {
            Buyaudio = GameObject.Find("Buyaudio").GetComponent<AudioSource>();
        }
        Myimage = GetComponent<Image>();
        if (Checksoundsprite == true)
        {
            Menuaudio = GameObject.Find("Menuaudio").GetComponent<AudioSource>();
            Showsoundsprite();
           
        }

        if (PlayerLock != null) {
            Unlockplayer = PlayerPrefs.GetInt("Unlockplayer" + Buttonnumber, Unlockplayer);
            Checkmylock();
        }
      else  if (SunglassLock != null)
        {
            UnlockSunglass = PlayerPrefs.GetInt("UnlockSunglass" + Buttonnumber, UnlockSunglass);
            Checkmylock();
        }
     else   if (CapLock != null)
        {
            UnlockCap = PlayerPrefs.GetInt("UnlockCap" + Buttonnumber, UnlockCap);
            Checkmylock();
        }

        if (Mymenu != null)
        {
            Menu = Mymenu.GetComponent<Menu>();
        }
     
        

    }
    public void Soundbutton()
    {
       
            Clickaudio.Play();
       
        Manage.Sound += 1;
        if (Manage.Sound >= 2)
        {
            Manage.Sound = 0;
        }
        Showsoundsprite();
    }
    public void Showsoundsprite()
    {
        if (Manage.Sound == 0)
        {
            Myimage.sprite = Buttonsprite[0];
            Menuaudio.Play();
        }
        else if (Manage.Sound == 1)
        {
            Myimage.sprite = Buttonsprite[1];
            Menuaudio.Stop();
        }
    }
    public void Shopbutton()
    {
        Menu.Shopnumber = Buttonnumber;
        Menu.showshopmenu();
        if (Manage.Sound == 0)
        {
            Clickaudio.Play();
        }
    }
    public void Showbutton()
    {
        transform.localScale = new Vector3(1.2f, 1.2f, 0);
        Myimage = GetComponent<Image>();
        Myimage.sprite = Buttonsprite[1];
    }
    public void Changeimage()
    {
        transform.localScale = new Vector3(1f, 1f, 0);
        Myimage = GetComponent<Image>();
        Myimage.sprite = Buttonsprite[0];
    }
    public void Checkmylock()
    {
        if (Unlockplayer >= 1)
        {
            Destroy(PlayerLock);
        }
        else if (UnlockSunglass >= 1)
        {
            Destroy(SunglassLock);
        }
       else if (UnlockCap >= 1)
        {
            Destroy(CapLock);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Selectplayerbutton()
    {
        if (Manage.Sound == 0)
        {
            Clickaudio.Play();
        }
        if (PlayerLock == null) { 
        Manage.Playernumber = Buttonnumber;
        Menu.Showselectplayer();
            Manage.Saveplayer();
        }
        else if (PlayerLock != null)
        {
            if (Manage.Coin >= Coin)
            {
                Instantiate(Particle, new Vector3(transform.position.x,transform.position.y, transform.position.z), Quaternion.identity);
                if (Manage.Sound == 0) { Buyaudio.Play(); }
                Manage.Coin -= Coin;
                Manage.Savecion();
                Manage.Playernumber = Buttonnumber;
                Menu.Showselectplayer();
                Unlockplayer = 1;
               PlayerPrefs.SetInt("Unlockplayer" + Buttonnumber, Unlockplayer);
                Menu.ShowCoins();
                Checkmylock();
                Manage.Saveplayer();
                
            }
        }
    }
   public void Jumpbutton()
    {
        Manage.Startgame = true;
        Manage.Player.GetComponent<Player>().Firstjump();
        Arrow.SetActive(true);
        Destroy(gameObject);
    }

    public void Againbutton()
    {
        if (Manage.Sound == 0)
        {
            Clickaudio.Play();
        }
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        
    }
    public void Playbutton()
    {
        if (Manage.Sound == 0)
        {
            Clickaudio.Play();
        }
        SceneManager.LoadScene("Play", LoadSceneMode.Single);
    }
    public void Playersbutton()
    {
        if (Manage.Sound == 0)
        {
            Clickaudio.Play();
        }
        Instantiate(Mymenu, new Vector3(0, 0,0), Quaternion.identity);

    }


    public void Homebutton()
    {
        if (Manage.Sound == 0)
        {
            Clickaudio.Play();
        }
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);

    }
    public void SelectSunglassbutton()
    {
        if (Manage.Sound == 0)
        {
            Clickaudio.Play();
        }
        if (SunglassLock == null)
        {
            Manage.Sunglass = Buttonnumber;
            Menu.Showselectsunglass();
            Manage.Saveplayer();
        }
        else if (SunglassLock != null)
        {
            if (Manage.Coin >= Coin)
            {
                Instantiate(Particle, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                if (Manage.Sound == 0) { Buyaudio.Play(); }
                Manage.Coin -= Coin;
                Manage.Savecion();
                Manage.Sunglass = Buttonnumber;
                Menu.Showselectsunglass();
                UnlockSunglass = 1;
                PlayerPrefs.SetInt("UnlockSunglass" + Buttonnumber, UnlockSunglass);
                Menu.ShowCoins();
                Checkmylock();
                Manage.Saveplayer();
            }
        }
    }
    public void Exitgame()
    {
        Application.Quit();
    }
    public void Resumegamebutton()
    {
        if (Manage.Sound == 0)
        {
            Clickaudio.Play();
        }
        Manage.Resmuegame();
    }
    public void Pausegamebuttoon()
    {
        if (Manage.Lose == false)
        {
            Menu.Showscore();
            Manage.Pausegame();
        }
    }
    public void SelectCapbutton()
    {
        if (Manage.Sound == 0)
        {
            Clickaudio.Play();
        }
        if (CapLock == null)
        {
            Manage.Cap = Buttonnumber;
            Menu.Showselectcaps();
            Manage.Saveplayer();
        }
        else if (CapLock != null)
        {
            if (Manage.Coin >= Coin)
            {
                Instantiate(Particle, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                if (Manage.Sound == 0) { Buyaudio.Play(); }
                Manage.Coin -= Coin;
                Manage.Savecion();
                Manage.Cap = Buttonnumber;
                Menu.Showselectcaps();
                UnlockCap = 1;
                PlayerPrefs.SetInt("UnlockCap" + Buttonnumber, UnlockCap);
                Menu.ShowCoins();
                Checkmylock();
                Manage.Saveplayer();
            }
        }
    }

    public void Exitmenu()
    {
        if (Manage.Sound == 0)
        {
            Clickaudio.Play();
        }
        Destroy(Mymenu);
    }

}
