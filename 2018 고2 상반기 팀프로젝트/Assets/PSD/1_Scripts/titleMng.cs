using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class titleMng : MonoBehaviour
{
    public GameObject _touch;
    public void EftAnim()
    {
        _touch.transform.GetChild(0).gameObject.SetActive(true);
        _touch.GetComponent<Button>().interactable = true;
            
    }
}
