using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Example/Create ExampleAsset Instance")]
public class MusicNote : ScriptableObject
{

    public AudioClip music;
    public List<Notes> notes = new List<Notes>();
    
}

[System.Serializable]
public class Notes
{
    public float time;
    public int num;
    public Note.NoteKind noteKind;
}

