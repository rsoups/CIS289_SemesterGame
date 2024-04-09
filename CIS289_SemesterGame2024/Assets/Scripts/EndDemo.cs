using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndDemo : MonoBehaviour
{
    public GameObject restart;
    public GameObject exit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void restartGame()
    {
        SceneManager.LoadScene("Wind Level");
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
