using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace KimMonster
{
    public class TotemSphare : MonoBehaviour
    {
        Transform myTransform;
        public float damage;
        public float moveSpeed;
        public float Angle;
        public bool isLive;
        public bool isfire;
        Vector2 targetPos;
        private int nNormal;
        public GameObject Line;
        LineRenderer lineRenderer;
        // Use this for initialization
        void Start()
        {
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

        public void MoveSphare(Vector2 _startPos, Vector2 _targetPos, float _fireAngle, float _fireSpeed)
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
            Vector3 FirstPlayerPos = PlayerTransform.position;
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
                angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
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
    }
}