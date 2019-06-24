using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace KimMonster
{
    public interface BangMState
    {
        BangMState Action(BangMonster monster);
        void Update(BangMonster monster);
    }

    public class BaState
    {
        public static Ba_IdleState idleState = new Ba_IdleState();
        public static Ba_MoveState moveState = new Ba_MoveState();
        public static Ba_AttackedState attackState = new Ba_AttackedState();
        public static Ba_HurtState hurtState = new Ba_HurtState();
    }
    public class Ba_IdleState : BangMState
    {
        public BangMState Action(BangMonster monster)
        {
            if (monster.bIsMoveTo && !monster.bIsAttack)
            {
                return BaState.moveState;
            }
            return null;

        }
        public void Update(BangMonster monster)
        {
            if (!monster.bIsMoveTo)
            {
                monster.mScale = new Vector2(Mathf.Abs(monster.gameObject.transform.localScale.x), monster.gameObject.transform.localScale.y);
                monster.gameObject.transform.position = new Vector3(monster.transform.position.x + monster.Speed * Time.smoothDeltaTime, monster.transform.position.y, -0.1f);
                if (monster.gameObject.transform.position.x >= (monster.FirstPos.x + 3))
                {
                    monster.gameObject.transform.localScale = new Vector2(-monster.mScale.x, monster.mScale.y);
                    monster.Speed = -monster.Speed;
                }
                else if (monster.gameObject.transform.position.x <= (monster.FirstPos.x - 3))
                {
                    monster.gameObject.transform.localScale = new Vector2(monster.mScale.x, monster.mScale.y);
                    monster.Speed = -monster.Speed;
                }
            }
            if (!monster.bIsMoveTo)
            {

                for (int i = 0; i < 11; i++)
                {
                    if (monster.gameObject.transform.localScale.x <= -0.3f)
                        monster.hit[i] = monster.CheckRaycast(-monster.direction[i]);
                    else if (monster.gameObject.transform.localScale.x >= 0.3f)
                        monster.hit[i] = monster.CheckRaycast(monster.direction[i]);
                    if (monster.hit[i].collider != null && monster.hit[i].collider.gameObject.layer == 8)
                    {
                        //Debug.Log("Hit the " + hit[i].collider.name);

                        //Debug.DrawRay(transform.position, direction * 10f, Color.red, 3f);
                        Debug.DrawLine(monster.transform.position, monster.hit[i].point, Color.red, 3f);
                        monster.bIsMoveTo = true;
                    }
                }
            }
        }
    }

    public class Ba_MoveState : BangMState
    {
        public BangMState Action(BangMonster monster)
        {
            float AttackDistance = Vector2.Distance(monster.Player.transform.position, monster.transform.position);
            if (AttackDistance <= 4)
            {
                monster.bIsAttack = true;
                monster.StartCoroutine("MoveStop");
                return BaState.attackState;
            }
            else if (AttackDistance > (monster.TileScale * monster.nTile) / 31)
            {
                monster.FirstPos = monster.gameObject.transform.position;
                monster.bIsMoveTo = false;
                return BaState.idleState;
            }
            return null;
        }
        public void Update(BangMonster monster)
        {
            monster.distance = (monster.Player.transform.position - monster.transform.position).normalized;
            monster.rigidbody.velocity = (monster.distance * monster.moveSpeed);

            monster.mScale = new Vector2(Mathf.Abs(monster.gameObject.transform.localScale.x), monster.gameObject.transform.localScale.y);
            if (monster.Player.transform.position.x > monster.transform.position.x)
            {
                monster.gameObject.transform.localScale = new Vector2(monster.mScale.x, monster.mScale.y);
            }
            else if (monster.Player.transform.position.x < monster.transform.position.x)
            {
                monster.gameObject.transform.localScale = new Vector2(-monster.mScale.x, monster.mScale.y);
            }
        }
    }

    public class Ba_AttackedState : BangMState
    {
        public BangMState Action(BangMonster monster)
        {
            return null;
        }

        public void Update(BangMonster monster)
        {

        }
    }

    public class Ba_HurtState : BangMState
    {
        public BangMState Action(BangMonster monster)
        {
            return null;
        }

        public void Update(BangMonster monster)
        {

        }
    }
}