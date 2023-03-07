using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class SelectSong : MonoBehaviour
{
    static int total = 0;
    [SerializeField]
    SelectManager selectManager;
    [SerializeField]
    int song_num = 0;
    TextMeshProUGUI songName_Tmp;
    // Start is called before the first frame update
    void Start()
    {
        selectManager = GameObject.Find("Manager").GetComponent<SelectManager>();
        song_num = total;
        total++;
    }
    public void OnClickBtn()
    {
        PlayerPrefs.SetInt("SelectSong", song_num);
        SceneManager.LoadScene("PlaySpace");
    }
}
