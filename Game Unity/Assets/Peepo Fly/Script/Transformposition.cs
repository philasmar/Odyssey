using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformposition : MonoBehaviour
{
    public float SpeedUp;
    public float SpeedRight;
    public bool Changescale;
    private float Scale;
    public bool Cloud;
    // Start is called before the first frame update
    void Start()
    {
        if (Changescale == true)
        {
            Scale = Random.Range(0.8f, 2);
            transform.localScale = new Vector3(Scale, Scale, 0);
        }
        if (Cloud == true)
        {
            SpeedRight = Random.Range(0.5f, -0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(SpeedRight * Time.deltaTime, SpeedUp * Time.deltaTime, 0);

    }
}
