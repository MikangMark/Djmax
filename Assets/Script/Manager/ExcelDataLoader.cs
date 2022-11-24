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

    Queue<int[]> note_q = new Queue<int[]>();
    string fileName;
    int bpm;
    int[] beat = new int[2];
    int playtime_Seconds;
    int total_Note = 0;

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
            int[] oneLine = new int[4];
            for(int j = 0; j < rowSize; j++)
            {
                if (i < infoLine)
                {
                    soundInfo[i, j] = row[j];//탭으로 구분된 원소들이 저장
                    //Debug.Log(soundInfo[i, j]); //음악정보 디버그
                }
                else
                {
                    note[i - infoLine, j] = int.Parse(row[j]);//숫자들하나씩저장
                    oneLine[j] = int.Parse(row[j]);
                    if (int.Parse(row[j]) == 1)
                    {
                        total_Note++;
                    }
                    //Debug.Log(note[i - infoLine, j]); //노트채보 디버그
                }
                note_q.Enqueue(oneLine);
            }
        }
        fileName = soundInfo[0, 1];
        bpm = int.Parse(soundInfo[1, 1]);
        beat[0] = int.Parse(soundInfo[2, 1]);
        beat[1] = int.Parse(soundInfo[2, 2]);
        playtime_Seconds = int.Parse(soundInfo[3, 1]) * 60 + int.Parse(soundInfo[3, 2]);
        Debug.Log(total_Note);
    }

}
