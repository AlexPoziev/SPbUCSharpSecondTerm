using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorrorSoundTrigger : MonoBehaviour
{
    public AudioSource FirstScarySound;

    public AudioSource SecondScarySound;

    public AudioSource ThirdScarySound;

    public AudioSource FourthScarySound;

    public int ChanceOfSound = 5;

    private void OnTriggerEnter(Collider other)
    {
        AudioSource[] scarySounds = new AudioSource[] { FirstScarySound, SecondScarySound, ThirdScarySound, FourthScarySound };

        foreach (var sound in scarySounds)
        {
            if (sound.isPlaying)
            {
                return;
            }
        }

        if (Random.Range(0, 101) < ChanceOfSound)
        {
            scarySounds[Random.Range(0, scarySounds.Length)].Play();
        }
    }
}
