using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KimMonster
{
    public class BulletManager : MonoBehaviour
    {
        public List<BangBullet> Lbullet;
        public GameObject[] bulletOrgin;
        public Transform Bullets;

        void Start()
        {
            Lbullet = new List<BangBullet>();
        }
        public void BangBullets(Vector2 _startPos, float _fireAngle, float _fireSpeed)
        {
            bool fireSurcess = false;
            for (int i = 0; i < Lbullet.Count; i++)
            {
                if (!Lbullet[i].isLive)
                {   
                    Lbullet[i].FireBullet(_startPos, _fireAngle, _fireSpeed);
                    return;
                }
            }
            if (!fireSurcess)
            {
                BangBullet curentBullet = Instantiate(bulletOrgin[0], Bullets).GetComponent<BangBullet>();
                Lbullet.Add(curentBullet);

                Lbullet[Lbullet.Count - 1].FireBullet(_startPos, _fireAngle, _fireSpeed);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}