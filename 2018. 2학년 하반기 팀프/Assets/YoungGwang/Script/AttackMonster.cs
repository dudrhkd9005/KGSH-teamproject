using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace KimMonster
{
    public class AttackMonster : Monster
    {
        private GameObject AttackBox; // 공격 범위(Collider)
        public AttackMState atState;
        private void Start()
        {
            moveSpeed = 4;
            Damage = 70;
            MaxHp = 150;
            Hp = MaxHp;
            Speed = 4;
            Init();
            AttackBox = GameObject.Find("AttackBox");
            atState = AtState.idleState;
        }
        private void Update()
        {
            AttackMState now = atState.Action(this);
            if (now != null)
                atState = now;
            atState.Update(this);
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
            bIsAttack = false;
            StartCoroutine("Attack");
            yield return new WaitForSeconds(1f);
        }

        public override IEnumerator Attack()
        {
            MonsterAnim.SetTrigger("Attack");

            rigidbody.velocity = Vector2.zero;
            yield return new WaitForSeconds(0.5f);
            atState = AtState.moveState;
        }

        public IEnumerator Remove()
        {
            Debug.Log("ReRE");
            yield return new WaitForSeconds(1.0f);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Attack"))
            {
                StopAllCoroutines();
                StartCoroutine(Remove());
                atState = AtState.moveState;
                isHurt = true;
                BackMove(collision, 4);
                Debug.Log(Hp);
            }
        }
    }
}