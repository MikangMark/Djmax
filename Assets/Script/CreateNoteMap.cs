using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNoteMap : MonoBehaviour
{
    public float default_Interval; //yÁÂÇ¥°£°Ý
    public float half_Interval;
    [HideInInspector]
    public GameObject[] startPositon;
    private void Awake()
    {
        default_Interval = 70;
        half_Interval = default_Interval * 0.5f;
    }
    // Start is called before the first frame update
    void Start()
    {
        startPositon = new GameObject[4];
        for(int i = 0; i < 4; i++)
        {
            startPositon[i] = GameObject.Find("NoteAppearLocation_" + i);
        }
        Debug.Log(ExcelDataLoader.Instance.note.Length);

        for (int i = 0; i < ExcelDataLoader.Instance.note.Length; i++)
        {
            if (i % 4 == 0)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (ExcelDataLoader.Instance.note[i, j] == 1)
                    {
                        NoteManager.Instance.CreateNote(j);
                    }
                }
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
