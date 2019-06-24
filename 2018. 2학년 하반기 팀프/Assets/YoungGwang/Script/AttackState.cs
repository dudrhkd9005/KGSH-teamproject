using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace KimMonster
{
    public interface AttackMState
    {
        AttackMState Action(AttackMonster monster);
        void Update(AttackMonster monster);
    }

    public class AtState
    {
        public static At_IdleState idleState = new At_IdleState();
        public static At_MoveState moveState = new At_MoveState();
        public static At_AttackedState attackState = new At_AttackedState();
        public static At_HurtState hurtState = new At_HurtState();
    }
    public class At_IdleState : AttackMState
    {
        public AttackMState Action(AttackMonster monster)
        {
            if (monster.bIsMoveTo && !monster.bIsAttack)
            {
                return AtState.moveState;
            }
            return null;
            
        }
        public void Update(AttackMonster monster)
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

    public class At_MoveState : AttackMState
    {
        public AttackMState Action(AttackMonster monster)
        {
            float AttackDistance = Vector2.Distance(monster.Player.transform.position, monster.transform.position);
            if (AttackDistance <= 2)
            {
                monster.bIsAttack = true;
                monster.StartCoroutine("MoveStop");
                return AtState.attackState;
            }
            else if (AttackDistance > (monster.TileScale * monster.nTile) / 31)
            {
                monster.FirstPos = monster.gameObject.transform.position;
                monster.bIsMoveTo = false;
                return AtState.idleState;
            }
            return null;
        }
        public void Update(AttackMonster monster)
        {
            Debug.Log("gogogoggol");
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

    public class At_AttackedState : AttackMState
    {
        public AttackMState Action(AttackMonster monster)
        {
            return null;
        }

        public void Update(AttackMonster monster)
        {

        }
    }

    public class At_HurtState : AttackMState
    {
        public AttackMState Action(AttackMonster monster)
        {
            return null;
        }

        public void Update(AttackMonster monster)
        {
           
        }
    }
}