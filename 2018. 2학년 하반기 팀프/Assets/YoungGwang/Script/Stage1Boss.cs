using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace KimMonster
{
    public class Stage1Boss : Boss
    {
        public Sphere BossSphere;
        public Image FillHp;
        private bool isAttack;
        //public Totem[] miniMonster;
        public GameObject[] PlayerSphere = new GameObject[4];
        public GameObject[] Totem = new GameObject[4];
        public Text[] Sphare_T = new Text[4];
        public Animator[] ColorAni = new Animator[4];
        public int[] nTrigger = new int[4];
        float Timer1 = 0;
        public int BossPattern;
        // Use this for initialization
        void Start() {
            for (int i = 0; i < 4; i++)
                nTrigger[i] = 0;
            FillHp.fillAmount = 1;
            BossPattern = 1;
            Init();
            moveSpeed = 4;
            MaxHp = 600;
            damage = 45;
            Hp = MaxHp;
            BossSphere.damage = damage;
            BossSphere.moveSpeed = moveSpeed;
            StartCoroutine(Attack());
        }

        // Update is called once per frame
        void Update() {
            for (int i = 0; i < 4; i++)
                Sphare_T[i].text = nTrigger[i].ToString();
            nFillHp = Hp / MaxHp;
            FillHp.fillAmount = Hp / MaxHp;
            switch(BossPattern)
            {
                case 1:
                    int j = 0;
                    for (int i = 0; i < 4; i++)
                    {
                        if (nTrigger[i] == 1)
                        {
                            j++;
                        }
                    }
                    if(j == 4)
                    {
                        Hp -= 100;
                        BossSphere.isfire = false;
                        StartCoroutine(BossPattern2());
                        j = 0;
                    }
                    break;
                case 2:
                    int k = 0;
                    for (int i = 0; i < 4; i++)
                    {
                        if (nTrigger[i] == 2)
                        {
                            k++;
                        }
                    }
                    if (k == 4)
                    {
                        Hp -= 200;
                        BossSphere.isfire = false;
                        StartCoroutine(BossPattern3());
                    }
                    break;
                case 3:
                    break;
            }
        }

        public override void Move()
        {
            base.Move();
        }

        public override void Hurt()
        {
            base.Hurt();
        }
        public override IEnumerator Attack()
        {
            yield return new WaitForSeconds(1f);
            BossSphere.isfire = true;
            Instantiate(BossSphere.gameObject);
            yield return new WaitForSeconds(2f);
        }

        public override IEnumerator MoveStop()
        {
            return base.MoveStop();
        }

        public IEnumerator BossPattern2()
        {
            BossPattern = 2;
            yield return new WaitForSeconds(3);
            BossSphere.isfire = true;
            for (int i = 0; i < 4; i++)
                nTrigger[i] = 0;
            Instantiate(Totem[0]);
            yield return new WaitForSeconds(5);
            Instantiate(Totem[1]);
        }

        public IEnumerator BossPattern3()
        {
            BossPattern = 3;
            yield return new WaitForSeconds(3);
            Instantiate(Totem[0]);
            yield return new WaitForSeconds(5);
            Instantiate(Totem[1]);
        }

        public override Vector2 FirstPos()
        {
            return base.FirstPos();
        }

        private void AttackPattern1()
        {

        }
    }
}