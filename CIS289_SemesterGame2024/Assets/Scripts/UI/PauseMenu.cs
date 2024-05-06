using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    // public void RestartLevel()
    // {
    //     if(SceneManager.GetActiveScene().name == "Wind Level")
    //     {
    //         SceneManager.LoadScene("Wind Level");
    //     }

    //     if(SceneManager.GetActiveScene().name == "Water Level")
    //     {
    //         SceneManager.LoadScene("Water Level");
    //     }

    //     if(SceneManager.GetActiveScene().name == "Fire Level")
    //     {
    //         SceneManager.LoadScene("Fire Level");
    //     }
    // }

    public void Quit()
    {
        Application.Quit();
    }
}
