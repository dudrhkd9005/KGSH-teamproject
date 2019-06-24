    using System.Collections.Generic;
    using System.Collections;
    using System.IO.Ports;
    using UnityEngine;
    public enum PressButton
    {
        Press_X,
        Press_Y,
        Press_A,
        Press_B,

    }


    public class GameController : MonoBehaviour {
        SerialPort serial ;
        public Character entity;
        Dictionary<PressButton, int> pressButton;
        public int health;
        public int mana;
        public float horizontal;
        public float vertical;

        private void Awake()
        {
            try
            {
                //포트이름,포트 넘버
                serial = new SerialPort("COM7", 9600);
                serial.Open();
                if (serial.IsOpen)
                {
                    pressButton = new Dictionary<PressButton, int>();

                    DontDestroyOnLoad(gameObject);
                    for (int i = 0; i < 4; i++)
                    {
                        pressButton.ContainsKey(PressButton.Press_X + i);
                    }
                }   
                else
                    Debug.Log("Fail");
            }
            catch (System.Exception e)
            {
                Debug.Log(e);
            }
        }
        private void Update()
        {

            health = entity.GetComponent<Character>().health;

            if (Input.GetKeyDown(KeyCode.B))
            {
             //   Debug.Log(health.ToString() + "," + mana.ToString());
                serial.Write(health.ToString()+","+ mana.ToString());
            }
            else if(Input.GetKeyDown(KeyCode.C))
                StartCoroutine(ReadDataFromSerialPort());
        }
        IEnumerator ReadDataFromSerialPort()
        {
            while (true)
            {
            
                yield return new WaitForSeconds(0.1f);

                int values = serial.ReadByte();
                Debug.Log(values);
                //    horizontal = (float.Parse(values[0]));
                //    vertical = (float.Parse(values[1]));
                //    for (int i = 0; i < 4; i++)
                //    {
                //        //때면 -1 안누르면 0 누르는 순간 1
                //        pressButton[PressButton.Press_X + i] = int.Parse(values[i + 2]);
                //    }
                //    Debug.Log(string.Format("Joy {0},{1}", horizontal, vertical));
                //    Debug.Log(string.Format("Button {0},{1},{2},{3}", values[2], values[3], values[4], values[5]));
                //}
            }
        }

    }
