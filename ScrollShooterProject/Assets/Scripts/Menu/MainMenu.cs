﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Level");
    }
    public void Settings()
    {
        throw new System.NotImplementedException();
    }
    public void Quit()
    {
        Application.Quit();
    }
}
