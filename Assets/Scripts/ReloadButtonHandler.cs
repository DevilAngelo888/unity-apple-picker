﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadButtonHandler : MonoBehaviour
{
    public void ReloadGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
