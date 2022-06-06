using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip audiowalk;
    public AudioClip audiohit;
    public AudioClip audioshot;
    public AudioClip audioblank;
    AudioSource audioSource;
    AudioSource audioSource2;   
    AudioSource audioSource3;
    AudioSource audioSource4;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource2 = GetComponent<AudioSource>();          
        audioSource3 = GetComponent<AudioSource>();
        audioSource4 = GetComponent<AudioSource>();
    }
    public void PlaySound(string action)
    {        
        switch (action)
        {
           
            case "walk":
                audioSource.clip = audiowalk;
                audioSource.Play();
                break;

            case "hit":
                audioSource2.clip = audiowalk;
                audioSource2.Play();
                break;

            case "shot":
                audioSource3.clip = audiowalk;
                audioSource3.Play();
                break;

            case "blank":
                audioSource4.clip = audiowalk;
                audioSource4.Play();
                break;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
