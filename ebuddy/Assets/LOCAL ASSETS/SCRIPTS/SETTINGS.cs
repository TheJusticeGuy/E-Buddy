using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class SETTINGS : MonoBehaviour
{
    [Header("Audio Settings")]
    public Slider volumeSlider;
    public AudioSource musicSource;

    [Header("Music Selection")]
    public TMP_Dropdown musicDropdown;
    public List<AudioClip> musicClips;   // Assign in Inspector
    public List<string> musicNames;      // Assign in Inspector

    void Start()
    {
        // Load volume setting
        float savedVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        volumeSlider.value = savedVolume;
        musicSource.volume = savedVolume;
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);

        // Load music dropdown
        musicDropdown.ClearOptions();
        musicDropdown.AddOptions(musicNames);

        int savedMusicIndex = PlayerPrefs.GetInt("SelectedMusic", 0);
        musicDropdown.value = savedMusicIndex;
        musicDropdown.onValueChanged.AddListener(OnMusicChanged);

        PlayMusic(savedMusicIndex);
    }

    public void OnVolumeChanged(float value)
    {
        musicSource.volume = value;
        PlayerPrefs.SetFloat("MusicVolume", value);
    }

    public void OnMusicChanged(int index)
    {
        PlayerPrefs.SetInt("SelectedMusic", index);
        PlayMusic(index);
    }

    void PlayMusic(int index)
    {
        if (index >= 0 && index < musicClips.Count && musicClips[index] != null)
        {
            musicSource.Stop();
            musicSource.clip = musicClips[index];
            musicSource.Play();
        }
        else
        {
            Debug.LogWarning("Invalid music index or clip is missing.");
        }
    }
}
