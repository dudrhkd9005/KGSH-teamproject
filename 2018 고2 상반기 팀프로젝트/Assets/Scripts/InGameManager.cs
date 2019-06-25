using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameManager : MonoBehaviour
{
    public struct NoteData
    {
        public NoteData(float _time, int _num)
        {
            time = _time;
            num = _num;
        }
        public float time;
        public int num;
    }

    public class SwipeData
    {
        public Vector2 startpo;
        public int touchNum;
        public Note note;
    }

    public Camera mainCamera;
    public AudioSource music;
    public float speed;
    public Transform[] lines = new Transform[3];
    public List<Note> notes = new List<Note>();
    public GameObject shortNote;
    public GameObject swipeNote;
    public GameObject longNote;
    public GameObject longSubNote;
    public ComboUI comboUI;
    public ScoreUI scoreUI;
    public SceneLoadManager sceneLoadManager;
    public bool editMode;
    public bool play;
    bool end;

    public Image songName;
    public Sprite[] songNameSprites;
    List<int> longNoteHold;
    List<SwipeData> swipeTouch = new List<SwipeData>();

    public GameObject spriteNumber;
    public GameObject particle;

    public float playTime;
    // Start is called before the first frame update
    void Start()
    {
        if (songName)
        {
            songName.sprite = songNameSprites[GameManager.Instance.playMusicNum];
            songName.SetNativeSize();
        }
        //StartCoroutine(test());
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Time.time);
        //Debug.Log(Time.deltaTime);
        if (play)
        {
            GoingNote();
            CheckTouch();
        }
        if((!end && !editMode && play && !music.isPlaying) || Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(endGame());
        }
        //Debug.Log("----" + Time.time);
    }

    void GoingNote()
    {
        for (int i = 0; i < notes.Count; i++)
        {
            //if(i == 0)
            //{
            //    Debug.Log("tttt : " + (Time.time - playTime));
            //    Debug.Log("mmmm : " + music.time);
            //}
            //Debug.Log(lines[notes[i].num - 1].localPosition.y + (notes[i].time - (Time.time - playTime)) * speed);
            notes[i].transform.localPosition = new Vector3(notes[i].transform.localPosition.x, lines[notes[i].num - 1].localPosition.y + (notes[i].time - (Time.time - playTime)) * speed, notes[i].transform.localPosition.z);
            if (notes[i].transform.localPosition.y - lines[notes[i].num - 1].transform.localPosition.y < -(speed * 0.2))
            {
                if (notes[i].noteKind == Note.NoteKind.Long)
                {
                    if (notes[i].off == false)
                    {
                        scoreUI.Score(ScoreUI.Judgment.Miss);
                        comboUI.breakCombo();
                        notes[i].off = true;
                    }
                    if (notes[i].GetComponent<LongNote>().touched == false)
                    {
                        //notes[i].GetComponent<LongNote>().Miss();
                        //notes.Remove(notes[i]);
                    }
                }
                else if (notes[i].noteKind == Note.NoteKind.Swipe)
                {
                    for(int j = 0; j < swipeTouch.Count; j++)
                    {
                        if (swipeTouch[j].note == notes[i].GetComponent<SwipeNote>())
                        {
                            swipeTouch.Remove(swipeTouch[j]);
                            j--;
                        }
                    }
                }
                else if(notes[i].noteKind == Note.NoteKind.SubLong)
                {
                    if(notes[i].off == false)
                    {
                        scoreUI.Score(ScoreUI.Judgment.Miss);
                        comboUI.breakCombo();
                        notes[i].off = true;
                    }
                    //notes.Remove(notes[i]);
                }
                else
                {
                    if (notes[i].off == false)
                    {
                        scoreUI.Score(ScoreUI.Judgment.Miss);
                        comboUI.breakCombo();
                        GameObject dstemp = notes[i].gameObject;
                        notes.Remove(notes[i]);
                        Destroy(dstemp);
                        i--;
                    }
                }
            }
        }
    }

    void CheckTouch()
    {
        for(int i = 0; i < lines.Length; i++)
        lines[i].transform.GetChild(0).gameObject.SetActive(false);

        if (Application.platform == RuntimePlatform.Android)
        {
            Touch tempTouchs;
            if (Input.touchCount > 0)
            {
                for (int i = 0; i < Input.touchCount; i++)
                {
                    tempTouchs = Input.GetTouch(i);
                    if (tempTouchs.phase == TouchPhase.Began)
                    {
                        //Debug.Log("Began : " + i);
                        RaycastHit raycastHit;
                        if (Physics.Raycast(mainCamera.ScreenPointToRay(tempTouchs.position), out raycastHit))
                        {
                            if (raycastHit.collider.CompareTag("NoteButton"))
                            {
                                int lineNum = raycastHit.collider.GetComponent<Line>().num;
                                Note temp = GetFrontNote(lineNum);
                                lines[lineNum - 1].transform.GetChild(0).gameObject.SetActive(true);
                                if (temp)
                                {
                                    if (temp.noteKind == Note.NoteKind.Short)
                                    {
                                        ProsessingNote(temp);
                                        GameObject par = Instantiate(particle);
                                        par.transform.position = lines[lineNum-1].transform.position;
                                        //par.transform.rotation = temp.transform.rotation;
                                        notes.Remove(temp);
                                        Destroy(temp.gameObject);
                                    }
                                    else if (temp.noteKind == Note.NoteKind.Swipe)
                                    {
                                        //Debug.Log("temp.GetComponent<SwipeNote>().touched : " + temp.GetComponent<SwipeNote>().touched);
                                        if (temp.GetComponent<SwipeNote>().touched == false)
                                        {
                                            //Debug.Log("swipeBe : " + i);
                                            temp.GetComponent<SwipeNote>().touched = true;
                                            SwipeData swipetemp = new SwipeData
                                            {
                                                startpo = tempTouchs.position,
                                                note = temp,
                                                touchNum = i
                                            };
                                            swipeTouch.Add(swipetemp);
                                            temp.off = true;
                                            //Debug.Log("swipeBeEnd : " + i);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (tempTouchs.phase == TouchPhase.Moved || tempTouchs.phase == TouchPhase.Stationary)
                    {
                        //Debug.Log("Began : " + i);
                        RaycastHit raycastHit;
                        if (Physics.Raycast(mainCamera.ScreenPointToRay(tempTouchs.position), out raycastHit))
                        {
                            if (raycastHit.collider.CompareTag("NoteButton"))
                            {
                                int lineNum = raycastHit.collider.GetComponent<Line>().num;
                                Note temp = GetFrontNote(lineNum);
                                lines[lineNum - 1].transform.GetChild(0).gameObject.SetActive(true);
                                if (temp)
                                {
                                    if (temp.noteKind == Note.NoteKind.Long || temp.noteKind == Note.NoteKind.SubLong)
                                    {
                                        if(((temp.time - (Time.time - playTime)) > 0 ? (temp.time - (Time.time - playTime)) : -(temp.time - (Time.time - playTime))) < 0.1f)
                                        {
                                            scoreUI.Score(ScoreUI.Judgment.Perfect);
                                            GameObject par =  Instantiate(particle);
                                            par.transform.position = lines[lineNum - 1].transform.position;
                                            //par.transform.rotation = temp.transform.rotation;
                                            comboUI.UpCombo();
                                            temp.off = true;
                                        }
                                    }
                                }
                            }
                        }
                        for (int j = 0; j < swipeTouch.Count; j++)
                        {
                            if (swipeTouch[j].touchNum == i)
                            {
                                if (Vector2.Distance(swipeTouch[j].startpo, tempTouchs.position) > 100)
                                {
                                    //Debug.Log("desStart");
                                    ProsessingNote(swipeTouch[j].note);
                                    GameObject par = Instantiate(particle);
                                    par.transform.position = lines[swipeTouch[j].note.num - 1].transform.position;
                                    //par.transform.rotation = swipeTouch[j].note.transform.rotation;
                                    GameObject dstemp = swipeTouch[j].note.gameObject;
                                    notes.Remove(swipeTouch[j].note);
                                    Destroy(dstemp);
                                    swipeTouch.Remove(swipeTouch[j]);
                                    j--;
                                    //Debug.Log("desEnd");
                                }

                            }
                        }
                    }
                    else if (tempTouchs.phase == TouchPhase.Ended)
                    {
                        for (int j = 0; j < swipeTouch.Count; j++)
                        {
                            if (swipeTouch[j].touchNum == i)
                            {
                                //Debug.Log("MissdesStart");
                                MissNote();
                                GameObject detemp = swipeTouch[j].note.gameObject;
                                notes.Remove(swipeTouch[j].note);
                                swipeTouch.Remove(swipeTouch[j]);
                                Destroy(detemp);
                                j--;
                                //Debug.Log("MissdesStart");
                                continue;

                            }
                            else if (swipeTouch[j].touchNum > i)
                            {
                                swipeTouch[j].touchNum = swipeTouch[j].touchNum - 1;
                            }
                        }
                    }
                }
            }
        }
        else if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            Vector2 mouse = Input.mousePosition;
            if (Input.GetMouseButtonDown(0))
            {
                //Debug.Log("Began : " + 0);
                RaycastHit raycastHit;
                if (Physics.Raycast(mainCamera.ScreenPointToRay(mouse), out raycastHit))
                {
                    if (raycastHit.collider.CompareTag("NoteButton"))
                    {
                        int lineNum = raycastHit.collider.GetComponent<Line>().num;
                        Note temp = GetFrontNote(lineNum);
                        lines[lineNum-1].transform.GetChild(0).gameObject.SetActive(true);
                        if (temp)
                        {
                            if (temp.noteKind == Note.NoteKind.Short)
                            {
                                ProsessingNote(temp);
                                GameObject par = Instantiate(particle);
                                par.transform.position = lines[lineNum - 1].transform.position;
                                //par.transform.rotation = temp.transform.rotation;
                                notes.Remove(temp);
                                Destroy(temp.gameObject);
                            }
                            else if (temp.noteKind == Note.NoteKind.Swipe)
                            {
                                //Debug.Log("temp.GetComponent<SwipeNote>().touched : " + temp.GetComponent<SwipeNote>().touched);
                                if (temp.GetComponent<SwipeNote>().touched == false)
                                {
                                    //Debug.Log("swipeBe : " + 0);
                                    temp.GetComponent<SwipeNote>().touched = true;
                                    SwipeData swipetemp = new SwipeData
                                    {
                                        startpo = mouse,
                                        note = temp,
                                        touchNum = 0
                                    };
                                    swipeTouch.Add(swipetemp);
                                    //Debug.Log("swipeBeEnd : " + 0);
                                }
                            }
                        }
                    }
                }
            }
            else if (Input.GetMouseButton(0))
            {
                //Debug.Log("Began : " + 0);
                RaycastHit raycastHit;
                if (Physics.Raycast(mainCamera.ScreenPointToRay(mouse), out raycastHit))
                {
                    if (raycastHit.collider.CompareTag("NoteButton"))
                    {
                        int lineNum = raycastHit.collider.GetComponent<Line>().num;
                        lines[lineNum-1].transform.GetChild(0).gameObject.SetActive(true);
                        Note temp = GetFrontNote(lineNum);
                        if (temp)
                        {
                            if (temp.noteKind == Note.NoteKind.Long || temp.noteKind == Note.NoteKind.SubLong)
                            {
                                if (((temp.time - (Time.time - playTime)) > 0 ? (temp.time - (Time.time - playTime)) : -(temp.time - (Time.time - playTime))) < 0.1f)
                                {
                                    scoreUI.Score(ScoreUI.Judgment.Perfect);
                                    GameObject par = Instantiate(particle);
                                    par.transform.position = lines[lineNum - 1].transform.position;
                                    //par.transform.rotation = temp.transform.rotation;
                                    comboUI.UpCombo();
                                    temp.off = true;
                                }
                            }
                        }
                    }
                }
                for (int j = 0; j < swipeTouch.Count; j++)
                {
                    if (swipeTouch[j].touchNum == 0)
                    {
                        if (Vector2.Distance(swipeTouch[j].startpo, mouse) > 100)
                        {
                            //Debug.Log("desStart");
                            ProsessingNote(swipeTouch[j].note);
                            GameObject par = Instantiate(particle);
                            par.transform.position = lines[swipeTouch[j].note.num - 1].transform.position;
                            //par.transform.rotation = swipeTouch[j].note.transform.rotation;
                            GameObject dstemp = swipeTouch[j].note.gameObject;
                            notes.Remove(swipeTouch[j].note);
                            Destroy(dstemp);
                            swipeTouch.Remove(swipeTouch[j]);
                            j--;
                            //Debug.Log("desEnd");
                        }

                    }
                }
            }
            else if (Input.GetMouseButtonUp(0))
                    {
                        for (int j = 0; j < swipeTouch.Count; j++)
                        {
                            if (swipeTouch[j].touchNum == 0)
                            {
                                MissNote();
                                GameObject detemp = swipeTouch[j].note.gameObject;
                                notes.Remove(swipeTouch[j].note);
                                swipeTouch.Remove(swipeTouch[j]);
                                Destroy(detemp);
                                j--;
                                continue;

                            }
                            else if (swipeTouch[j].touchNum > 0)
                            {
                                swipeTouch[j].touchNum = swipeTouch[j].touchNum - 1;
                            }
                        }
                    }
        }
    }

    void ProsessingNote(Note _note)
    {
        float dis = (_note.time - (Time.time - playTime)) > 0 ? (_note.time - (Time.time - playTime)) : -(_note.time - (Time.time - playTime));
        //Debug.Log(dis);
        if (dis <= 0.1f)
        {
            scoreUI.Score(ScoreUI.Judgment.Perfect);
            comboUI.UpCombo();
        }
        else if (dis <= 0.2f)
        {
            scoreUI.Score(ScoreUI.Judgment.Good);
            comboUI.UpCombo();
        }
        else if (dis <= 0.3f)
        {
            scoreUI.Score(ScoreUI.Judgment.Bad);
            comboUI.breakCombo();
        }
        else
        {
            scoreUI.Score(ScoreUI.Judgment.Miss);
            comboUI.breakCombo();
        }
    }

    void MissNote()
    {
        scoreUI.Score(ScoreUI.Judgment.Miss);
        comboUI.breakCombo();
    }

    Note GetFrontNote(int _num)
    {
        for(int i = 0; i < notes.Count; i++)
        {
            if (notes[i].time - (Time.time - playTime) > 0.4f || i >= notes.Count)
            {
                //Debug.Log("noNote : TIME");
                return null;
            }
            else if (notes[i].num == _num && notes[i].off == false)
            {
                return notes[i];
            }
        }
        //Debug.Log("noNote : INDEX");
        return null;
    }

    public void InstanceShortNote(NoteData _data)
    {
        GameObject tempObject = Instantiate(shortNote);
        tempObject.transform.parent = lines[_data.num - 1].parent;
        tempObject.transform.localPosition = new Vector3(lines[_data.num - 1].localPosition.x, lines[_data.num - 1].localPosition.y + (_data.time - (Time.time - playTime)) * speed, lines[_data.num - 1].localPosition.z);
        tempObject.transform.localRotation = Quaternion.identity;
        tempObject.GetComponent<Note>().num = _data.num;
        tempObject.GetComponent<Note>().time = _data.time;
        notes.Add(tempObject.GetComponent<Note>());
    }

    public void InstanceSwipeNote(NoteData _data)
    {
        GameObject tempObject = Instantiate(swipeNote);
        tempObject.transform.parent = lines[_data.num - 1].parent;
        tempObject.transform.localRotation = Quaternion.identity;
        tempObject.transform.localPosition = new Vector3(lines[_data.num - 1].localPosition.x, lines[_data.num - 1].localPosition.y + (_data.time - (Time.time - playTime)) * speed, lines[_data.num - 1].localPosition.z);
        tempObject.GetComponent<Note>().num = _data.num;
        tempObject.GetComponent<Note>().time = _data.time;
        notes.Add(tempObject.GetComponent<Note>());
    }

    public void InstanceLongNote(NoteData[] _data)
    {
        GameObject tempObject = Instantiate(longNote);
        tempObject.transform.parent = lines[_data[0].num - 1].parent;
        tempObject.transform.localRotation = Quaternion.identity;
        tempObject.transform.localPosition = new Vector3(lines[_data[0].num - 1].localPosition.x, lines[_data[0].num - 1].localPosition.y + (_data[0].time - (Time.time - playTime)) * speed, lines[_data[0].num - 1].localPosition.z);
        tempObject.GetComponent<Note>().num = _data[0].num;
        tempObject.GetComponent<Note>().time = _data[0].time;
        notes.Add(tempObject.GetComponent<Note>());
        tempObject.GetComponent<LongNote>().manager = this;
        for (int i = 1; i < _data.Length; i++)
        {
            GameObject subObject = Instantiate(longSubNote);
            subObject.transform.parent = lines[_data[1].num - 1].parent;
            subObject.transform.localRotation = Quaternion.identity;
            subObject.transform.localPosition = new Vector3(lines[_data[i].num - 1].localPosition.x, lines[_data[i].num - 1].localPosition.y + (_data[i].time - (Time.time - playTime)) * speed, lines[_data[i].num - 1].localPosition.z);
            subObject.GetComponent<Note>().num = _data[i].num;
            subObject.GetComponent<Note>().time = _data[i].time;
            tempObject.GetComponent<LongNote>().subNotes.Add(subObject.GetComponent<SubLongNote>());
            subObject.GetComponent<SubLongNote>().main = tempObject.GetComponent<LongNote>();
            notes.Add(subObject.GetComponent<Note>());
        }
    }

    IEnumerator test()
    {
        yield return new WaitForSeconds(1);
        InstanceShortNote(new NoteData(5, 2));
        yield return new WaitForSeconds(1);
        InstanceShortNote(new NoteData(6, 3));
        yield return new WaitForSeconds(1);
        InstanceSwipeNote(new NoteData(7, 3));
        yield return new WaitForSeconds(1);
        InstanceSwipeNote(new NoteData(8, 2));
        yield return new WaitForSeconds(1);
        InstanceSwipeNote(new NoteData(9, 1));
        yield return new WaitForSeconds(1);
        InstanceSwipeNote(new NoteData(10, 1));
        yield return new WaitForSeconds(1);
        InstanceSwipeNote(new NoteData(11, 3));
        yield return new WaitForSeconds(1);
        InstanceLongNote(new NoteData[3] { new NoteData(12, 1), new NoteData(12.5f, 2), new NoteData(13, 2) });
    }

    IEnumerator endGame()
    {
        yield return new WaitForSeconds(1);
        GameManager.Instance.score = scoreUI.score;
        GameManager.Instance.perfectCount = scoreUI.perfectCount;
        GameManager.Instance.goodCount = scoreUI.goodCount;
        GameManager.Instance.badCount = scoreUI.badCount;
        GameManager.Instance.missCount = scoreUI.missCount;
        GameManager.Instance.maxCombo = comboUI.GetMaxCombo();
        int sumScore = (scoreUI.perfectCount + scoreUI.goodCount + scoreUI.badCount + scoreUI.missCount) * 100;
        if(scoreUI.score > sumScore * 0.9)
        {
            GameManager.Instance.rank = Rank.S;
        }
        else if(scoreUI.score > sumScore * 0.8)
        {
            GameManager.Instance.rank = Rank.A;
        }
        else if (scoreUI.score > sumScore * 0.7)
        {
            GameManager.Instance.rank = Rank.B;
        }
        else if (scoreUI.score > sumScore * 0.6)
        {
            GameManager.Instance.rank = Rank.C;
        }
        else if (scoreUI.score > sumScore * 0.5)
        {
            GameManager.Instance.rank = Rank.D;
        }
        else
        {
            GameManager.Instance.rank = Rank.F;
        }
        sceneLoadManager.LoadScene("Result");
    }

    public void AllRemove()
    {
        for (int i = 0; i < notes.Count; i++)
        {
            GameObject dstemp = notes[i].gameObject;
            notes.Remove(notes[i]);
            Destroy(dstemp);
        }
    }

    public void  Pause()
    {
        music.Pause();
        play = false;
    }

    public void Continue()
    {
        music.Play();
        play = true;
        playTime = Time.time - music.time;
    }

    public void Restart()
    {
        sceneLoadManager.LoadScene("main");
    }

    public void BackToMenu()
    {
        sceneLoadManager.LoadScene("Scrolling");
    }
}
