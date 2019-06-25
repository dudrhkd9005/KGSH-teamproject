using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultLoad : MonoBehaviour
{
    public SpriteNumber score;
    public SpriteNumber perfectCount;
    public SpriteNumber goodCount;
    public SpriteNumber badCount;
    public SpriteNumber missCount;
    public SpriteNumber maxCombo;
    public Image rank;
    public GameObject bestScore;

    public Sprite[] rankSprite;
    int step = 0;

    float scoref;
    float perfect;
    float good;
    float bad;
    float miss;
    float combo;

    // Start is called before the first frame update
    void Start()
    {
        score.value = 0;
        perfectCount.value = 0;
        goodCount.value = 0;
        badCount.value = 0;
        missCount.value = 0;
        maxCombo.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (step == 0)
        {
            if (score.value != GameManager.Instance.score)
            {
                scoref += GameManager.Instance.score  * 0.8f * Time.deltaTime;
                score.value = (int)scoref;
                if(score.value > GameManager.Instance.score)
                {
                    score.value = GameManager.Instance.score;
                    step++;
                }
            }
        }
        else if (step == 1)
        {
            if (perfectCount.value != GameManager.Instance.perfectCount)
            {
                perfect += (GameManager.Instance.perfectCount * 0.8f * Time.deltaTime);
                perfectCount.value = (int)perfect;
                if(perfectCount.value > GameManager.Instance.perfectCount)
                {
                    perfectCount.value = GameManager.Instance.perfectCount;
                }
            }
            if (goodCount.value != GameManager.Instance.goodCount)
            {
                good += (GameManager.Instance.goodCount * 0.8f * Time.deltaTime);
                goodCount.value = (int)good;
                if (goodCount.value > GameManager.Instance.goodCount)
                {
                    goodCount.value = GameManager.Instance.goodCount;
                }
            }
            if (badCount.value != GameManager.Instance.badCount)
            {
                bad += (GameManager.Instance.badCount * 0.8f * Time.deltaTime);
                badCount.value = (int)bad;
                if (badCount.value > GameManager.Instance.badCount)
                {
                    badCount.value = GameManager.Instance.badCount;
                }
            }
            if (missCount.value != GameManager.Instance.missCount)
            {
                miss += (GameManager.Instance.missCount * 0.8f * Time.deltaTime);
                missCount.value = (int)miss;
                if (missCount.value > GameManager.Instance.missCount)
                {
                    missCount.value = GameManager.Instance.missCount;
                }
            }
            if (maxCombo.value != GameManager.Instance.maxCombo)
            {
                combo += (GameManager.Instance.maxCombo * 0.8f * Time.deltaTime);
                maxCombo.value = (int)combo;
                if (maxCombo.value > GameManager.Instance.maxCombo)
                {
                    maxCombo.value = GameManager.Instance.maxCombo;
                }
            }
            if (perfectCount.value == GameManager.Instance.perfectCount && goodCount.value == GameManager.Instance.goodCount && badCount.value == GameManager.Instance.badCount && missCount.value == GameManager.Instance.missCount && maxCombo.value == GameManager.Instance.maxCombo)
            {
                step++;
            }
        }
        else if (step == 2)
        {
            if (GameManager.Instance.rank == Rank.S)
            {
                rank.sprite = rankSprite[0];
            }
            else if (GameManager.Instance.rank == Rank.A)
            {
                rank.sprite = rankSprite[1];
            }
            else if (GameManager.Instance.rank == Rank.B)
            {
                rank.sprite = rankSprite[2];
            }
            else if (GameManager.Instance.rank == Rank.C)
            {
                rank.sprite = rankSprite[3];
            }
            else if (GameManager.Instance.rank == Rank.D)
            {
                rank.sprite = rankSprite[4];
            }
            else if (GameManager.Instance.rank == Rank.F)
            {
                rank.sprite = rankSprite[5];
            }
            rank.enabled = true;
            rank.SetNativeSize();

            if(GameManager.Instance.GetBestScore(GameManager.Instance.playMusicNum) < GameManager.Instance.score)
            {
                GameManager.Instance.SetbestScore(GameManager.Instance.playMusicNum, GameManager.Instance.score);
                bestScore.SetActive(true);
            }

            step++;
        }
    }
}
