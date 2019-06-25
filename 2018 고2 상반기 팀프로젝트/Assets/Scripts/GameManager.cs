using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Rank
{
    S,
    A,
    B,
    C,
    D,
    F
}

public class GameManager
{
    private static GameManager instance = null;

    public int playMusicNum;
    public int score;
    public int perfectCount;
    public int goodCount;
    public int badCount;
    public int missCount;
    public int maxCombo;
    public Rank rank;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameManager();
            }
            return instance;
        }
    }

    public void SetbestScore(int _musicNum, int _score)
    {
        PlayerPrefs.SetInt("BestScore " + _musicNum.ToString(), _score);
    }

    public int GetBestScore(int _musicNum)
    {
        return PlayerPrefs.GetInt("BestScore " + _musicNum.ToString(), 0);
    }

    public float GetSpeed()
    {
        return PlayerPrefs.GetFloat("Speed",10f);
    }

    public void SetSpeed(float _value)
    {
        PlayerPrefs.SetFloat("Speed", _value);
    }
}
