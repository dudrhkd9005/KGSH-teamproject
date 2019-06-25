using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delScripts : MonoBehaviour
{

    ParticleSystem thisPs;
    // Use this for initialization
    void Start()
    {
        thisPs = GetComponent<ParticleSystem>();

    }

    // Update is called once per frame
    void Update()
    {
        if(thisPs)
        {
            if(!thisPs.IsAlive())
            {
                Destroy(this.gameObject);
            }
        }

    }
}
