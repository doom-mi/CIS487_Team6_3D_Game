using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
   [Header("-----Audio Source--------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("------Audio Clip-------")]
    public AudioClip background;
    public AudioClip mainMenuMusic;
    public AudioClip CannonFire;
    public AudioClip ArrowFire;
    public AudioClip enemyHit;
    public AudioClip playerLoseLife;
    public AudioClip playerPlaceTower;
    public AudioClip waveStart;
    public AudioClip selectTower;
    [Header("------UI-------")]
    public AudioClip openPauseMenu;
    public AudioClip closePauseMenu;
    public AudioClip optionClicked;
    public AudioClip gameOver;
    [Header("-----Extras-----")]
    public AudioClip IfNeeded;

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
    
}