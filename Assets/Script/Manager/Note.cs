using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    public float noteSpeed;
    public int line_num;

    Image noteImage;
    // Update is called once per frame
    private void OnEnable()
    {
        if(noteImage == null)
        {
            noteImage = GetComponent<Image>();
        }

        noteImage.enabled = true;
    }
    void Update()
    {
        transform.localPosition += Vector3.down * noteSpeed * Time.deltaTime;
    }
    public void HideNote()
    {
        noteImage.enabled = false;
    }
}
