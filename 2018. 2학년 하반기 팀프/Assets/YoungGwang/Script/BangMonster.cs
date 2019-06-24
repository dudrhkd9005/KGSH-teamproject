using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace KimMonster
{
    public class BangMonster : Monster
    {
        private bool isfire;
        private int nNormal;
        private BulletManager bulletMng;
        private Transform firePosition;
        public float bulletInterval;
        public BangMState bangMState;
        private void Start()
        {
            bulletMng = GameObject.Find("GameMng").GetComponent<BulletManager>();
            firePosition = gameObject.transform;
            moveSpeed = 6;
            Damage = 60;
            MaxHp = 100;
            Hp = MaxHp;
            isfire = true;
            nNormal = 0;
            Speed = 6;
            Init();
            bangMState = BaState.idleState;
        }
        private void Update()
        {
            BangMState now = bangMState.Action(this);
            if (now != null)
                bangMState = now;
            bangMState.Update(this);
        }
        private void FixedUpdate()
        {
        }

        public override RaycastHit2D CheckRaycast(Vector2 direction)
        {
            float directionOriginOffset = originOffset * (direction.x > 0 ? 1 : -1);

            Vector2 startingPostion = new Vector2(transform.position.x + directionOriginOffset, transform.position.y);

            return Physics2D.Raycast(startingPostion, direction, raycastMaxDistance);
        }

        public override IEnumerator MoveStop()
        {
            yield return new WaitForSeconds(1f);
            isfire = true;
            StartCoroutine("Attack");
            yield return new WaitForSeconds(0.5f);
            bIsAttack = false;
            bangMState = BaState.moveState;
        }

        private void LookPlayer()
        {

        }

        public override IEnumerator Attack()
        {
            Transform MonTrans = gameObject.GetComponent<Transform>();
            
            while (isfire)
            {
                float angle;
                Vector3 v = Player.transform.position - transform.position;
                angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;

                switch (nNormal)
                {
                    case 0:
                        bulletMng.BangBullets(firePosition.position, angle, 10);
                        break;
                }
                yield return new WaitForSeconds(bulletInterval);
                isfire = false;
            }
            //yield return new WaitForSeconds(1f);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Attack"))
            {
                bangMState = BaState.moveState;
                isHurt = true;
                BackMove(collision, 4);
            }
        }
    }
}