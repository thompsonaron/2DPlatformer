﻿using LevelManagement.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMixerController : MonoBehaviour
{
    public AudioMixer mixer;
    // Start is called before the first frame update
    [SerializeField]
    private GameObject settingsPanel;

    [SerializeField]
    private Slider _sfxVolumeSlider;

    [SerializeField]
    private Slider _musicVolumeSlider;

    private DataManager _dataManager;

    protected  void Awake()
    {
       // base.Awake();
        _dataManager = Object.FindObjectOfType<DataManager>();
    }

    private void Start()
    {
        LoadData();
    }

    //public void OnMasterVolumeChanged(float volume)
    //{
    //    //if (_dataManager != null)
    //    //{
    //    //    _dataManager.MasterVolume = volume;
            
    //    //}
        
    //}

    public void OnSFXVolumeChanged(float volume)
    {
        if (_dataManager != null)
        {
            _dataManager.SfxVolume = volume;
        }
        mixer.SetFloat("sfxVol", volume);
    }

    public void OnMusicVolumeChanged(float volume)
    {
        if (_dataManager != null)
        {
            _dataManager.MusicVolume = volume;
        }

        mixer.SetFloat("musicVol", volume);
    }

    public void IncreaseByFive()
    {
        mixer.SetFloat("musicVol", 10);
    }

    public  void OnBackPressed()
    {
        //base.OnBackPressed();
        if (_dataManager != null)
        {
            _dataManager.Save();
        }
        settingsPanel.SetActive(false);

    }

    public void LoadData()
    {
        if (_dataManager == null || _sfxVolumeSlider == null || _musicVolumeSlider == null)
        {
            return;
        }
        _dataManager.Load();
      //  _masterVolumeSlider.value = _dataManager.MasterVolume;
        _sfxVolumeSlider.value = _dataManager.SfxVolume;
        _musicVolumeSlider.value = _dataManager.MusicVolume;
    }


}
