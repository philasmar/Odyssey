using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float Speed;
    public bool Hummer;
    void Start()
    {
        if (Hummer == true)
        {
            if (transform.position.x < 0)
            {
                Speed = -360;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles += new Vector3(0, 0, Speed * Time.deltaTime);
    }
}
