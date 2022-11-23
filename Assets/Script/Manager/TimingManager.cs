using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    public List<GameObject> boxNoteList = new List<GameObject>();
    [SerializeField]
    Transform Center = null;
    [SerializeField]
    RectTransform[] timingRect = null;
    Vector2[] timingBoxs = null;
    /*[SerializeField]
    Transform[] Center = null;
    [SerializeField]
    RectTransform[][] timingRect = null;
    [SerializeField]
    Vector2[][] timingBoxs = null;*/

    // Start is called before the first frame update
    void Start()
    {
        /*timingBoxs = new Vector2[4][];
        for(int i = 0; i < timingBoxs.Length; i++)
        {
            timingBoxs[i] = new Vector2[timingRect[i].Length];
        }
        
        for (int i = 0; i < timingRect.Length; i++)
        {
            for(int j = 0; j < timingRect[i].Length; j++)
            {
                timingBoxs[i][j].Set(Center[i].localPosition.y - timingRect[i][j].rect.height * 0.5f, Center[i].localPosition.y + timingRect[i][j].rect.height * 0.5f);
            }
            
        }*/
        timingBoxs = new Vector2[timingRect.Length];
        for (int i = 0; i < timingRect.Length; i++)
        {
            timingBoxs[i].Set(Center.localPosition.y - timingRect[i].rect.height * 0.5f, Center.localPosition.y + timingRect[i].rect.height * 0.5f);
        }
    }
    public void CheckTiming()
    {
        /*for(int i = 0; i < boxNoteList.Count; i++)
        {
            float t_notePosY = boxNoteList[i].transform.localPosition.y;

            for(int yi = 0; yi < timingBoxs.Length; yi++)
            {
                for(int yj = 0; yj < timingBoxs[yi].Length; yj++)
                {
                    if (timingBoxs[yi][yj].x <= t_notePosY && t_notePosY <= timingBoxs[yi][yj].y)
                    {
                        boxNoteList[i].GetComponent<Note>().HideNote();
                        boxNoteList.RemoveAt(i);
                        Debug.Log("Hit" + yj);
                        return;
                    }
                }
            }
        }*/
        for (int i = 0; i < boxNoteList.Count; i++)
        {
            float t_notePosY = boxNoteList[i].transform.localPosition.y;

            for (int y = 0; y < timingBoxs.Length; y++)
            {
                if (timingBoxs[y].x <= t_notePosY && t_notePosY <= timingBoxs[y].y)
                {
                    boxNoteList[i].GetComponent<Note>().HideNote();
                    boxNoteList.RemoveAt(i);
                    Debug.Log("Hit" + y);
                    return;
                }
            }
        }
        Debug.Log("Miss");
    }
}
