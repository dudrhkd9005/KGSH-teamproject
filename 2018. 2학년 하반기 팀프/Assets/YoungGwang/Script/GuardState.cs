using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace KimMonster
{
    public interface GuardMState
    {
        GuardMState Action(GuardMonster monster);
        void Update(GuardMonster monster);
    }

    public class GdState
    {
        public static Gd_IdleState idleState = new Gd_IdleState();
        public static Gd_MoveState moveState = new Gd_MoveState();
        public static Gd_SummonState attackState = new Gd_SummonState();
        public static Gd_HurtState hurtState = new Gd_HurtState();
    }
    public class Gd_IdleState : GuardMState
    {
        public GuardMState Action(GuardMonster monster)
        {
            if (monster.bIsMoveTo && !monster.bIsAttack)
            {
                return GdState.moveState;
            }
            return null;

        }
        public void Update(GuardMonster monster)
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

    public class Gd_MoveState : GuardMState
    {
        public GuardMState Action(GuardMonster monster)
        {
            float AttackDistance = Vector2.Distance(monster.Siren[monster.min_SirenPosition()].transform.position, monster.transform.position);
            if (AttackDistance <= 1)
            {
                monster.bIsAttack = true;
                monster.moveSpeed = 0;
                monster.Speed = 0;
                monster.StartCoroutine("MoveStop");
                return GdState.attackState;
            }
            else if (AttackDistance > (monster.TileScale * monster.nTile) / 31)
            {
                monster.FirstPos = monster.gameObject.transform.position;
                monster.bIsMoveTo = false;
                return GdState.idleState;
            }
            return null;
        }
        public void Update(GuardMonster monster)
        {
            monster.distance = (monster.Siren[monster.min_SirenPosition()].transform.position - monster.transform.position).normalized;
            monster.rigidbody.velocity = (monster.distance * monster.moveSpeed);

            monster.mScale = new Vector2(Mathf.Abs(monster.gameObject.transform.localScale.x), monster.gameObject.transform.localScale.y);
            float GuardDistance = Vector2.Distance(monster.Siren[monster.min_SirenPosition()].transform.position, monster.transform.position);

            if (monster.Siren[monster.min_SirenPosition()].transform.position.x > monster.transform.position.x)
            {
                monster.gameObject.transform.localScale = new Vector2(monster.mScale.x, monster.mScale.y);
            }
            else if (monster.Siren[monster.min_SirenPosition()].transform.position.x < monster.transform.position.x)
            {
                monster.gameObject.transform.localScale = new Vector2(-monster.mScale.x, monster.mScale.y);
            }
        }
    }

    public class Gd_SummonState : GuardMState
    {
        public GuardMState Action(GuardMonster monster)
        {
            return null;
        }

        public void Update(GuardMonster monster)
        {

        }
    }

    public class Gd_HurtState : GuardMState
    {
        public GuardMState Action(GuardMonster monster)
        {
            return null;
        }

        public void Update(GuardMonster monster)
        {

        }
    }
}