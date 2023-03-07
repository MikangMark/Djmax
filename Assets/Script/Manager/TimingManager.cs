using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TimingManager : MonoBehaviour
{
    public List<GameObject> boxNoteList = new List<GameObject>();
    /*[SerializeField]
    Transform Center = null;
    [SerializeField]
    RectTransform[] timingRect = null;
    Vector2[] timingBoxs = null;*/
    [SerializeField]
    TextMeshProUGUI judgePrint;
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
    int combo;
    int maxCombo;
    [SerializeField]
    Vector2[,] timingBoxs = null;
    public int[] judgeTotal_Count;

    // Start is called before the first frame update
    void Start()
    {
        judgePrint.gameObject.SetActive(false);
        combo = maxCombo = 0;
        timingBoxs = new Vector2[line, judge_Count];
        timingRect = new RectTransform[line, judge_Count];
        judgeTotal_Count = new int[4] { 0, 0, 0, 0 };
        for (int i = 0; i < line; i++)
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
            if(boxNoteList[i].GetComponent<Note>().line_num == line)
            {
                float t_notePosY = boxNoteList[i].transform.localPosition.y;

                for (int y = 0; y < judge_Count; y++)
                {
                    if (timingBoxs[line, y].x <= t_notePosY && t_notePosY <= timingBoxs[line, y].y)
                    {
                        boxNoteList[i].GetComponent<Note>().HideNote();
                        boxNoteList.RemoveAt(i);
                        judgeTotal_Count[y]++;
                        if (y < 2)
                        {
                            combo++;
                            if (maxCombo <= combo)
                            {
                                maxCombo = combo;
                            }
                            
                        }
                        else
                        {
                            combo = 0;
                        }
                        StartCoroutine(PrintJudge(y));
                        PlayerPrefs.SetInt("MaxCombo", maxCombo);
                        Debug.Log("Hit" + line);
                        return;
                    }
                }
            }
        }
    }
    IEnumerator PrintJudge(int judge)
    {
        switch (judge)
        {
            case 0:
                judgePrint.text = "Perfect";
                break;
            case 1:
                judgePrint.text = "Great";
                break;
            case 2:
                judgePrint.text = "Bad";
                break;
            case 3:
                judgePrint.text = "Miss";
                break;

        }
        judgePrint.gameObject.SetActive(true);
        
        yield return new WaitForSeconds(1.0f);
        judgePrint.gameObject.SetActive(false);
    }
}
