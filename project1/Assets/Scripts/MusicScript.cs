using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    private AudioSource audioSource;
    private bool isPlaying = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (isPlaying)
            {
                audioSource.Pause();
            }
            else
            {
                audioSource.Play();
            }

            isPlaying = !isPlaying;
        }
    }
}