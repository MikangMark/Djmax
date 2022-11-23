using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExcelDataLoader : Singleton<ExcelDataLoader>
{
    public TextAsset txt;
    public string[,] soundInfo;
    public int[,] note;
    [SerializeField]
    int lineSize, rowSize, infoLine;

    string fileName;
    int bpm;
    int[] beat = new int[2];
    int playtime_Seconds;

    void Start()
    {
        infoLine = 4;
        string currentText = txt.text.Substring(0, txt.text.Length - 1);
        string[] line = currentText.Split('\n');
        lineSize = line.Length;
        rowSize = line[0].Split('\t').Length;
        soundInfo = new string[infoLine, rowSize];
        note = new int[lineSize - infoLine, rowSize];

        for(int i = 0; i < lineSize; i++)
        {
            string[] row = line[i].Split('\t');
            for(int j = 0; j < rowSize; j++)
            {
                if (i < 5)
                {
                    soundInfo[i, j] = row[j];
                    Debug.Log(soundInfo[i, j]);
                }
                else
                {
                    note[i, j] = int.Parse(row[j]);
                }
                
            }
        }
        fileName = soundInfo[0, 1];
        bpm = int.Parse(soundInfo[1, 1]);
        beat[0] = int.Parse(soundInfo[2, 1]);
        beat[1] = int.Parse(soundInfo[2, 2]);
        playtime_Seconds = int.Parse(soundInfo[3, 1]) * 60 + int.Parse(soundInfo[3, 2]);
    }

}
