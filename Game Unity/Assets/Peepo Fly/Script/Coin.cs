using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private bool Move;
    private CircleCollider2D Collider;
    private GameObject Cam;
    private Manage Manage;
    public GameObject Target;
    private Barlife Showcoinscore;
    private AudioSource Coinaudio;
    // Start is called before the first frame update
    void Start()
    {
        Manage = GameObject.Find("Manage").GetComponent<Manage>();
        Coinaudio= GameObject.Find("Coinaudio").GetComponent<AudioSource>();
        Collider = GetComponent<CircleCollider2D>();
        Cam = GameObject.Find("Main Camera");
        Target= GameObject.Find("Barlife");
        Showcoinscore= GameObject.Find("Barlife").GetComponent<Barlife>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Move == true)
        {
            transform.position = Vector3.Lerp(transform.position, transform.position = new Vector3(Target.transform.position.x, Target.transform.position.y-1f, 0), Time.deltaTime * 4f);
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player") {
            if (Manage.Sound == 0) { Coinaudio.Play(); }
            Collider.enabled = false;
            transform.parent = Cam.transform;
            transform.localScale = new Vector3(1.2f, 1.2f, 1);
            Move = true;
            StartCoroutine(Destroycoin());

           
        }
    }

    IEnumerator Destroycoin()
    {
        yield return new WaitForSeconds(0.6f);
        Manage.Coin += 1;
        Showcoinscore.ShowCoinscore();
        Destroy(gameObject);
    }
}
