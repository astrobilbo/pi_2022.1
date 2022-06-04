using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown qualityDropdown;
    public Toggle fullScreenToggle;
    public Scrollbar sound;
    public Toggle Mute;
    Resolution[] resolutions;
    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width+" x "+ resolutions[i].height + " " + resolutions[i].refreshRate + "hz";
            options.Add(option);
            if (resolutions[i].width== Screen.width && resolutions[i].height== Screen.height)
            {
                currentResolutionIndex= i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value=currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        qualityDropdown.value=QualitySettings.GetQualityLevel();
        qualityDropdown.RefreshShownValue();
        fullScreenToggle.isOn=Screen.fullScreen;
        //sound.value=PlayerPrefs.GetFloat("volume",sound.value);
        //udioManager.audioManager.musicAudioSourcer.volume=sound.value;
        //udioManager.audioManager.SFXAudioSourcer.volume=sound.value;
        //udioManager.audioManager.backgroundAudioSourcer.volume=sound.value;

    }
    public void SetVolume(float volume)
    {
        //AudioManager.audioManager.musicAudioSourcer.volume=volume;
        //AudioManager.audioManager.SFXAudioSourcer.volume=volume;
        //AudioManager.audioManager.backgroundAudioSourcer.volume=volume;
    }

    public void SetQuality(int QualityIndex)
    {
        QualitySettings.SetQualityLevel(QualityIndex);
    }
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
    public void SetResolutions(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width,resolution.height,Screen.fullScreen);
    }
    private void OnDisable()
    {
        PlayerPrefs.SetFloat("volume",sound.value);

    }

}
