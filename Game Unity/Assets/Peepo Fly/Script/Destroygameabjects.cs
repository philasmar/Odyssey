using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroygameabjects : MonoBehaviour
{
    public float Destroythis;
   
    private AudioSource Audio;
    private Manage Manage;
    private GameObject Cam;
    public bool Destroyprefab;
    // Start is called before the first frame update
    void Start()
    {
        Manage = GameObject.Find("Manage").GetComponent<Manage>();
        Cam = GameObject.Find("Main Camera");
       

        if (Destroythis > 0)
        {
            StartCoroutine(Dest());
        }

    }
    IEnumerator Dest()
    {
        yield return new WaitForSeconds(Destroythis);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= Cam.transform.position.y - 12)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Jump")
        {
            if (transform.position.y > coll.transform.position.y&& Destroyprefab==true)
            {
                Destroy(coll.gameObject);
            }
        }
    }
}
