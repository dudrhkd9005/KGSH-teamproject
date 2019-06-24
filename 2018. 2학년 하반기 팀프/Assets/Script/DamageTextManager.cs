using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageTextManager : MonoBehaviour {

    public GameObject damageText;
    private static DamageTextManager instance;
    public static DamageTextManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<DamageTextManager>();
            return instance;
        }
    }
    public void SetText(Vector2 vector,int damage)
    {
        GameObject text= Instantiate(damageText, transform);
        text.GetComponentInChildren<Text>().text = damage.ToString();
        text.GetComponent<RectTransform>().position = vector;
    }
}
