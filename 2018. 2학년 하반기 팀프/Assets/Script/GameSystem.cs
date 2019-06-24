using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour {
    public bool isBox;
    public GameObject messageBox;
    public Character character;

    private void Awake()
    {
        character = GameObject.Find("Player").GetComponent<Character>();
    }

    void Update () {
        if (character.health <= 0)
        {
            messageBox.SetActive(true);
            Time.timeScale = 0;
        }
	}
}