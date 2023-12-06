using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Slider musicSlider;


    public void Start()
    {
        SetVolume();
        SetMusicVolume();
    }

    public void SetVolume()
    {
        float volume = volumeSlider.value;
        myMixer.SetFloat("volume", Mathf.Log10(volume)*20);
    }
    public void SetMusicVolume()
    {
        float music = musicSlider.value;
        myMixer.SetFloat("music", Mathf.Log10(music) *20);
    }
}
