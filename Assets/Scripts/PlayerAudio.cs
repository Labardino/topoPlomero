using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class PlayerAudio : MonoBehaviour
{
    public AudioSource playerSound;

    public AudioClip[] clipSounds;
    
    private void stepSound()
    {
        playerSound.PlayOneShot(clipSounds[0]);
    }
    private void slideSound()
    {
        playerSound.PlayOneShot(clipSounds[2]);
    }
    private void spinSound()
    {
        playerSound.PlayOneShot(clipSounds[1]);
    }

}
