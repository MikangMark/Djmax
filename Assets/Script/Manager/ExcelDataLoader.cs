using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExcelDataLoader : MonoBehaviour
{
    public static ExcelDataLoader instance = null;
    public TextAsset txt;
    public string[,] Sentence;
    [SerializeField]
    int lineSize, rowSize;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    public static ExcelDataLoader Instance
    {
        get
        {
            if(null == instance)
            {
                return null;
            }
            return instance;
        }
    }


    void Start()
    {
        
        string currentText = txt.text.Substring(0, txt.text.Length - 1);
        string[] line = currentText.Split('\n');
        lineSize = line.Length;
        rowSize = line[0].Split('\t').Length;
        Sentence = new string[lineSize, rowSize];

        for(int i = 0; i < lineSize; i++)
        {
            string[] row = line[i].Split('\t');
            for(int j = 0; j < rowSize; j++)
            {
                Sentence[i, j] = row[j];
            }
        }
    }

}
