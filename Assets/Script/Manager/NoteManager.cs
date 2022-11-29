using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public int bpm = 0;
    double currentTime = 0d;

    //[SerializeField]
    //Transform[] tfNoteAppear = null;
    [SerializeField]
    Transform[] tfNoteAppear_Default = null;
    TimingManager theTimingManager;

    private void Start()
    {
        theTimingManager = GetComponent<TimingManager>();
        //tfNoteAppear_Default = tfNoteAppear;
    }
    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= 60d / bpm)
        {
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            theTimingManager.boxNoteList.Remove(collision.gameObject);
            
            ObjectPool.instance.noteQueue.Enqueue(collision.gameObject);
            collision.gameObject.SetActive(false);
        }
    }
    public void CreateNote(int lineNum, float delayPos_y)
    {
        GameObject t_note = ObjectPool.instance.noteQueue.Dequeue();
        t_note.GetComponent<Note>().line_num = lineNum;
        t_note.transform.position = tfNoteAppear_Default[lineNum].position + Vector3.up * delayPos_y;
        
        //t_note.transform.position = tfNoteAppear[lineNum].position;
        t_note.SetActive(true);

        theTimingManager.boxNoteList.Add(t_note);
        currentTime -= 60d / bpm;
    }
}
