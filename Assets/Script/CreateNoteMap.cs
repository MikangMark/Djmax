using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNoteMap : MonoBehaviour
{
    public float default_Interval;
    public float half_Interval;
    private void Awake()
    {
        default_Interval = 70;
        half_Interval = default_Interval * 0.5f;
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < ExcelDataLoader.Instance.Sentence.Length; i++)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
