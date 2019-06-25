using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveRL : MonoBehaviour
{
    public SnapScrolling snapScrolling;
    public Transform con;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveR()
    {
        con.transform.localPosition -= new Vector3(400f,0);

    }
    public void MoveL()
    {
        con.transform.localPosition += new Vector3(400f, 0);

    }
}
