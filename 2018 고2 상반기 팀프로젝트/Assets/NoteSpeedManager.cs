using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpeedManager : MonoBehaviour
{
    public SpriteNumber spriteNumber;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = GameManager.Instance.GetSpeed();
        spriteNumber.value = (int)speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpSpeed()
    {
        speed++;
        spriteNumber.value = (int)speed;
        GameManager.Instance.SetSpeed(speed);
    }

    public void DownSpeed()
    {
        if (speed > 1)
        {
            speed--;
            spriteNumber.value = (int)speed;
            GameManager.Instance.SetSpeed(speed);
        }
    }
}
