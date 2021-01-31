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
        SceneManager.LoadScene("MainMenu");
    }
}
