using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EndGame : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI songTitle_Text;
    [SerializeField]
    TextMeshProUGUI maxcombo_Text;
    [SerializeField]
    TextMeshProUGUI perfect_Text;
    [SerializeField]
    TextMeshProUGUI great_Text;
    [SerializeField]
    TextMeshProUGUI bad_Text;
    [SerializeField]
    TextMeshProUGUI miss_Text;
    private void Start()
    {
        maxcombo_Text.text = "MaxCombo:\t" + PlayerPrefs.GetInt("MaxCombo");
        perfect_Text.text = "Perfect:\t" + PlayerPrefs.GetInt("Perfect");
        great_Text.text = "Great:\t" + PlayerPrefs.GetInt("Great");
        bad_Text.text = "Bad:\t\t" + PlayerPrefs.GetInt("Bad");
        miss_Text.text = "Miss:\t\t" + PlayerPrefs.GetInt("Miss");

    }
    public void OnClickBtn()
    {
        Application.Quit(0);
    }
}
