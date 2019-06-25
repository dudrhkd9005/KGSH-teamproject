using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class STAGESLESCRIPTS : MonoBehaviour
{

    private void Awake()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    GameObject This_Stage;//선택된 스테이지
    public Transform centerpos;
    //public Transform cneterPos;
    bool isCon; //스테이지가 선택 여부
    public bool isSelStageMod;
    public bool Revert;
    //화면 이동
    Camera cam;
    //public Transform Pos;
    public float MoveSpeedacc;
    public GameObject SelUI; //선택했을때 ui
    public GameObject DselUI; //선택 안했를때
                              // Use this for initialization
    void Start()
    {
        isCon = false;
        isSelStageMod = true;
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
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                Physics.Raycast(ray, out hit);

                if (hit.collider != null)
                {
                    MoveSpeedacc = 1;
                    This_Stage = hit.collider.gameObject;
                    isCon = true;
                    isSelStageMod = true;             
                }
            }
        }
    }

    void StageEffer()//선택됬을때이펙트
    {
        if (isCon == true)
        {
            MoveSpeedacc += Time.deltaTime * 2;
            SelUI.SetActive(true);
            DselUI.SetActive(false);

            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, new Vector3(This_Stage.transform.position.x, This_Stage.transform.position.y, This_Stage.transform.position.z - 0.8f), 3.5f * Time.deltaTime * (MoveSpeedacc * 2));

          This_Stage.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);

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
            this.gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, centerpos.position, 3.5f * Time.deltaTime * (MoveSpeedacc *2 ));

            MoveSpeedacc += Time.deltaTime;

            isCon = false; //선택했는지 않했는지

            isSelStageMod = false;//스테이지 모드 Yes or NO

           This_Stage.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
            //
            if (gameObject.transform.position == centerpos.position)
            {
                Revert = false;
            }
        }

    
    }


    void EFF()
    {
        //This_Stage.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).
    }
    //void Eff1()
    //{
    //    if ( ) 
    //    {

    //    }
    //}
}