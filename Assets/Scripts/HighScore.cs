using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    static public int Score = 1000;
    // Start is called before the first frame update
    private void Awake()
    {
        if (PlayerPrefs.HasKey("ApplePicker_HighScore"))
        {
            Score = PlayerPrefs.GetInt("ApplePicker_HighScore");
        }

        PlayerPrefs.SetInt("ApplePicker_HighScore", Score);
    }

    // Update is called once per frame
    void Update()
    {
        var text = this.GetComponent<Text>();
        text.text = $"High Score: {Score}";

        if (Score > PlayerPrefs.GetInt("ApplePicker_HighScore"))
        {
            PlayerPrefs.SetInt("ApplePicker_HighScore", Score);
        }
    }
}
