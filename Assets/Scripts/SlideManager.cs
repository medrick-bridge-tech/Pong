using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideManager : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    private MusicPlayer _musicPlayer;

    private void Start()
    {
        _musicPlayer = FindObjectOfType<MusicPlayer>();
        volumeSlider.value = _musicPlayer.GetComponent<AudioSource>().volume;
    }
    public void ChangeVolume()
    {
        
        _musicPlayer.GetComponent<AudioSource>().volume = volumeSlider.value;
    }
}