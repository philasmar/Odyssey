using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public GameObject Particle;
    public GameObject Scoreparticle;
    private Collider2D mycollider;
    private Manage Manage;
    private Animator Anim;
    public bool Jump;
    public float MoveRight;
    public float MoveUp;
    private AudioSource Birdaudio;
    // Start is called before the first frame update
    void Start()
    {
        Manage = GameObject.Find("Manage").GetComponent<Manage>();
        Birdaudio= GameObject.Find("Birdaudio" + (Random.Range(1, 4))).GetComponent<AudioSource>();

        mycollider = GetComponent<Collider2D>();
       
        if (GetComponent<Animator>() != null)
        {
            Anim = GetComponent<Animator>();
        }
        if (Jump == true)
        {
            if (transform.position.x <= 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            if (GetComponent<Animator>() != null) { 
            Anim.SetInteger("Bird", 1);
            }
            transform.GetComponent<Rigidbody2D>().velocity = new Vector3(MoveRight, MoveUp);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Manage.Player != null && mycollider.enabled==false&& Jump==false)
        {
            if (Manage.Player.transform.position.y >= transform.position.y )
            {
                mycollider.enabled = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player") {
            if (Particle != null && Scoreparticle != null) {
                if (Manage.Sound == 0) { Birdaudio.Play(); }
            Instantiate(Particle, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            Instantiate(Scoreparticle, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            Destroy(gameObject);
            }

        }
    }
}
