using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public int bpm = 0;
    double currentTime = 0d;

    [SerializeField]
    Transform[] tfNoteAppear = null;
    TimingManager theTimingManager;

    private void Start()
    {
        theTimingManager = GetComponent<TimingManager>();

    }
    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= 60d / bpm)
        {
            //CreateNote(0);
            //CreateNote(1);
            //CreateNote(2);
            //CreateNote(3);
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
        tfNoteAppear[lineNum].position = new Vector3(tfNoteAppear[lineNum].position.x, tfNoteAppear[lineNum].position.y + delayPos_y, tfNoteAppear[lineNum].position.z);
        t_note.transform.position = tfNoteAppear[lineNum].position;
        t_note.SetActive(true);

        theTimingManager.boxNoteList.Add(t_note);
        currentTime -= 60d / bpm;
    }
}
