using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using LitJson;

public class NoteCreater : MonoBehaviour {


    JsonData JD;
    TextAsset TA;

    public MusicPlayer MP;

    public float musicTime;

    public float deltaCreatNote;

    public int ObjectCnt;
    public int actualNoteCnt;

    public float hitTime;

    public GameObject Note;

    public GameObject ParantNote;
    public PlayManager PM;
    private void Awake()
    {
        ParantNote = gameObject;
    }
    void Start ()
    {
        
    }
	
	void Update ()
    {
        musicTime = MP.AS.time;
	}

    public void LoadNotes()
    {
        TA = Resources.Load<TextAsset>("Notes/Stage1");
        JD = JsonMapper.ToObject(TA.text);

        ObjectCnt = JD["Notes"].Count;
        
        MP.PlayMusic();
        
        StartCoroutine(CreatNote(1.0f));
        Debug.Log(hitTime);

    }

    IEnumerator CreatNote(float StreamingSec)
    {
        for (int i = 0; i < ObjectCnt; i++)
        {
            actualNoteCnt = JD["Notes"][i]["Index"].Count;
            hitTime = float.Parse(JD["Notes"][i]["HitTime"].ToString());

            yield return new WaitUntil(() => musicTime >= hitTime-1f);

            for (int j = 0; j < actualNoteCnt; j++)
            {
                GameObject newNote = Instantiate(Note, new Vector3(0,-30,0), Quaternion.identity);
                newNote.transform.SetParent(ParantNote.transform);
                newNote.transform.localScale = new Vector3(1,1,1);
                newNote.transform.localPosition = new Vector3(0, -30, 0);

                newNote.GetComponent<Notes>().SetNote(int.Parse(JD["Notes"][i]["Index"][j]["Path"].ToString()));
            }
        }

        yield return new WaitUntil(()=> !MP.AS.isPlaying);

        PM.EndSong();
    }
}
