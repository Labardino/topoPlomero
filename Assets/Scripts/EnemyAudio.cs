using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{

    public AudioSource fireshootSound;
    public AudioSource flySound;


    private void fireSound()
    {
        fireshootSound.Play();
    }
    private void GliceSound()
    {
        flySound.Play();
    }

}
