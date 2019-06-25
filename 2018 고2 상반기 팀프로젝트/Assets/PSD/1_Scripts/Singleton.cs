using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton
{

    public int _SongNum;

    public int[] maxssc =new int[8];
    public Sprite[] bestrank = new Sprite[8];
    public int[] chekRank = new int[8] { 5,5,5,5,5,5,5,5}  ;

    public int play_Count;
    public int[] Num_count = new int[8];

    public int _BestCombe;
    public int[] _SongBestCombe = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
    public float BGN_Volume =1;
    public float SFX_Volume = 1;
    /// SinglenTon
    /// </summary>
    private static Singleton instance = null;

    public static Singleton Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Singleton();
            }
            return instance;
        }
    }

    private Singleton()
    {

    }
}
