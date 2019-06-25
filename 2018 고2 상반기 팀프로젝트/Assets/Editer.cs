using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Editer : MonoBehaviour
{
    public InGameManager gameManager;
    public NoteManager noteManager;
    public Slider timeBar;
    public TMPro.TextMeshProUGUI timeText;
    bool play;
    // Start is called before the first frame update
    void Start()
    {
        gameManager.music.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = gameManager.music.time.ToString();
        if (play)
        {
            timeBar.value = gameManager.music.time / gameManager.music.clip.length;
        }
        if(Input.GetMouseButtonDown(1))
        {
            Debug.Log(gameManager.music.time.ToString());
        }
        //if(Input.GetMouseButtonDown(0))
        //{
        //    Vector2 mouse = Input.mousePosition;
        //}
        if(Input.GetKeyDown(KeyCode.G))
        {
            noteManager.nowMusicNode.notes.Add(new Notes() {noteKind = Note.NoteKind.Short, num = 1, time = gameManager.music.time });
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            noteManager.nowMusicNode.notes.Add(new Notes() { noteKind = Note.NoteKind.Short, num = 2, time = gameManager.music.time });
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            noteManager.nowMusicNode.notes.Add(new Notes() { noteKind = Note.NoteKind.Short, num = 3, time = gameManager.music.time });
        }
        gameManager.playTime = Time.time - gameManager.music.time;
    }

    public void Play()
    {
        gameManager.music.Play();
        Sort();
        noteManager.SetNowTime();
        play = true;
    }

    void Sort()
    {
        noteManager.nowMusicNode.notes.Sort(delegate(Notes A, Notes B)
        {
            if (A.time == B.time) return 0;
            if (A.time == 0) return 1;
            if (B.time == 0) return -1;
            if (A.time > B.time) return 1;
            else if (A.time < B.time) return -1;
            return 0;
        });
    }

    public void Stop()
    {
        gameManager.music.Pause();
        play = false;
    }
    
    public void SetToBar()
    {
        if (gameManager.music.isPlaying)
        {
            gameManager.music.Pause();
            play = false;
        }
        gameManager.AllRemove();
        gameManager.music.time = timeBar.value * gameManager.music.clip.length;
        timeText.text = gameManager.music.time.ToString();
    }
}
