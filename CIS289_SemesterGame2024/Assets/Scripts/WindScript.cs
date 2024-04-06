using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindScript : MonoBehaviour
{
    public AreaEffector2D windCurrent3;
    public AreaEffector2D windCurrent4;
    public SpriteRenderer wind3;
    public SpriteRenderer wind4;
    private float startTime = 0f;
    private float repeatTime = 5f;
    private bool windCurrentOn = false;

    // Start is called before the first frame update
    void Start()
    {
        windCurrent3.enabled = false;
        wind3.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        windActivation();
    }

    void windActivation()
    {
        startTime += Time.deltaTime;

        if(startTime >= repeatTime && windCurrentOn == false)
        {
            windCurrentOn = true;
            windCurrent3.enabled = true;
            wind3.enabled = true;
            startTime = 0f;
            windCurrent4.enabled = false;
            wind4.enabled = false;
        }

        if(startTime >= repeatTime && windCurrentOn == true)
        {
            windCurrentOn = false;
            windCurrent3.enabled = false;
            wind3.enabled = false;
            startTime = 0f;
            windCurrent4.enabled = true;
            wind4.enabled = true;
        }

    }
}
