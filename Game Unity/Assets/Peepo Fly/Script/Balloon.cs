using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public GameObject Particle;
    public GameObject Loop;
    public float Speeddown;
    public GameObject Ten;
    private Rigidbody2D LoopRgb2d;
    private AudioSource Balloonaudio;
    private Manage Manage;
    void Start()
    {
        Manage = GameObject.Find("Manage").GetComponent<Manage>();
        LoopRgb2d = Loop.GetComponent<Rigidbody2D>();
        Balloonaudio = GameObject.Find("Balloonaudio").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       transform.position -= new Vector3(0, Speeddown * Time.deltaTime, 0);
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if (Manage.Sound == 0)
            {
                Balloonaudio.Play();
            }
                Instantiate(Particle, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            Instantiate(Ten, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            LoopRgb2d.gravityScale = 10;
            Destroy(gameObject);
            

        }
    }
}

