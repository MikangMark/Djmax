using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    Image mainMenu;
    [SerializeField]
    Image option;

    [SerializeField]
    Button play_Btn;
    [SerializeField]
    Button option_Btn;
    [SerializeField]
    Button exit_Btn;

    bool play_option;

    [SerializeField]
    Scrollbar volum;
    // Start is called before the first frame update
    void Start()
    {
        play_option = true;
        volum.value = 0.6f;
        mainMenu.gameObject.SetActive(play_option);
        option.gameObject.SetActive(!play_option);
    }

    public void OnClickPlay_Btn()
    {
        SceneManager.LoadScene("SelectSong");
    }
    public void ChangeVolum()
    {
        PlayerPrefs.SetFloat("volum", volum.value);
    }

    public void OnClickPlay_Option_Btn()
    {
        play_option = !play_option;
        mainMenu.gameObject.SetActive(play_option);
        option.gameObject.SetActive(!play_option);
    }
    public void OnClickExit_Btn()
    {
        Application.Quit(0);
    }
}
