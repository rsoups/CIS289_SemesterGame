using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject player;
    public GameObject respawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        //newRespawnPoint = GameObject.Find("Player").GetComponent<Death>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            player.transform.position = respawnPoint.transform.position;
        }
    }
}
