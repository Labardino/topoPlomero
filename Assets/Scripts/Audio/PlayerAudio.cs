using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class PlayerAudio : MonoBehaviour
{
    #region Singleton
    public static PlayerAudio instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion
    public AudioSource playerSound;

    public AudioClip[] clipSounds;
    private PlayerManager playerInfo;

    private void Start()
    {
        playerInfo = FindObjectOfType<PlayerManager>();
    }
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
    private void fireSound()
    {
        playerSound.PlayOneShot(clipSounds[0]);
    }
    private void flySound()
    {
        playerSound.PlayOneShot(clipSounds[0]);
    }

    public void hurtSound()
    {
        playerSound.PlayOneShot(clipSounds[3]);
    }

}
