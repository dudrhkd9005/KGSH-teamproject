using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace KimMonster
{
    public class Totem : MonoBehaviour
    {
        public TotemSphare SmallSphare;
        // Use this for initialization
        void Start()
        {
            StartCoroutine(InstanceBall());
        }

        // Update is called once per frame
        void Update()
        {

        }

        public IEnumerator InstanceBall()
        {
            yield return new WaitForSeconds(2);
            SmallSphare.isfire = true;
            GameObject Sphareball = Instantiate(SmallSphare.gameObject);
            Sphareball.transform.position = transform.position;
            Sphareball.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            yield return new WaitForSeconds(1);
        }
    }
}