using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFollowingCat : MonoBehaviour

{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

        // Met à jour la position du son pour correspondre à la position du chat
        audioSource.transform.position = transform.position;
    }
}

