using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour {
    public GameObject attackEffect;
    private Character character;

    private void Start()
    {
        character = transform.parent.GetComponent<Character>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (character.isAttack && collision.CompareTag("Monster"))
        {
            int i;
            for (i = 0; i < character.monsters.Count; i++)
            {
                if (character.monsters[i].gameObject == collision.gameObject)
                {
                    return;
                }
            }
            Debug.Log(i);
            character.monsters.Add(collision.GetComponent<KimMonster.Monster>());
            //collision.GetComponent<KimMonster.Monster>().Hurt(character, (int)(character.attackDamage));
            Instantiate(attackEffect, collision.transform.position, Quaternion.identity);
            collision.GetComponent<KimMonster.Monster>().Hp -= 50;
            if (collision.GetComponent<KimMonster.Monster>().Hp <= 0)
                Destroy(collision.gameObject);
        }
    }
}       

//