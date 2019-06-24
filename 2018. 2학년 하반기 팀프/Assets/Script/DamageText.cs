using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageText : MonoBehaviour {
    float c = 0;
    float a = 1;
    private void Start()
    {
        StartCoroutine("Remove");
    }
    IEnumerator Remove()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
