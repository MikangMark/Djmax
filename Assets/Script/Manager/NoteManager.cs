using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NoteManager : MonoBehaviour
{
    public int bpm = 0;
    [SerializeField]
    float currentTime;
    [SerializeField]
    float endGameTIme;

    //[SerializeField]
    //Transform[] tfNoteAppear = null;
    [SerializeField]
    Transform[] tfNoteAppear_Default = null;
    TimingManager theTimingManager;

    private void Start()
    {
        theTimingManager = GetComponent<TimingManager>();
        currentTime = 0f;
        //tfNoteAppear_Default = tfNoteAppear;
    }
    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= endGameTIme)
        {
            PlayerPrefs.SetInt("Perfect", theTimingManager.judgeTotal_Count[0]);
            PlayerPrefs.SetInt("Great", theTimingManager.judgeTotal_Count[1]);
            PlayerPrefs.SetInt("Bad", theTimingManager.judgeTotal_Count[2]);
            PlayerPrefs.SetInt("Miss", theTimingManager.judgeTotal_Count[3]);
            SceneManager.LoadScene("EndingScene");
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
        t_note.SetActive(true);

        theTimingManager.boxNoteList.Add(t_note);
    }
}
