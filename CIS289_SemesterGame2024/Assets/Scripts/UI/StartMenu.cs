using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public GameObject startMenuUI;

    public void StartGame()
    {
        SceneManager.LoadScene("Wind Level");
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("Level Select");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
