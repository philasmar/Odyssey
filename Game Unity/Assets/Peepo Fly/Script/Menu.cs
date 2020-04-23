using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    public Text Levelscore;
    public Text Bestlevelscore;
    public Text Jumpscore;
    public Text Bestjumpscore;
    public Text Coinscore;
    private Manage Manage;
    public bool Showselectsshopmenu;
    public GameObject []Playerimage;
    public GameObject[] Selectplayers;
    public GameObject[] Selectsunglass;
    public GameObject[] Selectcap;
    public bool Checkshop;
    public int Shopnumber;
    public GameObject []Shopbuttonsimage;
    public GameObject []Shops;
    public GameObject Sunglass;
    public GameObject []Caps;
    public Sprite []Sunglasssprite;
    // Start is called before the first frame update

        public void Showselectsunglass()
    {
        Selectsunglass[0].SetActive(false);
        Selectsunglass[1].SetActive(false);
        Selectsunglass[2].SetActive(false);
        Selectsunglass[3].SetActive(false);
        Selectsunglass[4].SetActive(false);
        Selectsunglass[5].SetActive(false);
        Selectsunglass[6].SetActive(false);
        Selectsunglass[7].SetActive(false);
        Selectsunglass[8].SetActive(false);
        Selectsunglass[9].SetActive(false);
        Selectsunglass[10].SetActive(false);
        Selectsunglass[Manage.Sunglass].SetActive(true);

        if (Manage.Sunglass > 0) {
            Sunglass.GetComponent<Image>().enabled = true;
            Sunglass.GetComponent<Image>().sprite = Sunglasssprite[Manage.Sunglass];
        }
        else if(Manage.Sunglass <= 0) {
            Sunglass.GetComponent<Image>().enabled =false;
        }

    }
   public void showshopmenu()
    {
        Shops[0].SetActive(false);
        Shops[1].SetActive(false);
        Shops[2].SetActive(false);
        Shops[Shopnumber].SetActive(true);
        Shopbuttonsimage[0].GetComponent<Buttons>().Changeimage();
        Shopbuttonsimage[1].GetComponent<Buttons>().Changeimage();
        Shopbuttonsimage[2].GetComponent<Buttons>().Changeimage();
        Shopbuttonsimage[Shopnumber].GetComponent<Buttons>().Showbutton();
    }
    void Start()
    {

      
        Manage = GameObject.Find("Manage").GetComponent<Manage>();
      
        
        transform.SetParent(GameObject.Find("Canvas").transform, false);
        transform.localScale = Vector3.one;

      


        if (Levelscore != null)
        {
            Levelscore.text = "Score : " + (int)Manage.Score;

        }
        if (Bestlevelscore != null)
        {
            Bestlevelscore.text = "Best Score : " + (int)Manage.Bestscore;

        }
        if (Jumpscore != null)
        {
            Jumpscore.text = "Jump Score : " + (int)Manage.Jumpscore;

        }
        if (Bestjumpscore != null)
        {
            Bestjumpscore.text = "Best Jump Score : " + (int)Manage.Bestjumpscore;

        }

        if (Coinscore != null)
        {
            Coinscore.text = "Coin Score : " + (int)Manage.Coin;

        }

        if (Showselectsshopmenu == true)
        {
            Showselectplayer();
            Showselectcaps();
            Showselectsunglass();

        }
        if (Checkshop == true)
        {
            showshopmenu();
        }
    }

    public void Showscore()
    {
        if (Manage == null)
        {
            Manage = GameObject.Find("Manage").GetComponent<Manage>();
        }
        if (Levelscore != null)
        {
            Levelscore.text = "Score : " + (int)Manage.Score;

        }
        if (Bestlevelscore != null)
        {
            Bestlevelscore.text = "Best Level Score : " + (int)Manage.Bestscore;

        }
        if (Jumpscore != null)
        {
            Jumpscore.text = "Jump Score : " + (int)Manage.Jumpscore;

        }
        if (Bestjumpscore != null)
        {
            Bestjumpscore.text = "Best Jump Score : " + (int)Manage.Bestjumpscore;

        }

        if (Coinscore != null)
        {
            Coinscore.text = "Coin Score : " + (int)Manage.Coin;

        }
    }
    public void Showselectplayer()
    {
       
            Playerimage[0].SetActive(false);
            Playerimage[1].SetActive(false);
            Playerimage[2].SetActive(false);
            Playerimage[3].SetActive(false);
            Playerimage[Manage.Playernumber-1].SetActive(true);

        Selectplayers[0].SetActive(false);
        Selectplayers[1].SetActive(false);
        Selectplayers[2].SetActive(false);
        Selectplayers[3].SetActive(false);
        Selectplayers[Manage.Playernumber - 1].SetActive(true);
       
    }
    public void Showselectcaps()
    {
        Caps[0].SetActive(false);
        Caps[1].SetActive(false);
        Caps[2].SetActive(false);
        Caps[3].SetActive(false);
        Caps[4].SetActive(false);
        Caps[5].SetActive(false);
        Caps[6].SetActive(false);
        Caps[7].SetActive(false);
        Caps[8].SetActive(false);
        Caps[9].SetActive(false);
        Caps[10].SetActive(false);
        Caps[11].SetActive(false);
        Caps[12].SetActive(false);
        Caps[13].SetActive(false);
        Caps[14].SetActive(false);
        Caps[15].SetActive(false);
        Caps[16].SetActive(false);
        Caps[17].SetActive(false);
        Caps[18].SetActive(false);
        Caps[Manage.Cap].SetActive(true);

        Selectcap[0].SetActive(false);
        Selectcap[1].SetActive(false);
        Selectcap[2].SetActive(false);
        Selectcap[3].SetActive(false);
        Selectcap[4].SetActive(false);
        Selectcap[5].SetActive(false);
        Selectcap[6].SetActive(false);
        Selectcap[7].SetActive(false);
        Selectcap[8].SetActive(false);
        Selectcap[9].SetActive(false);
        Selectcap[10].SetActive(false);
        Selectcap[11].SetActive(false);
        Selectcap[12].SetActive(false);
        Selectcap[13].SetActive(false);
        Selectcap[14].SetActive(false);
        Selectcap[15].SetActive(false);
        Selectcap[16].SetActive(false);
        Selectcap[17].SetActive(false);
        Selectcap[18].SetActive(false);
        Selectcap[Manage.Cap].SetActive(true);


    }
  





    public void ShowCoins()
    {
        Coinscore.text = "Coin Score : " + (int)Manage.Coin;
    }
    // Update is called once per frame
    void Update()
    {
   
    }
}
