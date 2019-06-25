using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public enum Judgment
    {
        Perfect,
        Good,
        Bad,
        Miss
    }

    public SpriteNumber number;
    public GameObject JudgementObj;
    public int score = 0;
    public int perfectCount = 0;
    public int goodCount = 0;
    public int badCount = 0;
    public int missCount = 0;

    public Sprite perfect;
    public Sprite good;
    public Sprite bad;
    public Sprite miss;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(score != number.value)
        {
            number.value += (int)((score - number.value) / 0.6f);
        }
    }
    public void Score(Judgment judgment)
    {
        JudgementObj.GetComponent<Animation>().Stop();
        JudgementObj.GetComponent<Animation>().Play();
        if (judgment == Judgment.Perfect)
        {
            JudgementObj.GetComponent<Image>().sprite = perfect;
            JudgementObj.GetComponent<Image>().SetNativeSize();
            score += 100;
            perfectCount += 1;
        }
        else if(judgment == Judgment.Good)
        {
            JudgementObj.GetComponent<Image>().sprite = good;
            JudgementObj.GetComponent<Image>().SetNativeSize();
            score += 50;
            goodCount += 1;
        }
        else if(judgment == Judgment.Bad)
        {
            JudgementObj.GetComponent<Image>().sprite = bad;
            JudgementObj.GetComponent<Image>().SetNativeSize();
            score += 30;
            badCount += 1;
        }
        else if(judgment == Judgment.Miss)
        {
            JudgementObj.GetComponent<Image>().sprite = miss;
            JudgementObj.GetComponent<Image>().SetNativeSize();
            missCount += 1;
        }
    }
    public int GetScore()
    {
        return score;
    }
}
