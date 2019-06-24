using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace KimMonster
{
    public class Boss : MonoBehaviour
    {
        protected float Hp, MaxHp, nFillHp, damage, moveSpeed; // 몬스터 체력, 체력바Hp, 데미지, 보스 기본 이동 속도(변하지 않는값)
        protected GameObject Player; // 감지할 플레이어(마인드컨트롤 쓸거면 배열로바꿔주세용)
        protected bool bIsMoveTo, bIsAttack; // 이동과 공격상태를 구별하기위한 bool값
        protected Animator BossAnim; // 각 몬스터 애니메이터
        public const int TileScale = 64; // 가져올 타일크기(고정)
        //protected float Speed; // 기본 AI(대기상태)때 쓰는 속도(변하는 값)
        protected Vector2 Firstpos; // 몬스터의 맨 처믕포지션을 가져옴
        protected Vector2 mScale; // 몬스터 크기가져옴

        public virtual void Hurt(){ } //타격
        public virtual void Move(){ } //이동 
        public void BackMove(Collider2D collision, float force)
        {
            Vector2 PushDirection = collision.transform.position - transform.position;

            PushDirection = -PushDirection.normalized;
            
            GetComponent<Rigidbody2D>().AddForce(PushDirection * force * 100);
        }// 뒤로이동
        public virtual IEnumerator Attack() { yield return new WaitForSeconds(0); }//공격
        public virtual IEnumerator MoveStop() { yield return new WaitForSeconds(0); } // 공격 범위(즉 공격사정거리에 플레이어가오면 멈춘후 Attack()함수로들어감)
        public virtual Vector2 FirstPos()
        {
            return transform.position;
        }

        public void Init()
        {
            Player = GameObject.Find("Player");
            BossAnim = gameObject.GetComponent<Animator>();
            bIsMoveTo = false;
            bIsAttack = false;
            Firstpos = FirstPos();
        }
    }
}