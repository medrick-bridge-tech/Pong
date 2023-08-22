using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideManager : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Slider aiDifficultySlider;
    private MusicPlayer _musicPlayer;
    private GameSituation _gameSituation;

    private void Start()
    {
        _musicPlayer = FindObjectOfType<MusicPlayer>();
        _gameSituation = FindObjectOfType<GameSituation>();
        volumeSlider.value = _musicPlayer.GetComponent<AudioSource>().volume;
        aiDifficultySlider.value = _gameSituation.GetComponent<GameSituation>().GetAIDifficulty();
    }
    public void ChangeVolume()
    {
        _musicPlayer.GetComponent<AudioSource>().volume = volumeSlider.value;
    }

    public void ChangeAIDifficulty()
    {
        _gameSituation.GetComponent<GameSituation>().SetAIDifficulty(aiDifficultySlider.value);
    }
}