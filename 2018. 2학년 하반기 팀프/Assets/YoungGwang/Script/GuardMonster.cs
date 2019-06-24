using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace KimMonster
{
    public class GuardMonster : Monster
    {
        public GameObject[] Siren;
        public GameObject[] Monsters = new GameObject[2];
        private int nSiren;
        private bool push;
        public GuardMState guardMState;
        private void Start()
        {
            moveSpeed = 3;
            Damage = 30;
            MaxHp = 70;
            Hp = MaxHp;
            Speed = 3;
            nSiren = 3;
            Siren = new GameObject[nSiren];
            for (int i = 0; i < nSiren; i++)
            {
                Siren[i] = GameObject.Find("Siren" + (i + 1).ToString());
                //Debug.Log(Siren[i].name);
            }
            Init();
            guardMState = GdState.idleState;
        }
        private void Update()
        {
            GuardMState now = guardMState.Action(this);
            if (now != null)
                guardMState = now;
            guardMState.Update(this);
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

        public int min_SirenPosition()
        {
            float min_position;
            int minSiren;
            minSiren = 0;
            min_position = Vector2.Distance(Siren[0].transform.position, transform.position);
            for (int i = 1; i < nSiren; i++)
            {
                if (min_position > Vector2.Distance(Siren[i].transform.position, transform.position))
                {
                    min_position = Vector2.Distance(Siren[i].transform.position, transform.position);
                    minSiren = i;
                }
            }

            return minSiren;
        }

        public override IEnumerator MoveStop()
        {
            yield return new WaitForSeconds(1f);
            if (!push)
                StartCoroutine("Attack");
            bIsAttack = false;
        }

        public override IEnumerator Attack()
        {

            for (int i = 0; i < 3; i++)
            {
                Instantiate(Monsters[Random.Range(0, 2)]);

                float rPosX = Random.Range(Player.transform.position.x - 3, Player.transform.position.x + 3);
                float rPosY = Random.Range(Player.transform.position.y - 3, Player.transform.position.y + 3);
                Monsters[Random.Range(0, 1)].transform.position = new Vector2(rPosX, rPosY);
            }
            yield return new WaitForSeconds(1f);
            push = true;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Attack"))
            {
                guardMState = GdState.moveState;
                isHurt = true;
                BackMove(collision, 4);
            }
        }
    }
}