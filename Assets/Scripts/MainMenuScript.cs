using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{


    public void Play()
    {
        SceneManager.LoadScene("LevelMain");
    }

    public void GoToMain()
    {
        if (SceneManager.GetActiveScene().name.Equals("MainMenu"))
        {

            Application.Quit();
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GoToMain();
        }
    }
}
