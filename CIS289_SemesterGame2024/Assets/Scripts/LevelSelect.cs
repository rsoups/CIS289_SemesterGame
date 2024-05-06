using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public GameObject levelSelectUI;

    public void WindLevel()
    {
        SceneManager.LoadScene("Wind Level");
    }

    public void WaterLevel()
    {
        SceneManager.LoadScene("Water Level");
    }

    public void FireLevel()
    {
        SceneManager.LoadScene("Fire Level");
    }

    public void Back()
    {
        SceneManager.LoadScene("Start");
    }
}
