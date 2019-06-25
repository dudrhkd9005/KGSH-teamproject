using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongNote : MonoBehaviour
{
    public bool touched;
    public Transform startpo;
    public List<SubLongNote> subNotes = new List<SubLongNote>();
    public List<Transform> lines = new List<Transform>();
    public GameObject lineObj;
    public int step;
    public float linepo;
    public InGameManager manager;
    //public GameObject follow;
    // Start is called before the first frame update
    void Start()
    {
        GameObject temp = Instantiate(lineObj);
        temp.transform.parent = transform;
        temp.transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y,Mathf.Atan((subNotes[0].transform.localPosition.y - transform.localPosition.y)/(subNotes[0].transform.localPosition.x - transform.localPosition.x)) * Mathf.Rad2Deg - 90f);
        temp.transform.GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(temp.transform.GetChild(0).GetComponent<SpriteRenderer>().size.x, Vector2.Distance(transform.localPosition, subNotes[0].transform.localPosition));
        temp.transform.localPosition = (subNotes[0].transform.localPosition - transform.localPosition) / 2;
        temp.transform.parent = subNotes[0].transform;

        for (int i = 1; i < subNotes.Count; i++)
        {
            GameObject temp_ = Instantiate(lineObj);
            temp_.transform.parent = transform;
            temp_.transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, subNotes[i - 1].transform.localRotation.eulerAngles.y, Mathf.Atan((subNotes[i].transform.localPosition.y - subNotes[i - 1].transform.localPosition.y) / (subNotes[i].transform.localPosition.x - subNotes[i - 1].transform.localPosition.x)) * Mathf.Rad2Deg - 90f);
            temp_.transform.GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(temp_.transform.GetChild(0).GetComponent<SpriteRenderer>().size.x, Vector2.Distance(subNotes[i - 1].transform.localPosition, subNotes[i].transform.localPosition));
            temp_.transform.localPosition = ((subNotes[i].transform.localPosition + subNotes[i-1].transform.localPosition) / 2) - transform.localPosition;
            temp_.transform.parent = subNotes[i].transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (touched)
        //{
        //    if (step == 0)
        //    {
        //        follow.transform.localPosition = transform.localPosition;
        //        if (transform.localPosition.y < linepo)
        //        {
        //            startpo = transform;
        //            step++;
        //        }
        //    }
        //    else
        //    {
        //        Vector3.Lerp(startpo.localPosition, subNotes[step - 1].transform.localPosition, (linepo - startpo.localPosition.y) / subNotes[step - 1].transform.localPosition.y - startpo.localPosition.y);
        //        if (subNotes[step - 1].transform.localPosition.y < linepo)
        //        {
        //            startpo = subNotes[step - 1].transform;
        //            step++;
        //        }
        //    }
        //}

        for (int i = 0; i < subNotes.Count; i++)
        {
            if (subNotes[i].transform.localPosition.y > -15 && subNotes[subNotes.Count-1].GetComponent<Note>().off == false)
            {
                return;
            }
        }
        for (int i = 0; i < subNotes.Count; i++)
        {
            manager.notes.Remove(subNotes[i].GetComponent<Note>());
            Destroy(subNotes[i].gameObject);
        }
        for (int i = 0; i < lines.Count; i++)
        {
            Destroy(lines[i].gameObject);
        }
        manager.notes.Remove(GetComponent<Note>());
        Destroy(gameObject);
    }

    public void Miss()
    {
        transform.GetComponent<Note>().off = true;
        for(int i = 0; i < subNotes.Count; i++)
        {
            subNotes[i].GetComponent<Note>().off = true;
            subNotes[i].transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.gray;
        }
        for(int i = 0; i < lines.Count; i++)
        {
            lines[i].GetChild(0).GetComponent<SpriteRenderer>().color = Color.gray;
        }
    }

    public void CheckRemove()
    {

    }

    public void Touch()
    {
        touched = true;
        GetComponent<Note>().off = true;
        //follow = Instantiate(subNotes[0].gameObject);
        //follow.transform.parent = transform.parent;
        //follow.transform.localPosition = transform.localPosition;
    }
}
