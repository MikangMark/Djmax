using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectManager : MonoBehaviour
{
    public string[] songName;
    public int[] bpm;
    [SerializeField]
    List<GameObject> songList;
    [SerializeField]
    GameObject selectSong_BtnPrefab;
    [SerializeField]
    GameObject createTargetObject;
    [SerializeField]
    TextMeshProUGUI bpm_Text;
    [SerializeField]
    TextMeshProUGUI songTitle_text;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < songName.Length; i++)
        {
            GameObject temp = Instantiate(selectSong_BtnPrefab);
            temp.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = songTitle_text.text = songName[i];
            temp.transform.parent = createTargetObject.transform;
            songList.Add(temp);

            bpm_Text.text = "BPM: " + bpm[i].ToString();
        }
    }
}
