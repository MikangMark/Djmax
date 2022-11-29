using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    public List<GameObject> boxNoteList = new List<GameObject>();
    /*[SerializeField]
    Transform Center = null;
    [SerializeField]
    RectTransform[] timingRect = null;
    Vector2[] timingBoxs = null;*/
    [SerializeField]
    Transform[] Center = null;
    [SerializeField]
    RectTransform[] timingRect_0 = null;
    [SerializeField]
    RectTransform[] timingRect_1 = null;
    [SerializeField]
    RectTransform[] timingRect_2 = null;
    [SerializeField]
    RectTransform[] timingRect_3 = null;
    [SerializeField]
    RectTransform[,] timingRect = null;
    int line = 4;
    int judge_Count = 4;
    [SerializeField]
    Vector2[,] timingBoxs = null;

    // Start is called before the first frame update
    void Start()
    {
        timingBoxs = new Vector2[line, judge_Count];
        timingRect = new RectTransform[line, judge_Count];
        for(int i = 0; i < line; i++)
        {
            for(int j = 0; j < judge_Count; j++)
            {
                switch (j)
                {
                    case 0:
                        timingRect[i, j] = timingRect_0[j];
                        break;
                    case 1:
                        timingRect[i, j] = timingRect_1[j];
                        break;
                    case 2:
                        timingRect[i, j] = timingRect_2[j];
                        break;
                    case 3:
                        timingRect[i, j] = timingRect_3[j];
                        break;
                }

                
            }
        }
        for (int i = 0; i < line; i++)
        {
            for(int j = 0; j < judge_Count; j++)
            {
                timingBoxs[i, j].Set(Center[i].localPosition.y - timingRect[i, j].rect.height * 0.5f, Center[i].localPosition.y + timingRect[i, j].rect.height * 0.5f);
            }
            
        }
        /*timingBoxs = new Vector2[timingRect.Length];
        for (int i = 0; i < timingRect.Length; i++)
        {
            timingBoxs[i].Set(Center.localPosition.y - timingRect[i].rect.height * 0.5f, Center.localPosition.y + timingRect[i].rect.height * 0.5f);
        }*/
    }
    public void CheckTiming(int line)
    {
        for(int i = 0; i < boxNoteList.Count; i++)
        {
            float t_notePosY = boxNoteList[i].transform.localPosition.y;

            for (int y = 0; y < judge_Count; y++)
            {
                if (timingBoxs[line, y].x <= t_notePosY && t_notePosY <= timingBoxs[line, y].y)
                {
                    if(line == boxNoteList[i].GetComponent<Note>().line_num)
                    {
                        boxNoteList[i].GetComponent<Note>().HideNote();
                        boxNoteList.RemoveAt(i);
                        Debug.Log("Hit" + line);
                    }
                    return;
                }
            }
        }
        /*for (int i = 0; i < boxNoteList.Count; i++)
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
        }*/
        Debug.Log("Miss");
    }
}
