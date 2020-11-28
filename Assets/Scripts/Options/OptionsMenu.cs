using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer m_Mixer;
    public Slider m_MusicSlider;
    public Slider m_SfxSlider;

    private float m_CurrentMusicVolume;
    private float m_CurrentSfxVolume;

    public void Start()
    {
        LoadSettings();

        float music, sfx;

        if (m_Mixer.GetFloat("Music", out music))
        {
            if (m_MusicSlider) m_MusicSlider.value = music;
        }

        if (m_Mixer.GetFloat("Sfx", out sfx))
        {
            if (m_SfxSlider) m_SfxSlider.value = sfx;
        }
    }

    public void SetMusicVolume(float volume)
    {
        m_Mixer.SetFloat("Music", volume);
        m_CurrentMusicVolume = volume;
    }

    public void SetSfxVolume(float volume)
    { 
        m_Mixer.SetFloat("Sfx", volume);
        m_CurrentSfxVolume = volume;
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("Music", m_CurrentMusicVolume);
        PlayerPrefs.SetFloat("Sfx", m_CurrentSfxVolume);
    }

    public void LoadSettings()
    {
        if (PlayerPrefs.HasKey("Music"))
            SetMusicVolume(PlayerPrefs.GetFloat("Music"));
        else
            SetMusicVolume(10.0f);

        if (PlayerPrefs.HasKey("Sfx"))
            SetSfxVolume(PlayerPrefs.GetFloat("Sfx"));
        else
            SetSfxVolume(10.0f);
    }
}
