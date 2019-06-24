using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KimMonster
{
    public class HiddenBoss : MiniBoss
    {
        private float Time1, Time2;
        private bool IsHurt;

        private void Start()
        {
            Time1 = 0;
            Time2 = 0;
            moveSpeed = 4;
            damage = 0;
            MaxHp = 800;
            Hp = MaxHp;
            IsHurt = false;
            //Speed = 4;
            Init();
        }

        private void Update()
        {
            Stay();
        }

        public override void Stay()
        {
            if(IsHurt)//콜라이더 사용해서 타격맞앗을때
                Hurt();
        }

        public override void Hurt()
        {
            Timer();
        }

        private void Timer()
        {
            Time1 += Time.smoothDeltaTime;
            Time2 += Time.smoothDeltaTime;
            if (Time1 > 4 || Time2 > 1)
            {
                Debug.Log("Retry");
                transform.position = Firstpos;
                IsHurt = false;// 다시 콜라이더 맞기전 값
                Hp = MaxHp;
                Time1 = 0;
                Time2 = 0;
            }
        }

        public override IEnumerator MoveStop()
        {
            return base.MoveStop();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            //if (collision.gameObject.CompareTag("Player") && !collision.gameObject.GetComponent<Character>().IsGuardian)
            {
                //collision.gameObject.GetComponent<Character>().state = State.hurtState;
                //collision.gameObject.GetComponent<Character>().Health -= 10;
                //Debug.Log(collision.gameObject.GetComponent<Character>().Health);
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Attack"))
            {
                IsHurt = true;
                BackMove(collision, 4);
                Hp -= (int)collision.transform.parent.GetComponent<Character>().attackDamage;
                Debug.Log(Hp);
                Time2 = 0;
                if (Hp <= 0)
                    Destroy(gameObject);
            }
        }
    }
}