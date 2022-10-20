using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    TMP_Text text;
    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    void Update()
    {
        if(Mathf.FloorToInt(Time.time % 60) <= 9)
        {
            text.SetText(Mathf.FloorToInt(Time.timeSinceLevelLoad / 60) + ":0" + Mathf.FloorToInt(Time.timeSinceLevelLoad % 60));
        }
        else
        {
            text.SetText(Mathf.FloorToInt(Time.timeSinceLevelLoad / 60) + ":" + Mathf.FloorToInt(Time.timeSinceLevelLoad % 60));
        }
    }
}
