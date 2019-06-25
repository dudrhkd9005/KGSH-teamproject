using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{

    public Image thumbnail; // 1
    public Image Up;   //2 
    public Image down; //3

    public Image title;
    public Image nametitle;

    public Image score_;
    public Text scolore2;
    public int ScoreJum;

    public Image rank;
    public Text rank_;
    public char rankTitle;

    public Image Ligth_Center;

    public Image com1;
    public Image pre2;
    public Image good3;
    public Image nice4;
    public Image miss5;
    public Image dif6;
    public Image restart;
    public Image next;


    int comscr;
    int presc;
    int goodsc;
    int nice;
    int miss;
    int Non;
    public Text com1_;
    public Text pre1_;
    public Text god1_;
    public Text nice1_;
    public Text miss1_;
    // Text non1_;



    public bool TESTBOOL;
    // Use this for initialization
    void Start()
    {



        //Left_Ef();
    }

    // Update is called once per frame
    void Update()
    {
        if (TESTBOOL)
        {
            result_Val();
            Left_Ef();
            TESTBOOL = false;
        }
    }
    void result_Val()//결과 값들
    {
        ScoreJum = 155550;
        rankTitle = 'S';
        comscr = 2142;
        presc = 2050;
        goodsc = 1098;
        nice = 252;
        miss = 1740;
    }
    void Left_Ef()
    {
        //썸네일
        iTween.MoveTo(thumbnail.gameObject, iTween.Hash(
               "islocal", true,
               "y", 0,
               "time", 2.4f,
               "easetype", iTween.EaseType.easeOutQuint));
        iTween.ValueTo(this.gameObject, iTween.Hash(
               "from", 0,
               "to", 1f,
               "time", 2.8f,
               "onUpdate", "Alpha_1",
               "delay", 0,
               "easetype", iTween.EaseType.easeOutQuint
               , "oncomplete", "Nextef"));





        //위
        iTween.MoveTo(Up.gameObject, iTween.Hash("islocal", true,
              "y", 459,
              "time", 1.7f,
              "delay", 1.0f,
              "easetype", iTween.EaseType.easeOutQuint
           ));
        iTween.ValueTo(this.gameObject, iTween.Hash(
              "from", 0,
              "to", 0.3f,
              "time", 2f,
              "onUpdate", "Alpha_2",
              "delay", 1.0f,
              "easetype", iTween.EaseType.easeOutQuint));

        iTween.ValueTo(this.gameObject, iTween.Hash(
                                                    "from", 0,
                                                    "to", 0.8f,
                                                    "time", 4.5f,
                                                     "onUpdate", "Alpha_2_fon",
                                                     "delay", 1.0f,
                                                     "easetype", iTween.EaseType.easeOutQuint));
        iTween.ValueTo(this.gameObject, iTween.Hash(
                                            "from", 0,
                                            "to", 1.0f,
                                            "time", 4.0f,
                                             "onUpdate", "Alpha_2_fon2",
                                             "delay", 1.4f,
                                             "easetype", iTween.EaseType.easeOutQuint));













        //아래
        iTween.MoveTo(down.gameObject, iTween.Hash("islocal", true,
              "y", -450,
              "time", 1.7f,
              "delay", 1.0f,
              "easetype", iTween.EaseType.easeOutQuint));
        iTween.ValueTo(this.gameObject, iTween.Hash(
              "from", 0,
              "to", 0.3f,
              "time", 2f,
              "onUpdate", "Alpha_3",
              "delay", 1.0f,
              "easetype", iTween.EaseType.easeOutQuint));

        iTween.ValueTo(this.gameObject, iTween.Hash(
      "from", 0,
      "to", 0.8f,
      "time", 4.5f,
      "onUpdate", "Alpha_31",
      "delay", 1.2f,
      "easetype", iTween.EaseType.easeOutQuint
      ));
        iTween.ValueTo(this.gameObject, iTween.Hash(
      "from", 0,
      "to", 1.0f,
      "time", 4f,
      "onUpdate", "Alpha_32",
      "delay", 1.6f,
      "easetype", iTween.EaseType.easeOutQuint));

        iTween.ValueTo(this.gameObject, iTween.Hash(
      "from", 0,
      "to", ScoreJum,
      "time", 4f,
      "onUpdate", "Alpha_32_jumsu",
      "delay", 1.7f,
      "easetype", iTween.EaseType.easeOutQuint
       ));






        //가운데
        iTween.ValueTo(this.gameObject, iTween.Hash(
              "from", 0,
              "to", 1,
              "time", 3f,
              "onUpdate", "Alpha_4",
              "delay", 2.0f,
              "easetype", iTween.EaseType.easeOutQuint
             ));

        iTween.ValueTo(this.gameObject, iTween.Hash(
              "from", 0,
              "to", 0.8f,
              "time", 3f,
              "onUpdate", "Alpha_42",
              "delay", 2.4f,
              "easetype", iTween.EaseType.easeOutQuint
             ));
        iTween.ValueTo(this.gameObject, iTween.Hash(
      "from", 0,
      "to", 1,
      "time", 9f,
      "onUpdate", "Alpha_43",
      "delay", 2.8f,
      "easetype", iTween.EaseType.easeOutQuint
     ));




    }

    void Nextef()
    {
        iTween.MoveTo(com1.gameObject, iTween.Hash("islocal", true,
        "y", 340,
        "time", 1.5f,
        "delay", 0f,
        "easetype", iTween.EaseType.easeOutQuint));

        iTween.ValueTo(this.gameObject, iTween.Hash(
      "from", 0,
      "to", 1,
      "time", 1.5f,
      "onUpdate", "Alpha_5",
      "delay", 0,
      "easetype", iTween.EaseType.easeOutQuint));

        iTween.ValueTo(this.gameObject, iTween.Hash(
"from", 0,
"to", comscr,
"time", 1.5f,
"onUpdate", "Alpha_51",
"delay", 0.5f,
"easetype", iTween.EaseType.easeOutQuint));



        iTween.MoveTo(pre2.gameObject, iTween.Hash("islocal", true,
        "y", 210,
        "x", -268.95,
        "time", 1.5f,
        "delay", 0.5f,
        "easetype", iTween.EaseType.easeOutQuint));

        iTween.ValueTo(this.gameObject, iTween.Hash(
      "from", 0,
      "to", 1,
      "time", 1.5f,
      "onUpdate", "Alpha_6",
      "delay", 0.5f,
      "easetype", iTween.EaseType.easeOutQuint));


        iTween.ValueTo(this.gameObject, iTween.Hash(
"from", 0,
"to", presc,
"time", 1.5f,
"onUpdate", "Alpha_61",
"delay", 1.0f,
"easetype", iTween.EaseType.easeOutQuint));


        iTween.MoveTo(good3.gameObject, iTween.Hash("islocal", true,
        "y", 210,
        "x", 268.95,
        "time", 1.5f,
        "delay", 1f,
        "easetype", iTween.EaseType.easeOutQuint));

        iTween.ValueTo(this.gameObject, iTween.Hash(
      "from", 0,
      "to", 1,
      "time", 1.5f,
      "onUpdate", "Alpha_7",
      "delay", 1.0f,
      "easetype", iTween.EaseType.easeOutQuint));


        iTween.ValueTo(this.gameObject, iTween.Hash(
"from", 0,
"to", goodsc,
"time", 1.5f,
"onUpdate", "Alpha_71",
"delay", 1.5f,
"easetype", iTween.EaseType.easeOutQuint));


        iTween.MoveTo(nice4.gameObject, iTween.Hash("islocal", true,
          "y", -230,
           "x", 268.95,
          "time", 1.5f,
          "delay", 1.5f,
           "easetype", iTween.EaseType.easeOutQuint));

        iTween.ValueTo(this.gameObject, iTween.Hash(
      "from", 0,
      "to", 1,
      "time", 1.5f,
      "onUpdate", "Alpha_8",
      "delay", 1.5f,
      "easetype", iTween.EaseType.easeOutQuint
      , "oncomplete", "Nexte2f"));


        iTween.ValueTo(this.gameObject, iTween.Hash(
"from", 0,
"to", nice,
"time", 1.5f,
"onUpdate", "Alpha_81",
"delay", 2f,
"easetype", iTween.EaseType.easeOutQuint));



        iTween.MoveTo(miss5.gameObject, iTween.Hash("islocal", true,
           "y", -230,
           "x", -268.95,
           "time", 1.5f,
           "delay", 2.0f,
           "easetype", iTween.EaseType.easeOutQuint));

        iTween.ValueTo(this.gameObject, iTween.Hash(
      "from", 0,
      "to", 1,
      "time", 1.5f,
      "onUpdate", "Alpha_9",
      "delay", 2.0f,
      "easetype", iTween.EaseType.easeOutQuint));

        iTween.ValueTo(this.gameObject, iTween.Hash(
"from", 0,
"to", miss,
"time", 1.5f,
"onUpdate", "Alpha_91",
"delay", 2.5f,
"easetype", iTween.EaseType.easeOutQuint));


        iTween.MoveTo(dif6.gameObject, iTween.Hash("islocal", true,
            "y", -340,
            "x", 0,
            "time", 1.5f,
            "delay", 2.5f,
            "easetype", iTween.EaseType.easeOutQuint));

        iTween.ValueTo(this.gameObject, iTween.Hash(
      "from", 0,
      "to", 1,
      "time", 1.5f,
      "onUpdate", "Alpha_10",
      "delay", 2.5f,
      "easetype", iTween.EaseType.easeOutQuint));




    }
    void Nexte2f()
    {
      

        iTween.ValueTo(this.gameObject, iTween.Hash(
"from", 0,
"to", 1,
"time", 3f,
"onUpdate", "Alpah_11",
"delay", 0f,
"easetype", iTween.EaseType.easeOutQuint));

        iTween.ValueTo(this.gameObject, iTween.Hash(
"from", 0,
"to", 1,
"time", 3f,
"onUpdate", "Alpah_12",
"delay", 0.4f,
"easetype", iTween.EaseType.easeOutQuint));
    }

    void Alpha_1(float Value_)
    {
        Color color = thumbnail.color;
        color.a = Value_;
        thumbnail.color = color;
    }
    void Alpha_2(float Value_)
    {
        Color color = Up.color;
        color.a = Value_;
        Up.color = color;
    }
    void Alpha_2_fon(float Value_)
    {
        Color color = title.color;
        color.a = Value_;
        title.color = color;
    }
    void Alpha_2_fon2(float Value_)
    {
        Color color = nametitle.color;
        color.a = Value_;
        nametitle.color = color;
    }

    void Alpha_3(float Value_)
    {
        Color color = down.color;
        color.a = Value_;
        down.color = color;
    }

    void Alpha_31(float Value_)
    {
        Color color = score_.color;
        color.a = Value_;
        score_.color = color;
    }

    void Alpha_32(float Value_)
    {
        Color color = scolore2.color;
        color.a = Value_;
        scolore2.color = color;
    }
    void Alpha_32_jumsu(int jumsu)
    {
        scolore2.text = "" + jumsu;


    }

    void Alpha_4(float Value_)
    {
        Color color = Ligth_Center.color;
        color.a = Value_;
        Ligth_Center.color = color;
    }
    void Alpha_42(float Value_)
    {
        Color color = rank.color;
        color.a = Value_;
        rank.color = color;

    }
    void Alpha_43(float Value_)
    {
        Color color = rank_.color;
        color.a = Value_;
        rank_.color = color;
    }


    void Alpha_5(float Value_)
    {
        Color color = com1.color;
        color.a = Value_;
        com1.color = color;
    }
    void Alpha_6(float Value_)
    {
        Color color = pre2.color;
        color.a = Value_;
        pre2.color = color;
    }
    void Alpha_7(float Value_)
    {
        Color color = good3.color;
        color.a = Value_;
        good3.color = color;
    }
    void Alpha_8(float Value_)
    {
        Color color = nice4.color;
        color.a = Value_;
        nice4.color = color;
    }
    void Alpha_9(float Value_)
    {
        Color color = miss5.color;
        color.a = Value_;
        miss5.color = color;
    }
    void Alpha_10(float Value_)
    {
        Color color = dif6.color;
        color.a = Value_;
        dif6.color = color;
    }
    void Alpah_11(float Value_)
    {
        Color color = restart.color;
        color.a = Value_;
        restart.color = color;
    }
    void Alpah_12(float Value_)
    {
        Color color = next.color;
        color.a = Value_;
        next.color = color;
    }

    void Alpha_91(int Value_)
    {
        miss1_.text = "" + Value_;
    }
    void Alpha_81(int Value_)
    {
        nice1_.text = "" + Value_;
    }
    void Alpha_71(int Value_)
    {
        god1_.text = "" + Value_;
    }
    void Alpha_61(int Value_)
    {
        pre1_.text = "" + Value_;
    }
    void Alpha_51(int Value_)
    {
        com1_.text = "" + Value_;
    }

}
