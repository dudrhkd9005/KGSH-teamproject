using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace KimMonster
{
    public class Sphere : MonoBehaviour
    {
        Transform myTransform;
        public float damage;
        public float moveSpeed;
        public float Angle;
        public bool isLive;
        public bool isfire;
        public GameObject Line;
        LineRenderer lineRenderer;
        Vector2 targetPos;
        private int nNormal;
        Stage1Boss stage1Boss;
        public Color a = new Color(255, 0, 255);
        // Use this for initialization
        void Start()
        {
            stage1Boss = GameObject.Find("HiddenBoss(horse)").GetComponent<Stage1Boss>();
            lineRenderer = Line.GetComponent<LineRenderer>();
            nNormal = 0;
            moveSpeed = 10;
            isfire = true;
            StartCoroutine(Attack());
        }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
        // Update is called once per frame
        void Update()
        {
            if (!isfire)
                StartCoroutine(DelayAttack());
        }

        private void FixedUpdate()
        {
            if (isfire)
                transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.fixedDeltaTime);
        }

        public void MoveSphare(Vector2 _startPos,Vector2 _targetPos, float _fireAngle, float _fireSpeed)
        {
            gameObject.SetActive(true);
            myTransform = transform;
            myTransform.position = _startPos;
            targetPos = _targetPos;
            myTransform.rotation = Quaternion.Euler(0, 0, _fireAngle);
            Angle = _fireAngle;
            moveSpeed = _fireSpeed;
            isLive = true;
        }

        public IEnumerator Attack()
        {
            Transform PlayerTransform = GameObject.Find("Player").GetComponent<Transform>();
            Vector2 FirstPlayerPos = PlayerTransform.position;
            Vector2 FirstSpharePos = transform.position;
            Line.transform.position = FirstSpharePos;
            lineRenderer.SetPosition(0, new Vector3(FirstSpharePos.x, FirstSpharePos.y, -1));
            lineRenderer.SetPosition(1, new Vector3(FirstPlayerPos.x, FirstPlayerPos.y, -1));
            GameObject L = Instantiate(Line);
            yield return new WaitForSeconds(0.5f);
            Destroy(L);
            while (isfire)
            {
                float angle;
                Vector3 v = PlayerTransform.position - transform.position;
                angle = 
                    Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
                switch (nNormal)
                {
                    case 0:
                        MoveSphare(transform.position, FirstPlayerPos, angle, 30);
                        break;
                }
                yield return new WaitForSeconds(1);
                isfire = false;
            }
        }

        public IEnumerator DelayAttack()
        {
            isfire = true;
            yield return new WaitForSeconds(1.5f);
            StartCoroutine(Attack());
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            for(int i = 0; i < 4; i++)
            {
                if (collision.gameObject.CompareTag("Sphare" + (i + 1).ToString()))
                {
                    stage1Boss.ColorAni[i].SetTrigger("Trigger");
                    stage1Boss.nTrigger[i] += 1;
                }
            }
        }
    }
}