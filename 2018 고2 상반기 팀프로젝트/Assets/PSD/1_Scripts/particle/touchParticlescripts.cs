using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchParticlescripts : MonoBehaviour {

    //Transform thistran;
    public ParticleSystem TouchParticle_;
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        bcvdsfsafe();

    }

    void bcvdsfsafe()
    {
        if (Input.GetMouseButtonDown(0))
        {

          //  Debug.Log(Singleton.Instance.SongNum);
            Vector3 worldpos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, +10));
            Instantiate(TouchParticle_,worldpos,Quaternion.identity);
           // TouchParticle_.transform.position = new Vector3(worldpos.x, worldpos.y, 0);
        }
    }
}
