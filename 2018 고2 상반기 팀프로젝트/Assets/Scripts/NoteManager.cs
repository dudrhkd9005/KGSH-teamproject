using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public MusicNote[] musicNode;
    public InGameManager inGameManager;
    public int musicNum;
    public MusicNote nowMusicNode;
    int noteCount = 0;
    
    private void Awake()
    {
        if (inGameManager.editMode == false)
        {
            musicNum = GameManager.Instance.playMusicNum;
        }

        nowMusicNode = musicNode[musicNum];
        inGameManager.music.clip = nowMusicNode.music;
        inGameManager.speed = GameManager.Instance.GetSpeed();
    }

    // Start is called before the first frame update
    void Start()
    {
        if(!inGameManager.editMode)
        StartCoroutine(StartGame());
    }

    // Update is called once per frame
    void Update()
    {
        if (noteCount < nowMusicNode.notes.Count)
        {
            if (nowMusicNode.notes[noteCount].time != 0)
            {
                if (inGameManager.music.time > nowMusicNode.notes[noteCount].time - (50 / inGameManager.speed))
                {
                    if (nowMusicNode.notes[noteCount].noteKind == Note.NoteKind.Short)
                    {
                        inGameManager.InstanceShortNote(new InGameManager.NoteData(nowMusicNode.notes[noteCount].time, nowMusicNode.notes[noteCount].num));
                        noteCount++;
                    }
                    else if (nowMusicNode.notes[noteCount].noteKind == Note.NoteKind.Swipe)
                    {
                        inGameManager.InstanceSwipeNote(new InGameManager.NoteData(nowMusicNode.notes[noteCount].time, nowMusicNode.notes[noteCount].num));
                        noteCount++;
                    }
                    else if (nowMusicNode.notes[noteCount].noteKind == Note.NoteKind.Long)
                    {
                        List<InGameManager.NoteData> temp = new List<InGameManager.NoteData>();
                        temp.Add(new InGameManager.NoteData(nowMusicNode.notes[noteCount].time, nowMusicNode.notes[noteCount].num));
                        noteCount++;
                        while (true)
                        {
                            if (noteCount == nowMusicNode.notes.Count || nowMusicNode.notes[noteCount].noteKind != Note.NoteKind.SubLong)
                            {
                                break;
                            }
                            temp.Add(new InGameManager.NoteData(nowMusicNode.notes[noteCount].time, nowMusicNode.notes[noteCount].num));
                            noteCount++;
                        }
                        inGameManager.InstanceLongNote(temp.ToArray());
                    }
                }
            }
            else
            {
                noteCount++;
            }
        }
    }

    public void SetNowTime()
    {
        noteCount = 0;

        while (true)
        {
            if (noteCount < nowMusicNode.notes.Count)
            {
                if (inGameManager.music.time >= nowMusicNode.notes[noteCount].time)
                {
                    noteCount++;
                }
                else
                {
                    break;
                }
            }
            else
            {
                break;
            }

        }
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(3);
        inGameManager.music.Play();
        inGameManager.play = true;
        inGameManager.playTime = Time.time;
    }
}
