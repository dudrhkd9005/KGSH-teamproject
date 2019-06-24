using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface CharacterState
{

    CharacterState HandleInput(Character character);
    void Update(Character character);
    
}
public class State
{
    public static CharacterIdleState idleState = new CharacterIdleState();
    public static CharacterMoveState moveState = new CharacterMoveState();
    public static CharacterAttackState attackState = new CharacterAttackState();
    public static CharacterSkillState skillState = new CharacterSkillState();
    public static CharacterHurtState hurtState = new CharacterHurtState();
    public static CharacterDashState dashState = new CharacterDashState();
}


public class CharacterIdleState : CharacterState
{

    public CharacterState HandleInput(Character character)
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            return State.moveState;
        if (Input.GetMouseButtonDown(0))
            return State.attackState;
        if (Input.GetKeyDown(KeyCode.Space))
            return State.dashState;
        return null;
    }
    public void Update(Character character)
    {
        Animator animator = character.GetComponent<Animator>();
        Rigidbody2D rigidbody = character.GetComponent<Rigidbody2D>();
        rigidbody.velocity = Vector2.zero;
        animator.SetBool("Work", false);
    }
}

public class CharacterMoveState : CharacterState
{

    public CharacterState HandleInput(Character character)
    {
        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (direction.x == 0 && direction.y== 0)
            return State.idleState;
        if (Input.GetMouseButtonDown(0))
            return State.attackState;
        if (Input.GetKeyDown(KeyCode.Space))
            return State.dashState;
        return null;
    }
    public void Update(Character character)
    {
        Animator animator = character.GetComponent<Animator>();
        Rigidbody2D rigidbody = character.GetComponent<Rigidbody2D>();
        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        animator.SetFloat("Direction_X", direction.x);
        animator.SetFloat("Direction_Y", direction.y);
        animator.SetBool("Work", true);
        rigidbody.velocity = direction * character.moveSpeed;
    }
}

public class CharacterAttackState : CharacterState
{

    public CharacterState HandleInput(Character character)
    {
        if (character.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            Animator animator = character.GetComponent<Animator>();
            character.isAttack = false;
            animator.speed = 1;
            character.monsters.Clear();
            return State.idleState;
        }
        return null;
    }
    public void Update(Character character)
    { 
        if (!character.isAttack)
        {
            Rigidbody2D rigidbody = character.GetComponent<Rigidbody2D>();
            Animator animator = character.GetComponent<Animator>();
            rigidbody.velocity = Vector2.zero;
            animator.SetTrigger("Attack");
            animator.speed = character.attackSpeed;
            character.isAttack = true;
            float angle = Mathf.Atan2(0 - animator.GetFloat("Direction_Y"), 0 - animator.GetFloat("Direction_X")) * Mathf.Rad2Deg;

            character.transform.GetChild(0).localEulerAngles = new Vector3(0,0,angle );
            //SoundManager.Instance.PlayEffectSound("swing");
            
        }
    }
}

public class CharacterSkillState : CharacterState
{
    public CharacterState HandleInput(Character character)
    {
        return null;
    }
    public void Update(Character character)
    {

    }
}

public class CharacterHurtState : CharacterState
{

    public CharacterState HandleInput(Character character)
    {
        if (character.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            return State.idleState;
        }
        return null;
    }
    public void Update(Character character)
    {
        if (character.GuardianTime<=0)
        {
            Animator animator = character.GetComponent<Animator>();
            Rigidbody2D rigidbody = character.GetComponent<Rigidbody2D>();
            animator.SetTrigger("Hurt");
            rigidbody.velocity = Vector2.zero;
            character.GuardianTime = 1.0f; 
            character.isAttack = false;
            character.monsters.Clear();

        }
    }
}
public class CharacterDashState : CharacterState
{

    public CharacterState HandleInput(Character character)
    {
   
        if (character.dashPower==0)
        {
            character.isDash = false;
            return State.idleState;
        }
            return null;
    }
    public void Update(Character character)
    {
        character.transform.GetChild(1).GetComponent<ParticleSystemRenderer>().material.mainTexture = character.GetComponent<SpriteRenderer>().sprite.texture;
        if (!character.isDash)
        {
            Animator animator = character.GetComponent<Animator>();
            character.isDash = true;
            character.dashPower = 1;
            animator.SetTrigger("Dash");

        }
        else
        {
            Animator animator = character.GetComponent<Animator>();
            Vector2 direction = new Vector2(animator.GetFloat("Direction_X"), animator.GetFloat("Direction_Y")).normalized;
            character.GetComponent<Rigidbody2D>().velocity = direction*character.dashPower*25;
            character.dashPower =Mathf.Max(character.dashPower -Time.deltaTime*2,0);

     
        }
    }
}
