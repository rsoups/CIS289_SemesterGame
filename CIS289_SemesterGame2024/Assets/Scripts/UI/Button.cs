using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public AreaEffector2D windCurrent;
    public GameObject buttonOff;
    public GameObject buttonOn;
    public SpriteRenderer wind;

    // Start is called before the first frame update
    void Start()
    {
        buttonOn.SetActive(false);
        windCurrent.enabled = false;
        wind.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //button to turn on wind
    void OnTriggerEnter2D(Collider2D other)
    {  
        if(other.gameObject.CompareTag("Player"))
        {
            buttonOff.SetActive(false);
            buttonOn.SetActive(true);
            windCurrent.enabled = true;
            wind.enabled = true;
        }
    }
}
