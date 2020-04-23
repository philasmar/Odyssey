using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Gamebuttons : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public Image Arrow;
    private Manage Manage;
    public bool Right;
    // Start is called before the first frame update
    void Start()
    {
        Manage = GameObject.Find("Manage").GetComponent<Manage>();
    }

    // Update is called once per frame
    void Update()
    {

    }
   
    public void OnPointerDown(PointerEventData eventData)
    {
        Arrow.color = new Color32(255, 255, 255, 150);
        if (Right == true)
        {
            Manage.Moveright = true;
        }
      else  if (Right == false)
        {
            Manage.Moveleft = true;
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        Arrow.color = new Color32(255, 255, 255, 255);
        Manage.Moveleft = false;
        Manage.Moveright = false;
    }


}
