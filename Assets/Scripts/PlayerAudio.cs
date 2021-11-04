using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAudio : MonoBehaviour
{
    public AudioSource stepsSound;
    public AudioSource slidesSound;
    public AudioSource spinsSound;

    
    private void stepSound()
    {
        stepsSound.Play();
    }
    private void slideSound()
    {
        slidesSound.Play();
    }
    private void spinSound()
    {
        spinsSound.Play();
    }

}
