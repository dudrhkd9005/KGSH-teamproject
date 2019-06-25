using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stageSel : MonoBehaviour
{

    GameObject This_Stage;//선택된 스테이지

    public Transform cneterPos;
    bool isCon; //스테이지가 선택 여부
    public bool isSelStageMod;
    public bool Revert;
    //화면 이동
    Camera cam;
    public Transform Pos;
    public  float MoveSpeedacc;
    public GameObject SelUI; //선택했을때 ui
    public GameObject DselUI; //선택 안했를때
    // Use this for initialization
    void Start()
    {
        isCon = false;
        isSelStageMod = false;
        Revert = false;
        cam = GetComponent<Camera>();
        MoveSpeedacc = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        stagesle();

    }
    private void LateUpdate()
    {
        StageEffer();
        RevertStageSel();
    }
    void stagesle()//선택하기
    {
        if (isCon == false)
        {
            if (Input.GetMouseButtonUp(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                Physics.Raycast(ray, out hit);

                if (hit.collider != null)
                {
                    Revert = false;
                    MoveSpeedacc = 0;
                    This_Stage = hit.collider.gameObject;
                    isCon = true;
                    //Debug.Log(This_Stage);
                    //Debug.Log("asdfasdf");
                }
            }
        }
    }

    void StageEffer()//선택됬을때이펙트
    {
        if (isCon == true)
        {
           
            ////////ui 체인지
            SelUI.SetActive(true);
            DselUI.SetActive(false);



            //this.gameObject.transform.position =  Vector3.Lerp(new Vector3(this.transform.position.x,this.gameObject.transform.position.x, -10), new Vector3(This_Stage.transform.position.x, This_Stage.transform.position.y, -10), 2f*Time.deltaTime);
            //해당 오브젝트 에 가기
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, new Vector3(This_Stage.transform.position.x, This_Stage.transform.position.y, -10),3.5f * Time.deltaTime);

            //확대 
            if (cam.orthographicSize >= 0.28f)
            {
                MoveSpeedacc += Time.deltaTime * 2;
                cam.orthographicSize -= ((1.0f + (MoveSpeedacc )) * Time.deltaTime);
                isSelStageMod = true;            }

            //isCon = false;
        }
    }

    void RevertStageSel()//나가기
    {
        if (Revert)
        {
            //ui체인지
            SelUI.SetActive(false);
            DselUI.SetActive(true);

            //되돌아가기
            this.gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, cneterPos.position, 2.5f * Time.deltaTime);
            //화면 축소
            if (cam.orthographicSize <= 5.0f)
            {
                MoveSpeedacc += Time.deltaTime;

                cam.orthographicSize += ((2.5f + MoveSpeedacc * Time.deltaTime) * Time.deltaTime);

                isCon = false; //선택했는지 않했는지
                isSelStageMod = false;//스테이지 모드 Yes or NO

                if (cam.orthographicSize >= 5)//정확히 맞춤
                {
                    cam.orthographicSize = 5.0f;
                    //
                }
            }
            

        }
        else
        {
            //this.gameObject.transform.position = new Vector3(0, 0, -10);
        }
        //if (this.gameObject.transform.position == cneterPos.position)
        //{
        //    Pos.position = new Vector3(0, 0, -10);
        //    Revert = false;
        //}
    }
}
