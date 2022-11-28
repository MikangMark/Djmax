using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNoteMap : MonoBehaviour
{
    static public float default_Interval; //y��ǥ����
    static public float half_Interval;
    [HideInInspector]
    public GameObject[] startPositon;

    [SerializeField]
    NoteManager noteManager;

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
        Debug.Log(ExcelDataLoader.Instance.lineSize - ExcelDataLoader.Instance.infoLine);
        
        for (int i = 0; i < ExcelDataLoader.Instance.lineSize - ExcelDataLoader.Instance.infoLine; i++)
        {
            for (int j = 0; j < ExcelDataLoader.Instance.rowSize; j++)
            {
                if (ExcelDataLoader.Instance.note[i, j] == 1)//���߿� �ճ�Ʈ�߰��ҰŸ� 1�� enum�������� ����
                {
                    noteManager.CreateNote(j, i * default_Interval);
                    
                }
            }
        }
    }

}
