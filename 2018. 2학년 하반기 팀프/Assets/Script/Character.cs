using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Character : MonoBehaviour
{
    
    public float moveSpeed;
    public bool isAttack;
    public float attackDamage;
    public float attackSpeed;
    public int maxHealth;
    public int health;
    public float maxRecoveryHealth;
    public float recoveryHealth;
    public bool isDash;
    public float dashPower;

    public bool isGuardian;
    public float guardianTime;
    public float GuardianTime
    {
        get { return guardianTime; }
        set { guardianTime = value; }
    }
    public CharacterState state;
    public Image hpBar;
    public List<KimMonster.Monster> monsters;
    public List<int> texture2s;
    private void Awake()
    {
        //hpBar = GameObject.Find("hpBar_1").GetComponent<Image>();
    }
    private void Start()
    {
        moveSpeed = 3;
        attackSpeed = 1;
        
        maxHealth= health = 100;
        attackDamage = 45;

        state = State.idleState;

    }
    public  RaycastHit2D CheckRaycast(Vector2 direction)
    {
        float directionOriginOffset = 1 * (direction.x > 0 ? 1 : -1);

        Vector2 startingPostion = new Vector2(transform.position.x + directionOriginOffset, transform.position.y);

        return Physics2D.Raycast(startingPostion, direction, 5.0f);
    }
    private void Update()
    {
        //transform.GetChild(1).gameObject.SetActive();
        transform.GetChild(1).gameObject.SetActive(state == State.dashState);

        CharacterState nowState =state.HandleInput(this);
        if (nowState != null)
            state = nowState;
        state.Update(this);
        guardianTime -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.E))
            TimePause.Instance.IsTimePause = !TimePause.Instance.IsTimePause;
        if (Input.GetKeyDown(KeyCode.R))
        {
            Vector3 direction = new Vector2(GetComponent<Animator>().GetFloat("Direction_X"), GetComponent<Animator>().GetFloat("Direction_Y")).normalized;
            RaycastHit2D a= CheckRaycast(direction);
            if (a.collider != null)
                Debug.Log(a.transform.gameObject.tag);
            else
                transform.Translate(direction * 0.64f * 3);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.gameObject.CompareTag("Monster") || collision.gameObject.CompareTag("MonsterAttack")) && guardianTime<=0)
        {
            state = State.hurtState;
            state.Update(this);
            health -= 10;
            Debug.Log("Player Health"+health.ToString());
        }
    }

}