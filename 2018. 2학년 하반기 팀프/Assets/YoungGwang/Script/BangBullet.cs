using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace KimMonster
{
    public class BangBullet : MonoBehaviour
    {

        Transform myTransform;
        public float bulletSpeed;
        public float bulletAngle;
        public float bLiveTIme;
        public bool isLive;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void FixedUpdate()
        {
            if (isLive)
                myTransform.Translate(Vector2.right * bulletSpeed * Time.fixedDeltaTime);
        }
        public void FireBullet(Vector2 _startPos, float _fireAngle, float _fireSpeed)
        {
            gameObject.SetActive(true);
            myTransform = transform;
            myTransform.position = _startPos;
            myTransform.rotation = Quaternion.Euler(0, 0, _fireAngle);
            bulletAngle = _fireAngle;
            bulletSpeed = _fireSpeed;
            isLive = true;
            bLiveTIme = 5.0f;
            StartCoroutine(deadTimer());

        }
        IEnumerator deadTimer()
        {
            yield return new WaitForSeconds(bLiveTIme);

            gameObject.SetActive(false);
            isLive = false;
            //myTransform.transform.position = new Vector2(1000, 1000);
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                gameObject.SetActive(false);
                isLive = false;
            }
        }
    }
}