using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    public GameObject textbox;
    public TMP_Text textComponent;
    public float textSpeed;
    public string[] lines;
    private int index;
    public AudioClip textSoundClip;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        startDialogue();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if(textComponent.text == lines[index])
            {
                nextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void startDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
            audioSource.clip = textSoundClip;
            audioSource.Play();
        }
    }

    void nextLine()
    {
        if(index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            textbox.SetActive(false);

            if(SceneManager.GetActiveScene().name == "WindToWater")
            {
                SceneManager.LoadScene("Water Level");
            }

            if(SceneManager.GetActiveScene().name == "WaterToFire")
            {
                SceneManager.LoadScene("Fire Level");
            }

            if(SceneManager.GetActiveScene().name == "FireToEndGame")
            {
                SceneManager.LoadScene("Start");
            }
        }
    }
}
