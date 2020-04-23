using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    private Manage Manage;
    private GameObject Target;
    private bool Moveup;
    // Start is called before the first frame update
    void Start()
    {
        Manage = GameObject.Find("Manage").GetComponent<Manage>();


     


    }

    // Update is called once per frame
    void Update()
    {
        if (Manage.Player != null && Target == null)
        {
            Target = Manage.Player;
        }
       else if (Target != null&& Manage.Player != null) { 

        if (Target.transform.position.y > transform.position.y)
            {
                Moveup = true;
            }
        else if (Target.transform.position.y < transform.position.y)
            {
                Moveup = false;
            }

            if (Moveup == true)
            {
                transform.position = Vector3.Lerp(transform.position, transform.position = new Vector3(0, Target.transform.position.y, transform.position.z), Time.deltaTime * 3.5f);

            }

        }
        else if (Manage.Player == null && Target == null)
        {
            Moveup = false;
        }
       
    }
}
