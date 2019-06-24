using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KimMonster
{
    public abstract class Monster : MonoBehaviour
    {
        public int Hp, MaxHp, Damage, nFillHp; // 몬스터 체력, 데미지, 체력바Hp
        public float moveSpeed; // 몬스터 기본 이동 속도(변하지 않는값)
        public GameObject Player; // 감지할 플레이어(마인드컨트롤 쓸거면 배열로바꿔주세용)
        public bool bIsMoveTo, bIsAttack; // 이동과 공격상태를 구별하기위한 bool값
        public Animator MonsterAnim; // 각 몬스터 애니메이터
        public /*const*/ int TileScale = 64; // 가져올 타일크기(고정)
        public /*const*/ int nTile = 25; // 플레이어와 몬스터가 얼마만큼의 타일갯수만큼 떨어져있는지 확인할때쓰임(고정)
        public float Speed; // 기본 AI(대기상태)때 쓰는 속도(변하는 값)
        public Vector2 FirstPos; // 몬스터의 맨 처믕포지션을 가져옴
        public Vector2 mScale; // 몬스터 크기가져옴
        public new Rigidbody2D rigidbody;
        public bool isHurt;

        public float raycastMaxDistance; // Raycast의 Distance값
        public float originOffset; // Raycast Offset값
        public Vector3 distance; // 플레이어와 몬스터의 거리

        public RaycastHit2D[] hit = new RaycastHit2D[11]; // 뻗어나가는 Raycast들
        public Vector2[] direction = new Vector2[11]; // Racast의 방향
        public float ndirectionX = 1, ndirectionY = 0.5f, PNnum = 0.1f; //SetDirection함수 사용변수

        public abstract RaycastHit2D CheckRaycast(Vector2 direction); // RayCast 함수
        public abstract IEnumerator Attack(); //공격
        public abstract IEnumerator MoveStop(); // 공격 범위(즉 공격사정거리에 플레이어가오면 멈춘후 Attack()함수로들어감)
        public void SetDirection()// 위의 Racast의 방향 값세팅
        {
            for (int i = 0; i < 11; i++)
            {
                direction[i].x = ndirectionX;
                direction[i].y = ndirectionY;
                if (i != 4)
                    ndirectionY -= PNnum;
                else
                    ndirectionY = 0;
            }
        }
        public void Init()
        {
            FirstPos = gameObject.transform.position;
            Player = GameObject.Find("Player");
            MonsterAnim = gameObject.GetComponent<Animator>();
            rigidbody = GetComponent<Rigidbody2D>();
            originOffset = 1f;
            raycastMaxDistance = 5f;
            bIsMoveTo = false;
            bIsAttack = false;
            SetDirection();
        }
        public void BackMove(Collider2D collision, float force)
        {
            Vector2 PushDirection = collision.transform.position - transform.position;

            PushDirection = -PushDirection.normalized;

            GetComponent<Rigidbody2D>().AddForce(PushDirection * force * 100);
        }// 뒤로이
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player")&&!collision.gameObject.GetComponent<Character>().isGuardian)
            {
                collision.gameObject.GetComponent<Character>().state = State.hurtState;
                collision.gameObject.GetComponent<Character>().health -= 10;
                Debug.Log(collision.gameObject.GetComponent<Character>().health);
            }   
        }

        public bool IsHurt()
        {
            return isHurt;
        }
    }
}