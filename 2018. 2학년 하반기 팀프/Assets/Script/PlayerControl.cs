using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    Rigidbody2D body;
	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            body.velocity = new Vector3(0, -10);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            body.velocity = new Vector3(0, 10);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            body.velocity = new Vector3(-10, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            body.velocity = new Vector3(10,0);
        }
        else
        {

            body.velocity = new Vector3(0, 0);
            
        }
    }
}
